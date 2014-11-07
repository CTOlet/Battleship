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
    public partial class Game_Form : Form
    {
        public Socket clientSocket;
        public User user;
        public User opponent;
        private byte[] byteData = new byte[1024];
        public Game_Form()
        {
            InitializeComponent();
        }

        private void Game_Form_Load(object sender, EventArgs e)
        {
            label_OwnName.Text = user.name;
            label_OpponentName.Text = opponent.name;
        }
    }
}
