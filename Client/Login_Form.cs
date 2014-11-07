using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Classes;

namespace Client
{
    public partial class Login_Form : Form
    {
        public Socket clientSocket;
        public User user;
        private byte[] byteData = new byte[1024];

        public Login_Form()
        {
            InitializeComponent();
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
                    case Command.Error:
                        MessageBox.Show(msgReceived.Message, "Battleship: Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Command.User:
                        user = new User(msgReceived.Message);
                        //DialogResult = DialogResult.OK;
                        Hide();
                        var mainForm = new Main_Form();
                        mainForm.clientSocket = clientSocket;
                        mainForm.user = user;
                        mainForm.ShowDialog();
                        Show();
                        break;
                }

            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Battleship client: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnConnect(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndConnect(ar);

                //We are connected so we login into the server
                Data msgToSend = new Data();
                msgToSend.Command = Command.Login;
                msgToSend.Name = textBox_Name.Text;
                msgToSend.Password = textBox_Password.Text;

                byte[] b = msgToSend.ToByte();

                //Send the message to the server
                clientSocket.BeginSend(b, 0, b.Length, SocketFlags.None, OnSend, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void textBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Login();
            }
        }

        private void Login()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                //Server is listening on port 1000
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8000);

                //Connect to the server
                clientSocket.BeginConnect(ipEndPoint, OnConnect, null);

                byteData = new byte[1024];
                //Start listening to the data asynchronously
                clientSocket.BeginReceive(byteData,
                                           0,
                                           byteData.Length,
                                           SocketFlags.None,
                                           OnReceive,
                                           null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
