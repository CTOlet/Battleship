using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace Client
{
    public partial class Main_Form : Form
    {
        public Socket ClientSocket;
        public User User;
        private byte[] byteData = new byte[1024];

        public Main_Form()
        {
            InitializeComponent();
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                ClientSocket.EndSend(ar);
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
            //try
            //{
            //    clientSocket.EndReceive(ar);

            //    Data msgReceived = new Data(byteData);
            //    //Accordingly process the message received
            //    switch (msgReceived.cmdCommand)
            //    {
            //        case Command.Login:
            //            lstChatters.Items.Add(msgReceived.strName);
            //            break;

            //        case Command.Logout:
            //            lstChatters.Items.Remove(msgReceived.strName);
            //            break;

            //        case Command.Message:
            //            break;

            //        case Command.List:
            //            lstChatters.Items.AddRange(msgReceived.strMessage.Split('*'));
            //            lstChatters.Items.RemoveAt(lstChatters.Items.Count - 1);
            //            txtChatBox.Text += "<<<" + strName + " has joined the room>>>\r\n";
            //            break;
            //    }

            //    if (msgReceived.strMessage != null && msgReceived.cmdCommand != Command.List)
            //        txtChatBox.Text += msgReceived.strMessage + "\r\n";

            //    byteData = new byte[1024];

            //    clientSocket.BeginReceive(byteData,
            //                              0,
            //                              byteData.Length,
            //                              SocketFlags.None,
            //                              new AsyncCallback(OnReceive),
            //                              null);

            //}
            //catch (ObjectDisposedException)
            //{ }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            byteData = new byte[1024];
            //Start listening to the data asynchronously
            ClientSocket.BeginReceive(byteData,
                                       0,
                                       byteData.Length,
                                       SocketFlags.None,
                                       new AsyncCallback(OnReceive),
                                       null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Fill the info for the message to be send
                Data msgToSend = new Data();

                msgToSend.Name = User.Name;
                msgToSend.Message = "Hello!";
                msgToSend.Command = Command.Message;

                byte[] byteData = msgToSend.ToByte();

                //Send it to the server
                ClientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

                //txtMessage.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to send message to the server.", "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to leave the game?", "Battleship",
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
                msgToSend.Name = "Alimzhan";

                byte[] b = msgToSend.ToByte();
                ClientSocket.Send(b, 0, b.Length, SocketFlags.None);
                ClientSocket.Close();
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
