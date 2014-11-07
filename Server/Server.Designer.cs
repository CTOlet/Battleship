namespace Server
{
    partial class Server
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
            this.components = new System.ComponentModel.Container();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox_Games = new System.Windows.Forms.GroupBox();
            this.listBox_GamesList = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox_Queue = new System.Windows.Forms.GroupBox();
            this.listBox_QueueList = new System.Windows.Forms.ListBox();
            this.groupBox_Online = new System.Windows.Forms.GroupBox();
            this.listBox_OnlineList = new System.Windows.Forms.ListBox();
            this.groupBox_Games.SuspendLayout();
            this.groupBox_Queue.SuspendLayout();
            this.groupBox_Online.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Location = new System.Drawing.Point(9, 9);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(267, 242);
            this.txtLog.TabIndex = 1;
            // 
            // groupBox_Games
            // 
            this.groupBox_Games.Controls.Add(this.listBox_GamesList);
            this.groupBox_Games.Location = new System.Drawing.Point(282, 9);
            this.groupBox_Games.Name = "groupBox_Games";
            this.groupBox_Games.Size = new System.Drawing.Size(153, 134);
            this.groupBox_Games.TabIndex = 3;
            this.groupBox_Games.TabStop = false;
            this.groupBox_Games.Text = "Games";
            // 
            // listBox_GamesList
            // 
            this.listBox_GamesList.FormattingEnabled = true;
            this.listBox_GamesList.Location = new System.Drawing.Point(7, 20);
            this.listBox_GamesList.Name = "listBox_GamesList";
            this.listBox_GamesList.Size = new System.Drawing.Size(140, 108);
            this.listBox_GamesList.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox_Queue
            // 
            this.groupBox_Queue.Controls.Add(this.listBox_QueueList);
            this.groupBox_Queue.Location = new System.Drawing.Point(283, 150);
            this.groupBox_Queue.Name = "groupBox_Queue";
            this.groupBox_Queue.Size = new System.Drawing.Size(152, 101);
            this.groupBox_Queue.TabIndex = 4;
            this.groupBox_Queue.TabStop = false;
            this.groupBox_Queue.Text = "Queue";
            // 
            // listBox_QueueList
            // 
            this.listBox_QueueList.FormattingEnabled = true;
            this.listBox_QueueList.Location = new System.Drawing.Point(7, 20);
            this.listBox_QueueList.Name = "listBox_QueueList";
            this.listBox_QueueList.Size = new System.Drawing.Size(139, 69);
            this.listBox_QueueList.TabIndex = 0;
            // 
            // groupBox_Online
            // 
            this.groupBox_Online.Controls.Add(this.listBox_OnlineList);
            this.groupBox_Online.Location = new System.Drawing.Point(442, 9);
            this.groupBox_Online.Name = "groupBox_Online";
            this.groupBox_Online.Size = new System.Drawing.Size(125, 242);
            this.groupBox_Online.TabIndex = 5;
            this.groupBox_Online.TabStop = false;
            this.groupBox_Online.Text = "Online";
            // 
            // listBox_OnlineList
            // 
            this.listBox_OnlineList.FormattingEnabled = true;
            this.listBox_OnlineList.Location = new System.Drawing.Point(7, 20);
            this.listBox_OnlineList.Name = "listBox_OnlineList";
            this.listBox_OnlineList.Size = new System.Drawing.Size(112, 212);
            this.listBox_OnlineList.TabIndex = 0;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 261);
            this.Controls.Add(this.groupBox_Online);
            this.Controls.Add(this.groupBox_Queue);
            this.Controls.Add(this.groupBox_Games);
            this.Controls.Add(this.txtLog);
            this.Name = "Server";
            this.Text = "Battleship: Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_Games.ResumeLayout(false);
            this.groupBox_Queue.ResumeLayout(false);
            this.groupBox_Online.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox_Games;
        private System.Windows.Forms.ListBox listBox_GamesList;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox_Queue;
        private System.Windows.Forms.ListBox listBox_QueueList;
        private System.Windows.Forms.GroupBox groupBox_Online;
        private System.Windows.Forms.ListBox listBox_OnlineList;
    }
}

