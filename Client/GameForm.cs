using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using Client.Properties;

namespace Client
{
    public partial class GameForm : Form
    {
        public enum GameState
        {
            Arrange,
            Wait,
            Play,
            Turn
        }

        public Socket clientSocket = null;
        public User user = null;
        public User opponent;
        public byte[] byteData = new byte[1024];
        public GameState gameState;
        public Board ownBoard;
        public Board opponentBoard;
        public int x;
        public int y;
        public Random rnd = new Random();
        public bool isMouseHover = false;
        public SoundPlayer player = new SoundPlayer();
        public bool isMouseDown = false;
        public bool createShip = true;
        public Data msgToSend;
        public byte[] message;
        public Data msgReceived;

        public GameForm()
        {
            InitializeComponent();

            MaximumSize = MinimumSize = Size;
        }

        /*
        public void ArrangeShips()
        {
            ownBoard.ArrangeShip(new TupleList<int, int>
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
            });

            ownBoard.ArrangeShip(new TupleList<int, int>
            {
                {0, 2},
                {1, 2},
                {2, 2},
            });

            ownBoard.ArrangeShip(new TupleList<int, int>
            {
                {0, 4},
                {1, 4},
                {2, 4},
            });

            ownBoard.ArrangeShip(new TupleList<int, int>
            {
                {0, 6},
                {1, 6},
            });

            ownBoard.ArrangeShip(new TupleList<int, int>
            {
                {0, 8},
                {1, 8},
            });

            ownBoard.ArrangeShip(new TupleList<int, int>
            {
                {3, 8},
                {4, 8},
            });

            ownBoard.ArrangeShip(new TupleList<int, int>
            {
                {9, 9},
            });

            ownBoard.ArrangeShip(new TupleList<int, int>
            {
                {9, 7},
            });

            ownBoard.ArrangeShip(new TupleList<int, int>
            {
                {9, 5},
            });

            ownBoard.ArrangeShip(new TupleList<int, int>
            {
                {9, 3},
            });
        }
        */

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndReceive(ar);

                msgReceived = new Data(byteData);
                //Accordingly process the message received
                switch (msgReceived.Command)
                {
                    case Command.RegisterSuccess:
                        MessageBox.Show(msgReceived.Message, @"Battleship", MessageBoxButtons.OK);
                        clientSocket.Close();
                        break;
                    case Command.Error:
                        MessageBox.Show(msgReceived.Message, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Command.User:
                        user = new User(msgReceived.Message);
                        tabs.Invoke(new Action(() =>
                        {
                            tabs.SelectedTab = tab_main;
                            label_name_MainPage.Text = user.name;
                            label_wins_MainPage.Text = user.wins.ToString();
                            label_losses_MainPage.Text = user.losses.ToString();
                            label_rating_MainPage.Text = user.rating.ToString();
                        }));
                        break;
                    case Command.GameFound:
                        opponent = new User(msgReceived.Message);
                        //ArrangeShips();
                        tabs.Invoke(new Action(() =>
                        {
                            tabs.SelectedTab = tab_game;
                            label_ownName_GamePage.Text = user.name;
                            label_opponentName_GamePage.Text = opponent.name;
                            label_status_GamePage.Text = @"arrange your ships";
                            gameState = GameState.Arrange;
                        }));
                        break;
                    case Command.StartGame:
                        gameState = GameState.Wait;
                        tabs.Invoke(new Action(() =>
                        {
                            button_ready_GamePage.Visible = false;
                            label_status_GamePage.Text = @"waiting for your turn";
                        }));
                        break;
                    case Command.Turn:
                        gameState = GameState.Turn;
                        tabs.Invoke(new Action(() =>
                        {
                            label_status_GamePage.Text = @"your turn";
                        }));
                        break;
                    case Command.Shot:
                        //MessageBox.Show(string.Format("{0}, {1}", msgReceived.X, msgReceived.Y));
                        switch (ownBoard.matrix[msgReceived.X, msgReceived.Y])
                        {
                            case Cell.Empty:
                                ownBoard.matrix[msgReceived.X, msgReceived.Y] = Cell.Miss;
                                player.Stream = Resources.miss;
                                player.Play();
                                gameState = GameState.Turn;
                                tabs.Invoke(new Action(() =>
                                {
                                    label_status_GamePage.Text = @"your turn";
                                }));
                                break;
                            case Cell.Ship:
                                ownBoard.matrix[msgReceived.X, msgReceived.Y] = Cell.Hit;
                                player.Stream = (rnd.Next(0, 2) == 0) ? Resources.explosion : Resources.explosion_other;
                                player.Play();
                                if (ownBoard.CountAliveCells(msgReceived.X, msgReceived.Y) == 0)
                                {
                                    ownBoard.RoundShip(msgReceived.X, msgReceived.Y, true);
                                }
                                break;
                        }
                        panel_ownBoard_GamePage.Invalidate();
                        break;
                    case Command.ShotResult:
                        x = msgReceived.X;
                        y = msgReceived.Y;
                        opponentBoard.matrix[x, y] = msgReceived.Cell;
                        switch (msgReceived.Cell)
                        {
                            case Cell.Miss:
                                player.Stream = Resources.miss;
                                player.Play();
                                gameState = GameState.Wait;
                                tabs.Invoke(new Action(() =>
                                {
                                    label_status_GamePage.Text = @"opponent's turn";
                                }));
                                break;
                            case Cell.Hit:
                                gameState = GameState.Turn;
                                player.Stream = (rnd.Next(0, 2) == 0) ? Resources.explosion : Resources.explosion_other;
                                player.Play();
                                break;
                            case Cell.LastHit:
                                opponentBoard.matrix[x, y] = Cell.Hit;
                                opponentBoard.RoundShip(x, y, true);
                                gameState = GameState.Turn;
                                player.Stream = Resources.explosion_finish;
                                player.Play();
                                break;
                        }
                        panel_opponentBoard_GamePage.Invalidate();
                        break;
                    case Command.Win:
                        player.Stream = Resources.win;
                        player.Play();
                        Invoke(new Action(() => MessageBox.Show(this, @"You win!")));
                        tabs.Invoke(new Action(() =>
                        {
                            tabs.SelectedTab = tab_main;
                        }));
                        break;
                    case Command.Lose:
                        player.Stream = Resources.loose;
                        player.Play();
                        Invoke(new Action(() => MessageBox.Show(this, @"You lose!")));
                        tabs.Invoke(new Action(() =>
                        {
                            tabs.SelectedTab = tab_main;
                        }));
                        break;
                }
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show(ex.StackTrace, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnConnect(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndConnect(ar);

                //We are connected so we login into the server
                msgToSend = new Data
                {
                    Command = Command.Login,
                    Name = textBox_name_LoginPage.Text,
                    Password = textBox_password_LoginPage.Text
                };

                message = msgToSend.ToByte();

                //Send the message to the server
                clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, OnSend, clientSocket);
                //clientSocket.Send(b);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var ipAddress = IPAddress.Parse(textBox_server_LoginPage.Text);
                //var ipAddress = IPAddress.Parse("192.168.1.77");
                //var ipAddress = IPAddress.Parse("191.235.144.25"); cloudapp
                //Server is listening on port 8000
                var ipEndPoint = new IPEndPoint(ipAddress, 8000);

                //Connect to the server
                //clientSocket.BeginConnect(ipEndPoint, OnConnect, clientSocket);
                clientSocket.Connect(ipEndPoint);

                msgToSend = new Data
                {
                    Command = Command.Login,
                    Name = textBox_name_LoginPage.Text,
                    Password = textBox_password_LoginPage.Text
                };

                message = msgToSend.ToByte();

                //Send the message to the server
                clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, OnSend, clientSocket);

                byteData = new byte[1024];
                //Start listening to the data asynchronously
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_login_LoginPage_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void button_logout_MainPage_Click(object sender, EventArgs e)
        {
            if (!CloseConnection()) return;
            tabs.Invoke(new Action(() =>
            {
                tabs.SelectedTab = tab_login;
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
                if (clientSocket == null || user == null) return true;
                
                //Send a message to logout of the server
                msgToSend = new Data { Command = Command.Logout, Name = user.name };
                message = msgToSend.ToByte();
                clientSocket.Send(message);
                clientSocket.Close();

                return true;
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, @"Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        private void button_findGame_MainPage_Click(object sender, EventArgs e)
        {
            ownBoard = new Board();
            opponentBoard = new Board();

            msgToSend = new Data { Command = Command.FindGame };

            message = msgToSend.ToByte();

            //Send it to the server
            clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, OnSend, clientSocket);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseConnection())
            {
                e.Cancel = true;
                return;
            }
        }

        private void panel_ownBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.RoyalBlue), new Rectangle(0, 0, 300, 300));
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    g.DrawRectangle(new Pen(Color.Black, 1), i * 30, j * 30, 30, 30);
                    switch (ownBoard.matrix[i, j])
                    {
                        case Cell.Empty:

                            break;
                        case Cell.Miss:
                            g.DrawEllipse(new Pen(Color.DarkBlue, 5), i * 30 + 13, j * 30 + 13, 5, 5);
                            break;
                        case Cell.Ship:
                            g.FillRectangle(new SolidBrush(Color.DimGray), i * 30, j * 30, 30, 30);
                            g.DrawRectangle(new Pen(Color.Black, 3), i * 30, j * 30, 30, 30);
                            break;
                        case Cell.Hit:
                            g.FillRectangle(new SolidBrush(Color.DimGray), i * 30, j * 30, 30, 30);
                            g.DrawRectangle(new Pen(Color.Black, 3), i * 30, j * 30, 30, 30);
                            g.DrawLine(new Pen(Color.DarkRed, 3), i * 30, j * 30, (i + 1) * 30, (j + 1) * 30);
                            g.DrawLine(new Pen(Color.DarkRed, 3), (i + 1) * 30, j * 30, i * 30, (j + 1) * 30);
                            break;
                    }
                }
            }
        }

        private void panel_opponentBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.RoyalBlue), new Rectangle(0, 0, 300, 300));
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    g.DrawRectangle(new Pen(Color.Black, 1), i * 30, j * 30, 30, 30);
                    switch (opponentBoard.matrix[i, j])
                    {
                        case Cell.Empty:

                            break;
                        case Cell.Miss:
                            g.DrawEllipse(new Pen(Color.DarkBlue, 5), i * 30 + 13, j * 30 + 13, 5, 5);
                            break;
                        case Cell.Ship:
                            g.FillRectangle(new SolidBrush(Color.DimGray), i * 30, j * 30, 30, 30);
                            g.DrawRectangle(new Pen(Color.Black, 3), i * 30, j * 30, 30, 30);
                            break;
                        case Cell.Hit:
                            //g.FillRectangle(new SolidBrush(Color.DimGray), i * 30, j * 30, 30, 30);
                            //g.DrawRectangle(new Pen(Color.Black, 3), i * 30, j * 30, 30, 30);
                            g.DrawLine(new Pen(Color.DarkRed, 3), i * 30, j * 30, (i + 1) * 30, (j + 1) * 30);
                            g.DrawLine(new Pen(Color.DarkRed, 3), (i + 1) * 30, j * 30, i * 30, (j + 1) * 30);
                            break;
                    }
                }
            }
            if (gameState == GameState.Turn && isMouseHover)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Yellow)), 0, y * 30, 300, 30);
                g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Yellow)), x * 30, 0, 30, 300);
            }
        }

        private void panel_ownBoard_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;

            if (gameState == GameState.Arrange)
            {
                if (ownBoard.matrix[x, y] == Cell.Empty)
                {
                    ownBoard.matrix[x, y] = Cell.Ship;
                    createShip = true;
                }
                else if (ownBoard.matrix[x, y] == Cell.Ship)
                {
                    ownBoard.matrix[x, y] = Cell.Empty;
                    createShip = false;
                }
            }

            panel_ownBoard_GamePage.Invalidate();
        }

        private void panel_ownBoard_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void panel_ownBoard_MouseMove(object sender, MouseEventArgs e)
        {
            var position = panel_ownBoard_GamePage.PointToClient(Cursor.Position);
            x = position.X / 30;
            y = position.Y / 30;
            if (x < 0 || x > 9 || y < 0 || y > 9) return;

            if (isMouseDown && gameState == GameState.Arrange)
            {
                if (ownBoard.matrix[x, y] == Cell.Empty && createShip)
                {
                    ownBoard.matrix[x, y] = Cell.Ship;
                }
                else if (ownBoard.matrix[x, y] == Cell.Ship && !createShip)
                {
                    ownBoard.matrix[x, y] = Cell.Empty;
                }
            }

            panel_ownBoard_GamePage.Invalidate();
        }

        private void panel_opponentBoard_MouseLeave(object sender, EventArgs e)
        {
            isMouseHover = false;
            Cursor = Cursors.Default;

            panel_ownBoard_GamePage.Invalidate();
        }

        private void button_ready_GamePage_Click(object sender, EventArgs e)
        {
            if (ownBoard.CheckShipsArrangement())
            {
                gameState = GameState.Wait;
                label_status_GamePage.Text = string.Format("waiting for {0}", opponent.name);
                button_ready_GamePage.Text = @"Waiting...";
                button_ready_GamePage.Enabled = false;

                msgToSend = new Data { Command = Command.Ready };
                message = msgToSend.ToByte(ownBoard);

                clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, OnSend, clientSocket);
            }
            else
            {
                MessageBox.Show(@"Positions of the ships is not valid!");
            }
        }

        private void panel_opponentBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (opponentBoard.matrix[x, y] != Cell.Empty) return;

            if (gameState == GameState.Turn)
            {
                gameState = GameState.Wait;
                /*
                if (opponentBoard.matrix[x, y] == Cell.Empty)
                {
                    opponentBoard.matrix[x, y] = Cell.Miss;

                    player.Stream = Resources.miss;
                    player.Play();
                }
                else if (opponentBoard.matrix[x, y] == Cell.Ship)
                {
                    opponentBoard.matrix[x, y] = Cell.Hit;
                    if (opponentBoard.IsDestroyed(x, y))
                    {
                        player.Stream = Resources.explosion_finish;
                        player.Play();
                    }
                    else
                    {
                        player.Stream = (rnd.Next(0, 2) == 0) ? Resources.explosion : Resources.explosion_other;
                        player.Play();
                    }
                }
                */
                msgToSend = new Data
                {
                    Command = Command.Shot,
                    X = x,
                    Y = y
                };

                message = msgToSend.ToByte();

                //Send the message to the server
                clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, OnSend, clientSocket);
                //MessageBox.Show("Shot");
            }

            //panel_opponentBoard_GamePage.Invalidate();
        }

        private void panel_opponentBoard_GamePage_MouseMove(object sender, MouseEventArgs e)
        {
            isMouseHover = true;
            var position = panel_opponentBoard_GamePage.PointToClient(Cursor.Position);
            x = position.X / 30;
            y = position.Y / 30;
            if (x < 0 || x > 9 || y < 0 || y > 9) return;

            if (opponentBoard.matrix[x, y] != Cell.Empty && opponentBoard.matrix[x, y] != Cell.Ship)
            {
                Cursor = Cursors.No;
            }
            else
            {
                Cursor = Cursors.Default;
            }

            panel_opponentBoard_GamePage.Invalidate();
        }

        private void button_leave_GamePage_Click(object sender, EventArgs e)
        {
            msgToSend = new Data { Command = Command.Lose };

            message = msgToSend.ToByte();

            //Send the message to the server
            clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, OnSend, clientSocket);

            tabs.SelectedTab = tab_main;
        }

        private void button_register_LoginPage_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var ipAddress = IPAddress.Parse(textBox_server_LoginPage.Text);
            var ipEndPoint = new IPEndPoint(ipAddress, 8000);

            //Connect to the server
            clientSocket.Connect(ipEndPoint);

            msgToSend = new Data
            {
                Command = Command.Register,
                Name = textBox_name_LoginPage.Text,
                Password = textBox_password_LoginPage.Text
            };

            message = msgToSend.ToByte();

            //Send the message to the server
            clientSocket.Send(message, 0, message.Length, SocketFlags.None);

            byteData = new byte[1024];
            //Start listening to the data asynchronously
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, clientSocket);
        }
    }
}
