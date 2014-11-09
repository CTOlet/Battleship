namespace Client
{
    partial class Game_Form
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
            this.label_OwnNameTitle = new System.Windows.Forms.Label();
            this.label_OwnName = new System.Windows.Forms.Label();
            this.label_OpponentNameTitle = new System.Windows.Forms.Label();
            this.label_OpponentName = new System.Windows.Forms.Label();
            this.panel_Own = new System.Windows.Forms.Panel();
            this.panel_Opponent = new System.Windows.Forms.Panel();
            this.label_Status = new System.Windows.Forms.Label();
            this.button_LeaveGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_OwnNameTitle
            // 
            this.label_OwnNameTitle.AutoSize = true;
            this.label_OwnNameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_OwnNameTitle.Location = new System.Drawing.Point(12, 9);
            this.label_OwnNameTitle.Name = "label_OwnNameTitle";
            this.label_OwnNameTitle.Size = new System.Drawing.Size(42, 20);
            this.label_OwnNameTitle.TabIndex = 0;
            this.label_OwnNameTitle.Text = "You:";
            // 
            // label_OwnName
            // 
            this.label_OwnName.AutoSize = true;
            this.label_OwnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_OwnName.Location = new System.Drawing.Point(60, 9);
            this.label_OwnName.Name = "label_OwnName";
            this.label_OwnName.Size = new System.Drawing.Size(49, 20);
            this.label_OwnName.TabIndex = 0;
            this.label_OwnName.Text = "name";
            // 
            // label_OpponentNameTitle
            // 
            this.label_OpponentNameTitle.AutoSize = true;
            this.label_OpponentNameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_OpponentNameTitle.Location = new System.Drawing.Point(322, 9);
            this.label_OpponentNameTitle.Name = "label_OpponentNameTitle";
            this.label_OpponentNameTitle.Size = new System.Drawing.Size(84, 20);
            this.label_OpponentNameTitle.TabIndex = 0;
            this.label_OpponentNameTitle.Text = "Opponent:";
            // 
            // label_OpponentName
            // 
            this.label_OpponentName.AutoSize = true;
            this.label_OpponentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_OpponentName.Location = new System.Drawing.Point(412, 9);
            this.label_OpponentName.Name = "label_OpponentName";
            this.label_OpponentName.Size = new System.Drawing.Size(49, 20);
            this.label_OpponentName.TabIndex = 0;
            this.label_OpponentName.Text = "name";
            // 
            // panel_Own
            // 
            this.panel_Own.Location = new System.Drawing.Point(12, 32);
            this.panel_Own.Name = "panel_Own";
            this.panel_Own.Size = new System.Drawing.Size(300, 300);
            this.panel_Own.TabIndex = 1;
            // 
            // panel_Opponent
            // 
            this.panel_Opponent.Location = new System.Drawing.Point(322, 32);
            this.panel_Opponent.Name = "panel_Opponent";
            this.panel_Opponent.Size = new System.Drawing.Size(300, 300);
            this.panel_Opponent.TabIndex = 1;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Status.Location = new System.Drawing.Point(12, 343);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(56, 20);
            this.label_Status.TabIndex = 0;
            this.label_Status.Text = "Status";
            // 
            // button_LeaveGame
            // 
            this.button_LeaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_LeaveGame.Location = new System.Drawing.Point(514, 338);
            this.button_LeaveGame.Name = "button_LeaveGame";
            this.button_LeaveGame.Size = new System.Drawing.Size(108, 30);
            this.button_LeaveGame.TabIndex = 2;
            this.button_LeaveGame.Text = "Leave game";
            this.button_LeaveGame.UseVisualStyleBackColor = true;
            // 
            // Game_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 375);
            this.Controls.Add(this.button_LeaveGame);
            this.Controls.Add(this.panel_Opponent);
            this.Controls.Add(this.panel_Own);
            this.Controls.Add(this.label_OpponentName);
            this.Controls.Add(this.label_OpponentNameTitle);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.label_OwnName);
            this.Controls.Add(this.label_OwnNameTitle);
            this.Name = "Game_Form";
            this.Text = "Battleship";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_Form_FormClosing);
            this.Load += new System.EventHandler(this.Game_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_OwnNameTitle;
        private System.Windows.Forms.Label label_OwnName;
        private System.Windows.Forms.Label label_OpponentNameTitle;
        private System.Windows.Forms.Label label_OpponentName;
        private System.Windows.Forms.Panel panel_Own;
        private System.Windows.Forms.Panel panel_Opponent;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Button button_LeaveGame;
    }
}