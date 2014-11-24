namespace Client
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.tab_login = new System.Windows.Forms.TabPage();
            this.button_register_LoginPage = new System.Windows.Forms.Button();
            this.button_login_LoginPage = new System.Windows.Forms.Button();
            this.label_password_LoginPage = new System.Windows.Forms.Label();
            this.label_serverTitle_LoginPage = new System.Windows.Forms.Label();
            this.label_nameTitle_LoginPage = new System.Windows.Forms.Label();
            this.textBox_password_LoginPage = new System.Windows.Forms.TextBox();
            this.textBox_server_LoginPage = new System.Windows.Forms.TextBox();
            this.textBox_name_LoginPage = new System.Windows.Forms.TextBox();
            this.tab_main = new System.Windows.Forms.TabPage();
            this.label_ratingTitle_MainPage = new System.Windows.Forms.Label();
            this.label_rating_MainPage = new System.Windows.Forms.Label();
            this.label_lossesTitle_MainPage = new System.Windows.Forms.Label();
            this.label_losses_MainPage = new System.Windows.Forms.Label();
            this.label_winsTitle_MainPage = new System.Windows.Forms.Label();
            this.label_wins_MainPage = new System.Windows.Forms.Label();
            this.label_nameTitle_MainPage = new System.Windows.Forms.Label();
            this.label_name_MainPage = new System.Windows.Forms.Label();
            this.button_logout_MainPage = new System.Windows.Forms.Button();
            this.button_statistics_MainPage = new System.Windows.Forms.Button();
            this.button_findGame_MainPage = new System.Windows.Forms.Button();
            this.tab_game = new System.Windows.Forms.TabPage();
            this.panel_opponentBoard_GamePage = new Client.BufferedPanel();
            this.panel_ownBoard_GamePage = new Client.BufferedPanel();
            this.button_ready_GamePage = new System.Windows.Forms.Button();
            this.button_leave_GamePage = new System.Windows.Forms.Button();
            this.label_opponentName_GamePage = new System.Windows.Forms.Label();
            this.label_opponentNameTitle_GamePage = new System.Windows.Forms.Label();
            this.label_status_GamePage = new System.Windows.Forms.Label();
            this.label_statusTitle_GamePage = new System.Windows.Forms.Label();
            this.label_ownName_GamePage = new System.Windows.Forms.Label();
            this.label_ownNameTitle_GamePage = new System.Windows.Forms.Label();
            this.tab_statistics = new System.Windows.Forms.TabPage();
            this.button_mainMenu_StatisticsPage = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabs.SuspendLayout();
            this.tab_login.SuspendLayout();
            this.tab_main.SuspendLayout();
            this.tab_game.SuspendLayout();
            this.tab_statistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tab_login);
            this.tabs.Controls.Add(this.tab_main);
            this.tabs.Controls.Add(this.tab_game);
            this.tabs.Controls.Add(this.tab_statistics);
            this.tabs.Location = new System.Drawing.Point(0, -21);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(639, 405);
            this.tabs.TabIndex = 0;
            // 
            // tab_login
            // 
            this.tab_login.BackColor = System.Drawing.SystemColors.Control;
            this.tab_login.Controls.Add(this.button_register_LoginPage);
            this.tab_login.Controls.Add(this.button_login_LoginPage);
            this.tab_login.Controls.Add(this.label_password_LoginPage);
            this.tab_login.Controls.Add(this.label_serverTitle_LoginPage);
            this.tab_login.Controls.Add(this.label_nameTitle_LoginPage);
            this.tab_login.Controls.Add(this.textBox_password_LoginPage);
            this.tab_login.Controls.Add(this.textBox_server_LoginPage);
            this.tab_login.Controls.Add(this.textBox_name_LoginPage);
            this.tab_login.Location = new System.Drawing.Point(4, 22);
            this.tab_login.Name = "tab_login";
            this.tab_login.Padding = new System.Windows.Forms.Padding(3);
            this.tab_login.Size = new System.Drawing.Size(631, 379);
            this.tab_login.TabIndex = 0;
            this.tab_login.Text = "tabPage1";
            // 
            // button_register_LoginPage
            // 
            this.button_register_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_register_LoginPage.Location = new System.Drawing.Point(202, 207);
            this.button_register_LoginPage.Name = "button_register_LoginPage";
            this.button_register_LoginPage.Size = new System.Drawing.Size(110, 29);
            this.button_register_LoginPage.TabIndex = 9;
            this.button_register_LoginPage.Text = "Register";
            this.button_register_LoginPage.UseVisualStyleBackColor = true;
            this.button_register_LoginPage.Click += new System.EventHandler(this.button_register_LoginPage_Click);
            // 
            // button_login_LoginPage
            // 
            this.button_login_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_login_LoginPage.Location = new System.Drawing.Point(318, 207);
            this.button_login_LoginPage.Name = "button_login_LoginPage";
            this.button_login_LoginPage.Size = new System.Drawing.Size(110, 29);
            this.button_login_LoginPage.TabIndex = 10;
            this.button_login_LoginPage.Text = "Login";
            this.button_login_LoginPage.UseVisualStyleBackColor = true;
            this.button_login_LoginPage.Click += new System.EventHandler(this.button_login_LoginPage_Click);
            // 
            // label_password_LoginPage
            // 
            this.label_password_LoginPage.AutoSize = true;
            this.label_password_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_password_LoginPage.Location = new System.Drawing.Point(202, 178);
            this.label_password_LoginPage.Name = "label_password_LoginPage";
            this.label_password_LoginPage.Size = new System.Drawing.Size(78, 20);
            this.label_password_LoginPage.TabIndex = 8;
            this.label_password_LoginPage.Text = "Password";
            // 
            // label_serverTitle_LoginPage
            // 
            this.label_serverTitle_LoginPage.AutoSize = true;
            this.label_serverTitle_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_serverTitle_LoginPage.Location = new System.Drawing.Point(202, 114);
            this.label_serverTitle_LoginPage.Name = "label_serverTitle_LoginPage";
            this.label_serverTitle_LoginPage.Size = new System.Drawing.Size(55, 20);
            this.label_serverTitle_LoginPage.TabIndex = 7;
            this.label_serverTitle_LoginPage.Text = "Server";
            // 
            // label_nameTitle_LoginPage
            // 
            this.label_nameTitle_LoginPage.AutoSize = true;
            this.label_nameTitle_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_nameTitle_LoginPage.Location = new System.Drawing.Point(202, 146);
            this.label_nameTitle_LoginPage.Name = "label_nameTitle_LoginPage";
            this.label_nameTitle_LoginPage.Size = new System.Drawing.Size(51, 20);
            this.label_nameTitle_LoginPage.TabIndex = 7;
            this.label_nameTitle_LoginPage.Text = "Name";
            // 
            // textBox_password_LoginPage
            // 
            this.textBox_password_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_password_LoginPage.Location = new System.Drawing.Point(286, 175);
            this.textBox_password_LoginPage.Name = "textBox_password_LoginPage";
            this.textBox_password_LoginPage.Size = new System.Drawing.Size(142, 26);
            this.textBox_password_LoginPage.TabIndex = 6;
            this.textBox_password_LoginPage.Text = "123";
            // 
            // textBox_server_LoginPage
            // 
            this.textBox_server_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_server_LoginPage.Location = new System.Drawing.Point(286, 111);
            this.textBox_server_LoginPage.Name = "textBox_server_LoginPage";
            this.textBox_server_LoginPage.Size = new System.Drawing.Size(142, 26);
            this.textBox_server_LoginPage.TabIndex = 5;
            this.textBox_server_LoginPage.Text = "191.235.144.25";
            // 
            // textBox_name_LoginPage
            // 
            this.textBox_name_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_name_LoginPage.Location = new System.Drawing.Point(286, 143);
            this.textBox_name_LoginPage.Name = "textBox_name_LoginPage";
            this.textBox_name_LoginPage.Size = new System.Drawing.Size(142, 26);
            this.textBox_name_LoginPage.TabIndex = 5;
            this.textBox_name_LoginPage.Text = "alimzhan";
            // 
            // tab_main
            // 
            this.tab_main.BackColor = System.Drawing.SystemColors.Control;
            this.tab_main.Controls.Add(this.label_ratingTitle_MainPage);
            this.tab_main.Controls.Add(this.label_rating_MainPage);
            this.tab_main.Controls.Add(this.label_lossesTitle_MainPage);
            this.tab_main.Controls.Add(this.label_losses_MainPage);
            this.tab_main.Controls.Add(this.label_winsTitle_MainPage);
            this.tab_main.Controls.Add(this.label_wins_MainPage);
            this.tab_main.Controls.Add(this.label_nameTitle_MainPage);
            this.tab_main.Controls.Add(this.label_name_MainPage);
            this.tab_main.Controls.Add(this.button_logout_MainPage);
            this.tab_main.Controls.Add(this.button_statistics_MainPage);
            this.tab_main.Controls.Add(this.button_findGame_MainPage);
            this.tab_main.Location = new System.Drawing.Point(4, 22);
            this.tab_main.Name = "tab_main";
            this.tab_main.Padding = new System.Windows.Forms.Padding(3);
            this.tab_main.Size = new System.Drawing.Size(631, 379);
            this.tab_main.TabIndex = 1;
            this.tab_main.Text = "tabPage2";
            // 
            // label_ratingTitle_MainPage
            // 
            this.label_ratingTitle_MainPage.AutoSize = true;
            this.label_ratingTitle_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ratingTitle_MainPage.Location = new System.Drawing.Point(195, 220);
            this.label_ratingTitle_MainPage.Name = "label_ratingTitle_MainPage";
            this.label_ratingTitle_MainPage.Size = new System.Drawing.Size(60, 20);
            this.label_ratingTitle_MainPage.TabIndex = 15;
            this.label_ratingTitle_MainPage.Text = "Rating:";
            // 
            // label_rating_MainPage
            // 
            this.label_rating_MainPage.AutoSize = true;
            this.label_rating_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_rating_MainPage.Location = new System.Drawing.Point(265, 220);
            this.label_rating_MainPage.Name = "label_rating_MainPage";
            this.label_rating_MainPage.Size = new System.Drawing.Size(18, 20);
            this.label_rating_MainPage.TabIndex = 13;
            this.label_rating_MainPage.Text = "0";
            // 
            // label_lossesTitle_MainPage
            // 
            this.label_lossesTitle_MainPage.AutoSize = true;
            this.label_lossesTitle_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_lossesTitle_MainPage.Location = new System.Drawing.Point(195, 200);
            this.label_lossesTitle_MainPage.Name = "label_lossesTitle_MainPage";
            this.label_lossesTitle_MainPage.Size = new System.Drawing.Size(64, 20);
            this.label_lossesTitle_MainPage.TabIndex = 16;
            this.label_lossesTitle_MainPage.Text = "Losses:";
            // 
            // label_losses_MainPage
            // 
            this.label_losses_MainPage.AutoSize = true;
            this.label_losses_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_losses_MainPage.Location = new System.Drawing.Point(265, 200);
            this.label_losses_MainPage.Name = "label_losses_MainPage";
            this.label_losses_MainPage.Size = new System.Drawing.Size(18, 20);
            this.label_losses_MainPage.TabIndex = 14;
            this.label_losses_MainPage.Text = "0";
            // 
            // label_winsTitle_MainPage
            // 
            this.label_winsTitle_MainPage.AutoSize = true;
            this.label_winsTitle_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_winsTitle_MainPage.Location = new System.Drawing.Point(195, 180);
            this.label_winsTitle_MainPage.Name = "label_winsTitle_MainPage";
            this.label_winsTitle_MainPage.Size = new System.Drawing.Size(48, 20);
            this.label_winsTitle_MainPage.TabIndex = 12;
            this.label_winsTitle_MainPage.Text = "Wins:";
            // 
            // label_wins_MainPage
            // 
            this.label_wins_MainPage.AutoSize = true;
            this.label_wins_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_wins_MainPage.Location = new System.Drawing.Point(265, 180);
            this.label_wins_MainPage.Name = "label_wins_MainPage";
            this.label_wins_MainPage.Size = new System.Drawing.Size(18, 20);
            this.label_wins_MainPage.TabIndex = 11;
            this.label_wins_MainPage.Text = "0";
            // 
            // label_nameTitle_MainPage
            // 
            this.label_nameTitle_MainPage.AutoSize = true;
            this.label_nameTitle_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_nameTitle_MainPage.Location = new System.Drawing.Point(195, 143);
            this.label_nameTitle_MainPage.Name = "label_nameTitle_MainPage";
            this.label_nameTitle_MainPage.Size = new System.Drawing.Size(55, 20);
            this.label_nameTitle_MainPage.TabIndex = 9;
            this.label_nameTitle_MainPage.Text = "Name:";
            // 
            // label_name_MainPage
            // 
            this.label_name_MainPage.AutoSize = true;
            this.label_name_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name_MainPage.Location = new System.Drawing.Point(265, 143);
            this.label_name_MainPage.Name = "label_name_MainPage";
            this.label_name_MainPage.Size = new System.Drawing.Size(72, 20);
            this.label_name_MainPage.TabIndex = 10;
            this.label_name_MainPage.Text = "alimzhan";
            // 
            // button_logout_MainPage
            // 
            this.button_logout_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_logout_MainPage.Location = new System.Drawing.Point(343, 210);
            this.button_logout_MainPage.Name = "button_logout_MainPage";
            this.button_logout_MainPage.Size = new System.Drawing.Size(93, 30);
            this.button_logout_MainPage.TabIndex = 6;
            this.button_logout_MainPage.Text = "Logout";
            this.button_logout_MainPage.UseVisualStyleBackColor = true;
            this.button_logout_MainPage.Click += new System.EventHandler(this.button_logout_MainPage_Click);
            // 
            // button_statistics_MainPage
            // 
            this.button_statistics_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_statistics_MainPage.Location = new System.Drawing.Point(343, 174);
            this.button_statistics_MainPage.Name = "button_statistics_MainPage";
            this.button_statistics_MainPage.Size = new System.Drawing.Size(93, 30);
            this.button_statistics_MainPage.TabIndex = 7;
            this.button_statistics_MainPage.Text = "Statistics";
            this.button_statistics_MainPage.UseVisualStyleBackColor = true;
            this.button_statistics_MainPage.Click += new System.EventHandler(this.button_statistics_MainPage_Click);
            // 
            // button_findGame_MainPage
            // 
            this.button_findGame_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_findGame_MainPage.Location = new System.Drawing.Point(343, 138);
            this.button_findGame_MainPage.Name = "button_findGame_MainPage";
            this.button_findGame_MainPage.Size = new System.Drawing.Size(93, 30);
            this.button_findGame_MainPage.TabIndex = 8;
            this.button_findGame_MainPage.Text = "Find game";
            this.button_findGame_MainPage.UseVisualStyleBackColor = true;
            this.button_findGame_MainPage.Click += new System.EventHandler(this.button_findGame_MainPage_Click);
            // 
            // tab_game
            // 
            this.tab_game.Controls.Add(this.panel_opponentBoard_GamePage);
            this.tab_game.Controls.Add(this.panel_ownBoard_GamePage);
            this.tab_game.Controls.Add(this.button_ready_GamePage);
            this.tab_game.Controls.Add(this.button_leave_GamePage);
            this.tab_game.Controls.Add(this.label_opponentName_GamePage);
            this.tab_game.Controls.Add(this.label_opponentNameTitle_GamePage);
            this.tab_game.Controls.Add(this.label_status_GamePage);
            this.tab_game.Controls.Add(this.label_statusTitle_GamePage);
            this.tab_game.Controls.Add(this.label_ownName_GamePage);
            this.tab_game.Controls.Add(this.label_ownNameTitle_GamePage);
            this.tab_game.Location = new System.Drawing.Point(4, 22);
            this.tab_game.Name = "tab_game";
            this.tab_game.Size = new System.Drawing.Size(631, 379);
            this.tab_game.TabIndex = 2;
            this.tab_game.Text = "tabPage1";
            this.tab_game.UseVisualStyleBackColor = true;
            // 
            // panel_opponentBoard_GamePage
            // 
            this.panel_opponentBoard_GamePage.Location = new System.Drawing.Point(319, 31);
            this.panel_opponentBoard_GamePage.Name = "panel_opponentBoard_GamePage";
            this.panel_opponentBoard_GamePage.Size = new System.Drawing.Size(301, 301);
            this.panel_opponentBoard_GamePage.TabIndex = 11;
            this.panel_opponentBoard_GamePage.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_opponentBoard_Paint);
            this.panel_opponentBoard_GamePage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_opponentBoard_MouseClick);
            this.panel_opponentBoard_GamePage.MouseLeave += new System.EventHandler(this.panel_opponentBoard_MouseLeave);
            this.panel_opponentBoard_GamePage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_opponentBoard_GamePage_MouseMove);
            // 
            // panel_ownBoard_GamePage
            // 
            this.panel_ownBoard_GamePage.Location = new System.Drawing.Point(12, 31);
            this.panel_ownBoard_GamePage.Name = "panel_ownBoard_GamePage";
            this.panel_ownBoard_GamePage.Size = new System.Drawing.Size(301, 301);
            this.panel_ownBoard_GamePage.TabIndex = 0;
            this.panel_ownBoard_GamePage.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_ownBoard_Paint);
            this.panel_ownBoard_GamePage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_ownBoard_MouseDown);
            this.panel_ownBoard_GamePage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_ownBoard_MouseMove);
            this.panel_ownBoard_GamePage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_ownBoard_MouseUp);
            // 
            // button_ready_GamePage
            // 
            this.button_ready_GamePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ready_GamePage.Location = new System.Drawing.Point(398, 342);
            this.button_ready_GamePage.Name = "button_ready_GamePage";
            this.button_ready_GamePage.Size = new System.Drawing.Size(108, 30);
            this.button_ready_GamePage.TabIndex = 10;
            this.button_ready_GamePage.Text = "Ready";
            this.button_ready_GamePage.UseVisualStyleBackColor = true;
            this.button_ready_GamePage.Click += new System.EventHandler(this.button_ready_GamePage_Click);
            // 
            // button_leave_GamePage
            // 
            this.button_leave_GamePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_leave_GamePage.Location = new System.Drawing.Point(512, 342);
            this.button_leave_GamePage.Name = "button_leave_GamePage";
            this.button_leave_GamePage.Size = new System.Drawing.Size(108, 30);
            this.button_leave_GamePage.TabIndex = 10;
            this.button_leave_GamePage.Text = "Leave game";
            this.button_leave_GamePage.UseVisualStyleBackColor = true;
            this.button_leave_GamePage.Click += new System.EventHandler(this.button_leave_GamePage_Click);
            // 
            // label_opponentName_GamePage
            // 
            this.label_opponentName_GamePage.AutoSize = true;
            this.label_opponentName_GamePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_opponentName_GamePage.Location = new System.Drawing.Point(405, 7);
            this.label_opponentName_GamePage.Name = "label_opponentName_GamePage";
            this.label_opponentName_GamePage.Size = new System.Drawing.Size(49, 20);
            this.label_opponentName_GamePage.TabIndex = 3;
            this.label_opponentName_GamePage.Text = "name";
            // 
            // label_opponentNameTitle_GamePage
            // 
            this.label_opponentNameTitle_GamePage.AutoSize = true;
            this.label_opponentNameTitle_GamePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_opponentNameTitle_GamePage.Location = new System.Drawing.Point(315, 8);
            this.label_opponentNameTitle_GamePage.Name = "label_opponentNameTitle_GamePage";
            this.label_opponentNameTitle_GamePage.Size = new System.Drawing.Size(84, 20);
            this.label_opponentNameTitle_GamePage.TabIndex = 4;
            this.label_opponentNameTitle_GamePage.Text = "Opponent:";
            // 
            // label_status_GamePage
            // 
            this.label_status_GamePage.AutoSize = true;
            this.label_status_GamePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_status_GamePage.Location = new System.Drawing.Point(61, 347);
            this.label_status_GamePage.Name = "label_status_GamePage";
            this.label_status_GamePage.Size = new System.Drawing.Size(105, 20);
            this.label_status_GamePage.TabIndex = 5;
            this.label_status_GamePage.Text = "arrange ships";
            // 
            // label_statusTitle_GamePage
            // 
            this.label_statusTitle_GamePage.AutoSize = true;
            this.label_statusTitle_GamePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_statusTitle_GamePage.Location = new System.Drawing.Point(8, 347);
            this.label_statusTitle_GamePage.Name = "label_statusTitle_GamePage";
            this.label_statusTitle_GamePage.Size = new System.Drawing.Size(60, 20);
            this.label_statusTitle_GamePage.TabIndex = 5;
            this.label_statusTitle_GamePage.Text = "Status:";
            // 
            // label_ownName_GamePage
            // 
            this.label_ownName_GamePage.AutoSize = true;
            this.label_ownName_GamePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ownName_GamePage.Location = new System.Drawing.Point(56, 8);
            this.label_ownName_GamePage.Name = "label_ownName_GamePage";
            this.label_ownName_GamePage.Size = new System.Drawing.Size(49, 20);
            this.label_ownName_GamePage.TabIndex = 6;
            this.label_ownName_GamePage.Text = "name";
            // 
            // label_ownNameTitle_GamePage
            // 
            this.label_ownNameTitle_GamePage.AutoSize = true;
            this.label_ownNameTitle_GamePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ownNameTitle_GamePage.Location = new System.Drawing.Point(8, 8);
            this.label_ownNameTitle_GamePage.Name = "label_ownNameTitle_GamePage";
            this.label_ownNameTitle_GamePage.Size = new System.Drawing.Size(42, 20);
            this.label_ownNameTitle_GamePage.TabIndex = 7;
            this.label_ownNameTitle_GamePage.Text = "You:";
            // 
            // tab_statistics
            // 
            this.tab_statistics.BackColor = System.Drawing.SystemColors.Control;
            this.tab_statistics.Controls.Add(this.button_mainMenu_StatisticsPage);
            this.tab_statistics.Controls.Add(this.dataGridView);
            this.tab_statistics.Location = new System.Drawing.Point(4, 22);
            this.tab_statistics.Name = "tab_statistics";
            this.tab_statistics.Size = new System.Drawing.Size(631, 379);
            this.tab_statistics.TabIndex = 3;
            this.tab_statistics.Text = "tab_statistics";
            // 
            // button_mainMenu_StatisticsPage
            // 
            this.button_mainMenu_StatisticsPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_mainMenu_StatisticsPage.Location = new System.Drawing.Point(516, 343);
            this.button_mainMenu_StatisticsPage.Name = "button_mainMenu_StatisticsPage";
            this.button_mainMenu_StatisticsPage.Size = new System.Drawing.Size(108, 30);
            this.button_mainMenu_StatisticsPage.TabIndex = 11;
            this.button_mainMenu_StatisticsPage.Text = "Main menu";
            this.button_mainMenu_StatisticsPage.UseVisualStyleBackColor = true;
            this.button_mainMenu_StatisticsPage.Click += new System.EventHandler(this.button_mainMenu_StatisticsPage_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.winnerName,
            this.loserName,
            this.date});
            this.dataGridView.Location = new System.Drawing.Point(8, 11);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(616, 326);
            this.dataGridView.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "#";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // winnerName
            // 
            this.winnerName.HeaderText = "Winner Name";
            this.winnerName.Name = "winnerName";
            this.winnerName.ReadOnly = true;
            // 
            // loserName
            // 
            this.loserName.HeaderText = "Loser Name";
            this.loserName.Name = "loserName";
            this.loserName.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 386);
            this.Controls.Add(this.tabs);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Text = "Battleship";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.tabs.ResumeLayout(false);
            this.tab_login.ResumeLayout(false);
            this.tab_login.PerformLayout();
            this.tab_main.ResumeLayout(false);
            this.tab_main.PerformLayout();
            this.tab_game.ResumeLayout(false);
            this.tab_game.PerformLayout();
            this.tab_statistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tab_login;
        private System.Windows.Forms.TabPage tab_main;
        private System.Windows.Forms.Label label_ratingTitle_MainPage;
        private System.Windows.Forms.Label label_rating_MainPage;
        private System.Windows.Forms.Label label_lossesTitle_MainPage;
        private System.Windows.Forms.Label label_losses_MainPage;
        private System.Windows.Forms.Label label_winsTitle_MainPage;
        private System.Windows.Forms.Label label_wins_MainPage;
        private System.Windows.Forms.Label label_nameTitle_MainPage;
        private System.Windows.Forms.Label label_name_MainPage;
        private System.Windows.Forms.Button button_logout_MainPage;
        private System.Windows.Forms.Button button_statistics_MainPage;
        private System.Windows.Forms.Button button_findGame_MainPage;
        private System.Windows.Forms.Button button_register_LoginPage;
        private System.Windows.Forms.Button button_login_LoginPage;
        private System.Windows.Forms.Label label_password_LoginPage;
        private System.Windows.Forms.Label label_nameTitle_LoginPage;
        private System.Windows.Forms.TextBox textBox_password_LoginPage;
        private System.Windows.Forms.TextBox textBox_name_LoginPage;
        private System.Windows.Forms.TabPage tab_game;
        private System.Windows.Forms.Button button_leave_GamePage;
        private System.Windows.Forms.Label label_opponentName_GamePage;
        private System.Windows.Forms.Label label_opponentNameTitle_GamePage;
        private System.Windows.Forms.Label label_statusTitle_GamePage;
        private System.Windows.Forms.Label label_ownName_GamePage;
        private System.Windows.Forms.Label label_ownNameTitle_GamePage;
        private System.Windows.Forms.Label label_status_GamePage;
        private BufferedPanel panel_ownBoard_GamePage;
        private System.Windows.Forms.Button button_ready_GamePage;
        private BufferedPanel panel_opponentBoard_GamePage;
        private System.Windows.Forms.Label label_serverTitle_LoginPage;
        private System.Windows.Forms.TextBox textBox_server_LoginPage;
        private System.Windows.Forms.TabPage tab_statistics;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn winnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn loserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Button button_mainMenu_StatisticsPage;
    }
}