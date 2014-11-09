namespace Client
{
    partial class LoginPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_register = new System.Windows.Forms.Button();
            this.button_login = new System.Windows.Forms.Button();
            this.label_passwordTitle = new System.Windows.Forms.Label();
            this.label_nameTitle = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_register
            // 
            this.button_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_register.Location = new System.Drawing.Point(14, 74);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(110, 29);
            this.button_register.TabIndex = 15;
            this.button_register.Text = "Register";
            this.button_register.UseVisualStyleBackColor = true;
            // 
            // button_login
            // 
            this.button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_login.Location = new System.Drawing.Point(130, 74);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(110, 29);
            this.button_login.TabIndex = 16;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            // 
            // label_passwordTitle
            // 
            this.label_passwordTitle.AutoSize = true;
            this.label_passwordTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_passwordTitle.Location = new System.Drawing.Point(14, 45);
            this.label_passwordTitle.Name = "label_passwordTitle";
            this.label_passwordTitle.Size = new System.Drawing.Size(78, 20);
            this.label_passwordTitle.TabIndex = 14;
            this.label_passwordTitle.Text = "Password";
            // 
            // label_nameTitle
            // 
            this.label_nameTitle.AutoSize = true;
            this.label_nameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_nameTitle.Location = new System.Drawing.Point(14, 13);
            this.label_nameTitle.Name = "label_nameTitle";
            this.label_nameTitle.Size = new System.Drawing.Size(51, 20);
            this.label_nameTitle.TabIndex = 13;
            this.label_nameTitle.Text = "Name";
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_password.Location = new System.Drawing.Point(98, 42);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(142, 26);
            this.textBox_password.TabIndex = 12;
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_name.Location = new System.Drawing.Point(98, 10);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(142, 26);
            this.textBox_name.TabIndex = 11;
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_register);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.label_passwordTitle);
            this.Controls.Add(this.label_nameTitle);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_name);
            this.Name = "LoginPage";
            this.Size = new System.Drawing.Size(254, 112);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_register;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label_passwordTitle;
        private System.Windows.Forms.Label label_nameTitle;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_name;

    }
}
