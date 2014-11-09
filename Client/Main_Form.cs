using System;
using System.Net.Sockets;
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
        public string closeAction = "close";
        public Login_Form parent;

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
                    case Command.GameFound:
                        opponent = new User(msgReceived.Message);
                        closeAction = "hide";
                        Hide();
                        var gameForm = new Game_Form { clientSocket = clientSocket, user = user, opponent = opponent, parent = this};
                        clientSocket.EndSend(ar);
                        gameForm.ShowDialog();
                        Show();
                        break;
                }

                byteData = new byte[1024];

                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, null);

            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_FindGame_Click(object sender, EventArgs e)
        {
            try
            {
                //Fill the info for the message to be send
                var msgToSend = new Data {Command = Command.FindGame};

                var byteData = msgToSend.ToByte();

                //Send it to the server
                //clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, OnSend, null);
                clientSocket.Send(byteData);

                //txtMessage.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Unable to send message to the server.", @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeAction != "logout" && closeAction != "close") return;
            if (closeAction == "close")
            {
                Application.Exit();
            }

            if (MessageBox.Show(@"Are you sure you want to leave the game?", @"Battleship",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                //Send a message to logout of the server
                var msgToSend = new Data {Command = Command.Logout, Name = user.name};
                var b = msgToSend.ToByte();
                clientSocket.Send(b);
                clientSocket.Close();

                if (closeAction == "logout")
                {
                    parent.Show();
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Logout_Click(object sender, EventArgs e)
        {
            closeAction = "logout";
            Close();
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
    }
}
