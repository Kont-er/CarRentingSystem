using System;
using System.Windows.Forms;

namespace CarRenting
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnAdmin;
        private Button btnUser;
        private Label lblWelcome;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAdmin = new Button();
            this.btnUser = new Button();
            this.lblWelcome = new Label();

            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.Text = "Select Login Type";
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(80, 20);
            this.lblWelcome.Size = new System.Drawing.Size(160, 30);

            // btnAdmin
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.Location = new System.Drawing.Point(90, 70);
            this.btnAdmin.Size = new System.Drawing.Size(140, 40);
            this.btnAdmin.Click += new EventHandler(this.btnAdmin_Click);

            // btnUser
            this.btnUser.Text = "User";
            this.btnUser.Location = new System.Drawing.Point(90, 130);
            this.btnUser.Size = new System.Drawing.Size(140, 40);
            this.btnUser.Click += new EventHandler(this.btnUser_Click);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(320, 200);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnUser);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
        }
    }
}
