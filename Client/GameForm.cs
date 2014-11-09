using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace Client
{
    public partial class GameForm : Form
    {
        public Socket clientSocket;
        public User user;
        private byte[] byteData = new byte[1024];

        public GameForm()
        {
            InitializeComponent();
        }

        private void Login()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var ipAddress = IPAddress.Parse("127.0.0.1");
                //var ipAddress = IPAddress.Parse("192.168.1.77");
                //var ipAddress = IPAddress.Parse("191.235.144.25"); cloudapp
                //Server is listening on port 8000
                var ipEndPoint = new IPEndPoint(ipAddress, 8000);

                //Connect to the server
                clientSocket.BeginConnect(ipEndPoint, OnConnect, clientSocket);

                byteData = new byte[1024];
                //Start listening to the data asynchronously
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_login_LoginPage_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
                //strName = txtName.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndReceive(ar);

                var msgReceived = new Data(byteData);
                //Accordingly process the message received
                switch (msgReceived.Command)
                {
                    case Command.Error:
                        MessageBox.Show(msgReceived.Message, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Command.User:
                        user = new User(msgReceived.Message);
                        tabs.Invoke(new Action(() =>
                        {
                            tabs.SelectedTab = MainPage;
                            label_name_MainPage.Text = user.name;
                            label_wins_MainPage.Text = user.wins.ToString();
                            label_losses_MainPage.Text = user.losses.ToString();
                            label_rating_MainPage.Text = user.rating.ToString();
                        }));
                        break;
                }

            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnConnect(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndConnect(ar);

                //We are connected so we login into the server
                var msgToSend = new Data
                {
                    Command = Command.Login,
                    Name = textBox_name_LoginPage.Text,
                    Password = textBox_password_LoginPage.Text
                };

                byte[] b = msgToSend.ToByte();

                //Send the message to the server
                clientSocket.BeginSend(b, 0, b.Length, SocketFlags.None, OnSend, clientSocket);
                //clientSocket.Send(b);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_logout_MainPage_Click(object sender, EventArgs e)
        {
            if (!CloseConnection()) return;
            tabs.Invoke(new Action(() =>
            {
                tabs.SelectedTab = LoginPage;
            }));
        }

        public bool CloseConnection()
        {
            if (MessageBox.Show(@"Are you sure you want to leave the game?", @"Battleship",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return false;
            }

            try
            {
                //Send a message to logout of the server
                var msgToSend = new Data { Command = Command.Logout, Name = user.name };
                var b = msgToSend.ToByte();
                clientSocket.Send(b);
                clientSocket.Close();

                return true;
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
