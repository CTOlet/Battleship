using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Classes;
using MySql.Data.MySqlClient.Memcached;

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

        public struct ClientInfo
        {
            public Socket socket;   //Socket of the client
            public string name;  //Name by which the user logged into the chat room
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
                serverSocket.BeginAccept(OnAccept, null);
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
                serverSocket.BeginAccept(OnAccept, null);

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

                            games.Add(game);
                            txtLog.Text += string.Format("[{0}] Connecting {1} with {2}...\r\n", DateTime.Now.ToString("hh:mm:ss"), game.player1.name, game.player2.name);

                            msgToSend.Command = Command.GameFound;

                            message = msgToSend.ToByte(UserDAO.FindByName(game.player2.name));
                            game.player1.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                OnSend, null);

                            message = msgToSend.ToByte(UserDAO.FindByName(game.player1.name));
                            game.player2.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                OnSend, null);
                        }
                        clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
                        break;

                    case Command.List:

                        //Send the names of all users in the chat room to the new user
                        msgToSend.Command = Command.List;
                        msgToSend.Name = null;
                        msgToSend.Message = null;

                        //Collect the names of the user in the chat room
                        foreach (ClientInfo client in clientList)
                        {
                            //To keep things simple we use asterisk as the marker to separate the user names
                            msgToSend.Message += client.name + "*";
                        }

                        message = msgToSend.ToByte();

                        //Send the name of the users in the chat room
                        clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                OnSend, clientSocket);
                        break;
                }

                //if (msgToSend.Command != Command.List)   //List messages are not broadcasted
                //{
                //    message = msgToSend.ToByte();

                //    foreach (ClientInfo clientInfo in clientList)
                //    {
                //        if (clientInfo.socket != clientSocket ||
                //            msgToSend.Command != Command.Login)
                //        {
                //            //Send the message to all users
                //            clientInfo.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                //                new AsyncCallback(OnSend), clientInfo.socket);
                //        }
                //    }

                //    txtLog.Text += msgToSend.Message + "\r\n";
                //}
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
            listBox_GamesList.Items.Clear();
            foreach (var game in games.ToList())
            {
                listBox_GamesList.Items.Add(string.Format("{0} - {1}", game.player1.name, game.player2.name));
            }

            listBox_QueueList.Items.Clear();
            foreach (var client in findingList)
            {
                listBox_QueueList.Items.Add(string.Format("{0}", client.name));
            }

            listBox_OnlineList.Items.Clear();
            foreach (ClientInfo clientInfo in clientList)
            {
                listBox_OnlineList.Items.Add(string.Format("{0}", clientInfo.name));
            }
        }
    }
}
