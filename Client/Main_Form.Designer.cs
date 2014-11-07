namespace Client
{
    partial class Main_Form
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
            this.button_FindGame = new System.Windows.Forms.Button();
            this.label_name = new System.Windows.Forms.Label();
            this.label_wins = new System.Windows.Forms.Label();
            this.label_winsTitle = new System.Windows.Forms.Label();
            this.label_lossesTitle = new System.Windows.Forms.Label();
            this.label_losses = new System.Windows.Forms.Label();
            this.label_nameTitle = new System.Windows.Forms.Label();
            this.label_rating = new System.Windows.Forms.Label();
            this.label_ratingTitle = new System.Windows.Forms.Label();
            this.button_Statistics = new System.Windows.Forms.Button();
            this.button_Logout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_FindGame
            // 
            this.button_FindGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_FindGame.Location = new System.Drawing.Point(160, 12);
            this.button_FindGame.Name = "button_FindGame";
            this.button_FindGame.Size = new System.Drawing.Size(93, 30);
            this.button_FindGame.TabIndex = 0;
            this.button_FindGame.Text = "Find game";
            this.button_FindGame.UseVisualStyleBackColor = true;
            this.button_FindGame.Click += new System.EventHandler(this.button_FindGame_Click);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.Location = new System.Drawing.Point(82, 9);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(72, 20);
            this.label_name.TabIndex = 1;
            this.label_name.Text = "alimzhan";
            // 
            // label_wins
            // 
            this.label_wins.AutoSize = true;
            this.label_wins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_wins.Location = new System.Drawing.Point(82, 54);
            this.label_wins.Name = "label_wins";
            this.label_wins.Size = new System.Drawing.Size(18, 20);
            this.label_wins.TabIndex = 2;
            this.label_wins.Text = "0";
            // 
            // label_winsTitle
            // 
            this.label_winsTitle.AutoSize = true;
            this.label_winsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_winsTitle.Location = new System.Drawing.Point(12, 54);
            this.label_winsTitle.Name = "label_winsTitle";
            this.label_winsTitle.Size = new System.Drawing.Size(48, 20);
            this.label_winsTitle.TabIndex = 3;
            this.label_winsTitle.Text = "Wins:";
            // 
            // label_lossesTitle
            // 
            this.label_lossesTitle.AutoSize = true;
            this.label_lossesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_lossesTitle.Location = new System.Drawing.Point(12, 74);
            this.label_lossesTitle.Name = "label_lossesTitle";
            this.label_lossesTitle.Size = new System.Drawing.Size(64, 20);
            this.label_lossesTitle.TabIndex = 5;
            this.label_lossesTitle.Text = "Losses:";
            // 
            // label_losses
            // 
            this.label_losses.AutoSize = true;
            this.label_losses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_losses.Location = new System.Drawing.Point(82, 74);
            this.label_losses.Name = "label_losses";
            this.label_losses.Size = new System.Drawing.Size(18, 20);
            this.label_losses.TabIndex = 4;
            this.label_losses.Text = "0";
            // 
            // label_nameTitle
            // 
            this.label_nameTitle.AutoSize = true;
            this.label_nameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_nameTitle.Location = new System.Drawing.Point(12, 9);
            this.label_nameTitle.Name = "label_nameTitle";
            this.label_nameTitle.Size = new System.Drawing.Size(55, 20);
            this.label_nameTitle.TabIndex = 1;
            this.label_nameTitle.Text = "Name:";
            // 
            // label_rating
            // 
            this.label_rating.AutoSize = true;
            this.label_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_rating.Location = new System.Drawing.Point(82, 94);
            this.label_rating.Name = "label_rating";
            this.label_rating.Size = new System.Drawing.Size(18, 20);
            this.label_rating.TabIndex = 4;
            this.label_rating.Text = "0";
            // 
            // label_ratingTitle
            // 
            this.label_ratingTitle.AutoSize = true;
            this.label_ratingTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ratingTitle.Location = new System.Drawing.Point(12, 94);
            this.label_ratingTitle.Name = "label_ratingTitle";
            this.label_ratingTitle.Size = new System.Drawing.Size(60, 20);
            this.label_ratingTitle.TabIndex = 5;
            this.label_ratingTitle.Text = "Rating:";
            // 
            // button_Statistics
            // 
            this.button_Statistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Statistics.Location = new System.Drawing.Point(160, 48);
            this.button_Statistics.Name = "button_Statistics";
            this.button_Statistics.Size = new System.Drawing.Size(93, 30);
            this.button_Statistics.TabIndex = 0;
            this.button_Statistics.Text = "Statistics";
            this.button_Statistics.UseVisualStyleBackColor = true;
            // 
            // button_Logout
            // 
            this.button_Logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Logout.Location = new System.Drawing.Point(160, 84);
            this.button_Logout.Name = "button_Logout";
            this.button_Logout.Size = new System.Drawing.Size(93, 30);
            this.button_Logout.TabIndex = 0;
            this.button_Logout.Text = "Logout";
            this.button_Logout.UseVisualStyleBackColor = true;
            this.button_Logout.Click += new System.EventHandler(this.button_Logout_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 135);
            this.Controls.Add(this.label_ratingTitle);
            this.Controls.Add(this.label_rating);
            this.Controls.Add(this.label_lossesTitle);
            this.Controls.Add(this.label_losses);
            this.Controls.Add(this.label_winsTitle);
            this.Controls.Add(this.label_wins);
            this.Controls.Add(this.label_nameTitle);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_Logout);
            this.Controls.Add(this.button_Statistics);
            this.Controls.Add(this.button_FindGame);
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Main_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_FindGame;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_wins;
        private System.Windows.Forms.Label label_winsTitle;
        private System.Windows.Forms.Label label_lossesTitle;
        private System.Windows.Forms.Label label_losses;
        private System.Windows.Forms.Label label_nameTitle;
        private System.Windows.Forms.Label label_rating;
        private System.Windows.Forms.Label label_ratingTitle;
        private System.Windows.Forms.Button button_Statistics;
        private System.Windows.Forms.Button button_Logout;
    }
}