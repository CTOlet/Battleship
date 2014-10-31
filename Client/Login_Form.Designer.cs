namespace Client
{
    partial class Login_Form
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
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.button_Register = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Name.Location = new System.Drawing.Point(96, 14);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(142, 26);
            this.textBox_Name.TabIndex = 0;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Password.Location = new System.Drawing.Point(96, 46);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(142, 26);
            this.textBox_Password.TabIndex = 1;
            this.textBox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Password_KeyDown);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Name.Location = new System.Drawing.Point(12, 17);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(51, 20);
            this.label_Name.TabIndex = 2;
            this.label_Name.Text = "Name";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Password.Location = new System.Drawing.Point(12, 49);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(78, 20);
            this.label_Password.TabIndex = 3;
            this.label_Password.Text = "Password";
            // 
            // button_Login
            // 
            this.button_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Login.Location = new System.Drawing.Point(128, 78);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(110, 29);
            this.button_Login.TabIndex = 4;
            this.button_Login.Text = "Login";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // button_Register
            // 
            this.button_Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Register.Location = new System.Drawing.Point(12, 78);
            this.button_Register.Name = "button_Register";
            this.button_Register.Size = new System.Drawing.Size(110, 29);
            this.button_Register.TabIndex = 4;
            this.button_Register.Text = "Register";
            this.button_Register.UseVisualStyleBackColor = true;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 118);
            this.Controls.Add(this.button_Register);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_Name);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Button button_Register;
    }
}