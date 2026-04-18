using System;
using System.Windows.Forms;

namespace CarRenting
{
    partial class UserLoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();


            this.SuspendLayout();

            // lblUsername
            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new System.Drawing.Point(20, 20);
            this.lblUsername.Size = new System.Drawing.Size(70, 23);

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(100, 20);
            this.txtUsername.Size = new System.Drawing.Size(180, 23);

            // lblPassword
            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new System.Drawing.Point(20, 60);
            this.lblPassword.Size = new System.Drawing.Size(70, 23);

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(100, 60);
            this.txtPassword.Size = new System.Drawing.Size(180, 23);
            this.txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new System.Drawing.Point(100, 100);
            this.btnLogin.Size = new System.Drawing.Size(80, 30);
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // btnRegister
            this.btnRegister = new Button();
            this.btnRegister.Text = "Register";
            this.btnRegister.Location = new System.Drawing.Point(200, 100);
            this.btnRegister.Size = new System.Drawing.Size(80, 30);
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            // Add to form controls
            this.Controls.Add(this.btnRegister);


            // UserLoginForm
            this.ClientSize = new System.Drawing.Size(320, 150);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "UserLoginForm";
            this.Text = "User Login";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
