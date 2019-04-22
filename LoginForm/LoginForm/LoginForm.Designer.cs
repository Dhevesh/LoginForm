namespace LoginForm
{
    partial class Form_Login
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
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.TxtBox_Username = new System.Windows.Forms.TextBox();
            this.TxtBox_Pword = new System.Windows.Forms.TextBox();
            this.Lbl_Username = new System.Windows.Forms.Label();
            this.Lbl_Pword = new System.Windows.Forms.Label();
            this.Lbl_ForgotPassword = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(370, 480);
            this.Btn_Submit.Margin = new System.Windows.Forms.Padding(6);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(150, 44);
            this.Btn_Submit.TabIndex = 2;
            this.Btn_Submit.Text = "Submit";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            // 
            // TxtBox_Username
            // 
            this.TxtBox_Username.Location = new System.Drawing.Point(370, 246);
            this.TxtBox_Username.Margin = new System.Windows.Forms.Padding(6);
            this.TxtBox_Username.Name = "TxtBox_Username";
            this.TxtBox_Username.Size = new System.Drawing.Size(196, 31);
            this.TxtBox_Username.TabIndex = 0;
            // 
            // TxtBox_Pword
            // 
            this.TxtBox_Pword.Location = new System.Drawing.Point(370, 377);
            this.TxtBox_Pword.Margin = new System.Windows.Forms.Padding(6);
            this.TxtBox_Pword.Name = "TxtBox_Pword";
            this.TxtBox_Pword.Size = new System.Drawing.Size(196, 31);
            this.TxtBox_Pword.TabIndex = 1;
            this.TxtBox_Pword.UseSystemPasswordChar = true;
            // 
            // Lbl_Username
            // 
            this.Lbl_Username.AutoSize = true;
            this.Lbl_Username.Location = new System.Drawing.Point(365, 202);
            this.Lbl_Username.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Lbl_Username.Name = "Lbl_Username";
            this.Lbl_Username.Size = new System.Drawing.Size(110, 25);
            this.Lbl_Username.TabIndex = 3;
            this.Lbl_Username.Text = "Username";
            // 
            // Lbl_Pword
            // 
            this.Lbl_Pword.AutoSize = true;
            this.Lbl_Pword.Location = new System.Drawing.Point(365, 334);
            this.Lbl_Pword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Lbl_Pword.Name = "Lbl_Pword";
            this.Lbl_Pword.Size = new System.Drawing.Size(106, 25);
            this.Lbl_Pword.TabIndex = 4;
            this.Lbl_Pword.Text = "Password";
            // 
            // Lbl_ForgotPassword
            // 
            this.Lbl_ForgotPassword.AutoSize = true;
            this.Lbl_ForgotPassword.Location = new System.Drawing.Point(365, 431);
            this.Lbl_ForgotPassword.Name = "Lbl_ForgotPassword";
            this.Lbl_ForgotPassword.Size = new System.Drawing.Size(174, 25);
            this.Lbl_ForgotPassword.TabIndex = 5;
            this.Lbl_ForgotPassword.TabStop = true;
            this.Lbl_ForgotPassword.Text = "Forgot Password";
            // 
            // Form_Login
            // 
            this.AcceptButton = this.Btn_Submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 748);
            this.Controls.Add(this.Lbl_ForgotPassword);
            this.Controls.Add(this.Lbl_Pword);
            this.Controls.Add(this.Lbl_Username);
            this.Controls.Add(this.TxtBox_Pword);
            this.Controls.Add(this.TxtBox_Username);
            this.Controls.Add(this.Btn_Submit);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.TextBox TxtBox_Username;
        private System.Windows.Forms.TextBox TxtBox_Pword;
        private System.Windows.Forms.Label Lbl_Username;
        private System.Windows.Forms.Label Lbl_Pword;
        private System.Windows.Forms.LinkLabel Lbl_ForgotPassword;
    }
}

