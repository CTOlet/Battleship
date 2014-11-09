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
            this.LoginPage = new System.Windows.Forms.TabPage();
            this.button_register_LoginPage = new System.Windows.Forms.Button();
            this.button_login_LoginPage = new System.Windows.Forms.Button();
            this.label_password_LoginPage = new System.Windows.Forms.Label();
            this.label_nameTitle_LoginPage = new System.Windows.Forms.Label();
            this.textBox_password_LoginPage = new System.Windows.Forms.TextBox();
            this.textBox_name_LoginPage = new System.Windows.Forms.TextBox();
            this.MainPage = new System.Windows.Forms.TabPage();
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
            this.tabs.SuspendLayout();
            this.LoginPage.SuspendLayout();
            this.MainPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.LoginPage);
            this.tabs.Controls.Add(this.MainPage);
            this.tabs.Location = new System.Drawing.Point(0, -21);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(660, 389);
            this.tabs.TabIndex = 0;
            // 
            // LoginPage
            // 
            this.LoginPage.BackColor = System.Drawing.SystemColors.Control;
            this.LoginPage.Controls.Add(this.button_register_LoginPage);
            this.LoginPage.Controls.Add(this.button_login_LoginPage);
            this.LoginPage.Controls.Add(this.label_password_LoginPage);
            this.LoginPage.Controls.Add(this.label_nameTitle_LoginPage);
            this.LoginPage.Controls.Add(this.textBox_password_LoginPage);
            this.LoginPage.Controls.Add(this.textBox_name_LoginPage);
            this.LoginPage.Location = new System.Drawing.Point(4, 22);
            this.LoginPage.Name = "LoginPage";
            this.LoginPage.Padding = new System.Windows.Forms.Padding(3);
            this.LoginPage.Size = new System.Drawing.Size(652, 363);
            this.LoginPage.TabIndex = 0;
            this.LoginPage.Text = "tabPage1";
            // 
            // button_register_LoginPage
            // 
            this.button_register_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_register_LoginPage.Location = new System.Drawing.Point(213, 199);
            this.button_register_LoginPage.Name = "button_register_LoginPage";
            this.button_register_LoginPage.Size = new System.Drawing.Size(110, 29);
            this.button_register_LoginPage.TabIndex = 9;
            this.button_register_LoginPage.Text = "Register";
            this.button_register_LoginPage.UseVisualStyleBackColor = true;
            // 
            // button_login_LoginPage
            // 
            this.button_login_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_login_LoginPage.Location = new System.Drawing.Point(329, 199);
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
            this.label_password_LoginPage.Location = new System.Drawing.Point(213, 170);
            this.label_password_LoginPage.Name = "label_password_LoginPage";
            this.label_password_LoginPage.Size = new System.Drawing.Size(78, 20);
            this.label_password_LoginPage.TabIndex = 8;
            this.label_password_LoginPage.Text = "Password";
            // 
            // label_nameTitle_LoginPage
            // 
            this.label_nameTitle_LoginPage.AutoSize = true;
            this.label_nameTitle_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_nameTitle_LoginPage.Location = new System.Drawing.Point(213, 138);
            this.label_nameTitle_LoginPage.Name = "label_nameTitle_LoginPage";
            this.label_nameTitle_LoginPage.Size = new System.Drawing.Size(51, 20);
            this.label_nameTitle_LoginPage.TabIndex = 7;
            this.label_nameTitle_LoginPage.Text = "Name";
            // 
            // textBox_password_LoginPage
            // 
            this.textBox_password_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_password_LoginPage.Location = new System.Drawing.Point(297, 167);
            this.textBox_password_LoginPage.Name = "textBox_password_LoginPage";
            this.textBox_password_LoginPage.Size = new System.Drawing.Size(142, 26);
            this.textBox_password_LoginPage.TabIndex = 6;
            // 
            // textBox_name_LoginPage
            // 
            this.textBox_name_LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_name_LoginPage.Location = new System.Drawing.Point(297, 135);
            this.textBox_name_LoginPage.Name = "textBox_name_LoginPage";
            this.textBox_name_LoginPage.Size = new System.Drawing.Size(142, 26);
            this.textBox_name_LoginPage.TabIndex = 5;
            // 
            // MainPage
            // 
            this.MainPage.BackColor = System.Drawing.SystemColors.Control;
            this.MainPage.Controls.Add(this.label_ratingTitle_MainPage);
            this.MainPage.Controls.Add(this.label_rating_MainPage);
            this.MainPage.Controls.Add(this.label_lossesTitle_MainPage);
            this.MainPage.Controls.Add(this.label_losses_MainPage);
            this.MainPage.Controls.Add(this.label_winsTitle_MainPage);
            this.MainPage.Controls.Add(this.label_wins_MainPage);
            this.MainPage.Controls.Add(this.label_nameTitle_MainPage);
            this.MainPage.Controls.Add(this.label_name_MainPage);
            this.MainPage.Controls.Add(this.button_logout_MainPage);
            this.MainPage.Controls.Add(this.button_statistics_MainPage);
            this.MainPage.Controls.Add(this.button_findGame_MainPage);
            this.MainPage.Location = new System.Drawing.Point(4, 22);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainPage.Size = new System.Drawing.Size(652, 363);
            this.MainPage.TabIndex = 1;
            this.MainPage.Text = "tabPage2";
            // 
            // label_ratingTitle_MainPage
            // 
            this.label_ratingTitle_MainPage.AutoSize = true;
            this.label_ratingTitle_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ratingTitle_MainPage.Location = new System.Drawing.Point(206, 214);
            this.label_ratingTitle_MainPage.Name = "label_ratingTitle_MainPage";
            this.label_ratingTitle_MainPage.Size = new System.Drawing.Size(60, 20);
            this.label_ratingTitle_MainPage.TabIndex = 15;
            this.label_ratingTitle_MainPage.Text = "Rating:";
            // 
            // label_rating_MainPage
            // 
            this.label_rating_MainPage.AutoSize = true;
            this.label_rating_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_rating_MainPage.Location = new System.Drawing.Point(276, 214);
            this.label_rating_MainPage.Name = "label_rating_MainPage";
            this.label_rating_MainPage.Size = new System.Drawing.Size(18, 20);
            this.label_rating_MainPage.TabIndex = 13;
            this.label_rating_MainPage.Text = "0";
            // 
            // label_lossesTitle_MainPage
            // 
            this.label_lossesTitle_MainPage.AutoSize = true;
            this.label_lossesTitle_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_lossesTitle_MainPage.Location = new System.Drawing.Point(206, 194);
            this.label_lossesTitle_MainPage.Name = "label_lossesTitle_MainPage";
            this.label_lossesTitle_MainPage.Size = new System.Drawing.Size(64, 20);
            this.label_lossesTitle_MainPage.TabIndex = 16;
            this.label_lossesTitle_MainPage.Text = "Losses:";
            // 
            // label_losses_MainPage
            // 
            this.label_losses_MainPage.AutoSize = true;
            this.label_losses_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_losses_MainPage.Location = new System.Drawing.Point(276, 194);
            this.label_losses_MainPage.Name = "label_losses_MainPage";
            this.label_losses_MainPage.Size = new System.Drawing.Size(18, 20);
            this.label_losses_MainPage.TabIndex = 14;
            this.label_losses_MainPage.Text = "0";
            // 
            // label_winsTitle_MainPage
            // 
            this.label_winsTitle_MainPage.AutoSize = true;
            this.label_winsTitle_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_winsTitle_MainPage.Location = new System.Drawing.Point(206, 174);
            this.label_winsTitle_MainPage.Name = "label_winsTitle_MainPage";
            this.label_winsTitle_MainPage.Size = new System.Drawing.Size(48, 20);
            this.label_winsTitle_MainPage.TabIndex = 12;
            this.label_winsTitle_MainPage.Text = "Wins:";
            // 
            // label_wins_MainPage
            // 
            this.label_wins_MainPage.AutoSize = true;
            this.label_wins_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_wins_MainPage.Location = new System.Drawing.Point(276, 174);
            this.label_wins_MainPage.Name = "label_wins_MainPage";
            this.label_wins_MainPage.Size = new System.Drawing.Size(18, 20);
            this.label_wins_MainPage.TabIndex = 11;
            this.label_wins_MainPage.Text = "0";
            // 
            // label_nameTitle_MainPage
            // 
            this.label_nameTitle_MainPage.AutoSize = true;
            this.label_nameTitle_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_nameTitle_MainPage.Location = new System.Drawing.Point(206, 137);
            this.label_nameTitle_MainPage.Name = "label_nameTitle_MainPage";
            this.label_nameTitle_MainPage.Size = new System.Drawing.Size(55, 20);
            this.label_nameTitle_MainPage.TabIndex = 9;
            this.label_nameTitle_MainPage.Text = "Name:";
            // 
            // label_name_MainPage
            // 
            this.label_name_MainPage.AutoSize = true;
            this.label_name_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name_MainPage.Location = new System.Drawing.Point(276, 137);
            this.label_name_MainPage.Name = "label_name_MainPage";
            this.label_name_MainPage.Size = new System.Drawing.Size(72, 20);
            this.label_name_MainPage.TabIndex = 10;
            this.label_name_MainPage.Text = "alimzhan";
            // 
            // button_logout_MainPage
            // 
            this.button_logout_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_logout_MainPage.Location = new System.Drawing.Point(354, 204);
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
            this.button_statistics_MainPage.Location = new System.Drawing.Point(354, 168);
            this.button_statistics_MainPage.Name = "button_statistics_MainPage";
            this.button_statistics_MainPage.Size = new System.Drawing.Size(93, 30);
            this.button_statistics_MainPage.TabIndex = 7;
            this.button_statistics_MainPage.Text = "Statistics";
            this.button_statistics_MainPage.UseVisualStyleBackColor = true;
            // 
            // button_findGame_MainPage
            // 
            this.button_findGame_MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_findGame_MainPage.Location = new System.Drawing.Point(354, 132);
            this.button_findGame_MainPage.Name = "button_findGame_MainPage";
            this.button_findGame_MainPage.Size = new System.Drawing.Size(93, 30);
            this.button_findGame_MainPage.TabIndex = 8;
            this.button_findGame_MainPage.Text = "Find game";
            this.button_findGame_MainPage.UseVisualStyleBackColor = true;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 365);
            this.Controls.Add(this.tabs);
            this.Name = "GameForm";
            this.Text = "Battleship";
            this.tabs.ResumeLayout(false);
            this.LoginPage.ResumeLayout(false);
            this.LoginPage.PerformLayout();
            this.MainPage.ResumeLayout(false);
            this.MainPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage LoginPage;
        private System.Windows.Forms.TabPage MainPage;
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
    }
}