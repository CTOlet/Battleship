using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Classes;

namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();

            clientList = new List<ClientInfo>();
            findingList = new List<ClientInfo>();
            games = new List<Game>();
        }

        //The collection of all clients logged into the room (an array of type ClientInfo)
        private List<ClientInfo> clientList;

        public string getClientName(Socket clientSocket)
        {
            return (from ClientInfo client in clientList where client.socket == clientSocket select client.name).FirstOrDefault();
        }

        private List<ClientInfo> findingList;
        private List<Game> games;

        //The main socket on which the server listens to the clients
        private Socket serverSocket;

        private byte[] byteData = new byte[1024];

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //We are using TCP sockets
                serverSocket = new Socket(AddressFamily.InterNetwork,
                                          SocketType.Stream,
                                          ProtocolType.Tcp);

                //Assign the any IP of the machine and listen on port number 8000
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 8000);

                //Bind and listen on the given address
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(4);

                //Accept the incoming clients
                serverSocket.BeginAccept(OnAccept, serverSocket);
                txtLog.Text += string.Format("[{0}] The server is listening on port 8000\r\n", DateTime.Now.ToString("hh:mm:ss"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server: Form1_Load",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);

                //Start listening for more clients
                serverSocket.BeginAccept(OnAccept, serverSocket);

                //Once the client connects then start receiving the commands from her
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                    OnReceive, clientSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server: OnAccept",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                clientSocket.EndReceive(ar);

                //Transform the array of bytes received from the user into an
                //intelligent form of object Data
                Data msgReceived = new Data(byteData);

                //We will send this object in response the users request
                Data msgToSend = new Data();

                byte[] message;

                //If the message is to login, logout, or simple text message
                //then when send to others the type of the message remains the same
                msgToSend.Command = msgReceived.Command;
                msgToSend.Name = msgReceived.Name;

                int nIndex;
                switch (msgReceived.Command)
                {
                    case Command.Login:
                        var user = UserDAO.Login(msgReceived.Name, msgReceived.Password);
                        if (user != null)
                        {
                            //When a user logs in to the server then we add her to our
                            //list of clients

                            ClientInfo clientInfo = new ClientInfo();
                            clientInfo.socket = clientSocket;
                            clientInfo.name = msgReceived.Name;

                            clientList.Add(clientInfo);

                            txtLog.Text += String.Format("[{0}] {1} has logged in\r\n",
                                DateTime.Now.ToString("hh:mm:ss"),
                                msgReceived.Name
                                );

                            msgToSend.Command = Command.User;
                            message = msgToSend.ToByte(user);

                            //Send the name of the users in the chat room
                            clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                    OnSend, clientSocket);

                            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
                        }
                        else
                        {
                            msgToSend.Command = Command.Error;
                            msgToSend.Message = "Invalid name/password, please try again";

                            message = msgToSend.ToByte();

                            //Send the name of the users in the chat room
                            //IAsyncResult result = clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnSend), clientSocket);
                            clientSocket.Send(message, 0, message.Length, SocketFlags.None);
                            //while (!result.IsCompleted)
                            //{
                            //    // Do more work here if the call isn't complete
                            //    Thread.Sleep(100);
                            //}

                            nIndex = 0;
                            foreach (ClientInfo client in clientList)
                            {
                                if (client.socket == clientSocket)
                                {
                                    clientList.RemoveAt(nIndex);
                                    break;
                                }
                                ++nIndex;
                            }
                            clientSocket.Close();
                        }
                        break;

                    case Command.Logout:

                        //When a user wants to log out of the server then we search for her 
                        //in the list of clients and close the corresponding connection
                        clientList.RemoveAll(x => x.socket == clientSocket);
                        findingList.RemoveAll(x => x.socket == clientSocket);
                        games.RemoveAll(x => x.player1.socket == clientSocket || x.player2.socket == clientSocket);
                        // TODO: Notificate opponent about leave game by user
                        // TODO: Recalc rank of the users

                        clientSocket.Close();

                        msgToSend.Message = "<<<" + msgReceived.Name + " has disconnected from server>>>";
                        txtLog.Text += string.Format("[{0}] {1} has disconnected from server\r\n", DateTime.Now.ToString("hh:mm:ss"), msgReceived.Name);
                        break;

                    case Command.Message:
                        txtLog.Text += msgReceived.Name + ": " + msgReceived.Message + "\r\n";
                        //Set the text of the message that we will broadcast to all users
                        msgToSend.Message = msgReceived.Name + ": " + msgReceived.Message;

                        clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
                        break;

                    case Command.FindGame:
                        findingList.Add(clientList.First(x => x.socket == clientSocket));
                        txtLog.Text += string.Format("[{0}] {1} is looking for a game...\r\n", DateTime.Now.ToString("hh:mm:ss"), getClientName(clientSocket));

                        if (findingList.Count > 1)
                        {
                            Game game = new Game();
                            game.player1 = findingList[0];
                            game.player2 = findingList[1];
                            game.player1.ready = game.player2.ready = false;
                            findingList.RemoveRange(0, 2);

                            games.Add(game);
                            txtLog.Text += string.Format("[{0}] Connecting {1} with {2}...\r\n", DateTime.Now.ToString("hh:mm:ss"), game.player1.name, game.player2.name);

                            msgToSend.Command = Command.GameFound;

                            message = msgToSend.ToByte(UserDAO.FindByName(game.player2.name));
                            game.player1.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                OnSend, game.player1.socket);

                            message = msgToSend.ToByte(UserDAO.FindByName(game.player1.name));
                            game.player2.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                OnSend, game.player2.socket);
                        }
                        clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
                        break;
                    case Command.Ready:
                        foreach (var game in games)
                        {
                            if (game.player1.socket == clientSocket)
                            {
                                game.player1.ready = true;
                                game.player1.board = new Board(msgReceived.Message);
                            } else if (game.player2.socket == clientSocket)
                            {
                                game.player2.ready = true;
                                game.player2.board = new Board(msgReceived.Message);
                            }
                            if (game.player1.ready && game.player2.ready)
                            {
                                msgToSend.Command = Command.StartGame;
                                message = msgToSend.ToByte();
                                game.player1.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                    OnSend, game.player1.socket);
                                game.player2.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                    OnSend, game.player2.socket);

                                msgToSend.Command = Command.Turn;
                                message = msgToSend.ToByte();
                                game.player1.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                    OnSend, game.player1.socket);
                            }
                        }
                        clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
                        break;
                    case Command.Shot:
                        foreach (var game in games)
                        {
                            if (game.player1.socket == clientSocket)
                            {
                                // send result of the shot back to the client
                                switch (game.player2.board.matrix[msgReceived.X, msgReceived.Y])
                                {
                                    case Cell.Empty:
                                        msgToSend.Cell = Cell.Miss;
                                        break;
                                    case Cell.Ship:
                                        msgToSend.Cell = Cell.Hit;
                                        break;
                                }
                                msgToSend.Command = Command.ShotResult;
                                message = msgToSend.ToByte();
                                clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                            OnSend, clientSocket);

                                // send to opponent shot
                                msgToSend = msgReceived;
                                message = msgToSend.ToByte();
                                game.player2.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                    OnSend, game.player2.socket);
                            } else if (game.player2.socket == clientSocket)
                            {
                                // send result of the shot back to the client
                                switch (game.player1.board.matrix[msgReceived.X, msgReceived.Y])
                                {
                                    case Cell.Empty:
                                        msgToSend.Cell = Cell.Miss;
                                        break;
                                    case Cell.Ship:
                                        msgToSend.Cell = Cell.Hit;
                                        break;
                                }
                                msgToSend.Command = Command.ShotResult;
                                message = msgToSend.ToByte();
                                clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                            OnSend, clientSocket);

                                // send to opponent shot
                                msgToSend = msgReceived;
                                message = msgToSend.ToByte();
                                game.player1.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                    OnSend, game.player1.socket);
                            }
                        }
                        clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server: OnReceive", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server: OnSend", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            groupBox_Games.Text = string.Format("Games [{0}]", games.Count.ToString());
            listBox_GamesList.DataSource = games.Select(x => string.Format("{0} - {1}", x.player1.name, x.player2.name)).ToList();

            groupBox_Queue.Text = string.Format("Queue [{0}]", findingList.Count.ToString());
            listBox_QueueList.DataSource = findingList.Select(x => string.Format("{0}", x.name)).ToList();

            groupBox_Online.Text = string.Format("Online [{0}]", clientList.Count.ToString());
            listBox_OnlineList.DataSource = clientList.Select(x => string.Format("{0}", x.name)).ToList();
        }
    }
}
