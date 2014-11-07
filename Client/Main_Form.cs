using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace Client
{
    public partial class Main_Form : Form
    {
        public Socket clientSocket;
        public User user;
        public User opponent;
        private byte[] byteData = new byte[1024];
        public bool appClose = true;

        public Main_Form()
        {
            InitializeComponent();
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndReceive(ar);

                Data msgReceived = new Data(byteData);
                //Accordingly process the message received
                switch (msgReceived.Command)
                {
                    case Command.GameFound:
                        opponent = new User(msgReceived.Message);
                        appClose = false;
                        Hide();
                        var gameForm = new Game_Form { clientSocket = clientSocket, user = user, opponent = opponent };
                        gameForm.ShowDialog();
                        Show();
                        appClose = true;
                        break;
                }

                byteData = new byte[1024];

                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, null);

            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            label_name.Text = user.name;
            label_wins.Text = user.wins.ToString();
            label_losses.Text = user.losses.ToString();
            label_rating.Text = user.rating.ToString();

            byteData = new byte[1024];
            //Start listening to the data asynchronously
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
        }

        private void button_FindGame_Click(object sender, EventArgs e)
        {
            try
            {
                //Fill the info for the message to be send
                Data msgToSend = new Data();

                msgToSend.Command = Command.FindGame;

                byte[] byteData = msgToSend.ToByte();

                //Send it to the server
                //clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, OnSend, null);
                clientSocket.Send(byteData);

                //txtMessage.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to send message to the server.", "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (appClose == true)
            {
                Application.Exit();
            }

            if (appClose == true && MessageBox.Show("Are you sure you want to leave the game?", "Battleship",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                //Send a message to logout of the server
                Data msgToSend = new Data();
                msgToSend.Command = Command.Logout;
                msgToSend.Name = user.name;

                byte[] b = msgToSend.ToByte();
                clientSocket.Send(b);
                //clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, OnSend, clientSocket);
                //Thread.Sleep(100);
                clientSocket.Close();
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Logout_Click(object sender, EventArgs e)
        {
            appClose = false;
            Close();
        }
    }
}
