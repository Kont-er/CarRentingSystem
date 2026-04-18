using System.Windows.Forms;

namespace CarRenting
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtFirstName, txtLastName, txtEmail, txtPassword, txtPhone;
        private Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFirstName = new TextBox { Text = "First Name", Location = new System.Drawing.Point(20, 20), Width = 200 };
            this.txtLastName = new TextBox { Text = "Last Name", Location = new System.Drawing.Point(20, 60), Width = 200 };
            this.txtEmail = new TextBox { Text = "Email", Location = new System.Drawing.Point(20, 100), Width = 200 };
            this.txtPhone = new TextBox { Text = "Phone", Location = new System.Drawing.Point(20, 140), Width = 200 };
            this.txtPassword = new TextBox { Text = "Password", Location = new System.Drawing.Point(20, 180), Width = 200, UseSystemPasswordChar = true };

            this.btnRegister = new Button
            {
                Text = "Register",
                Location = new System.Drawing.Point(70, 230),
                Size = new System.Drawing.Size(100, 30)
            };
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.ClientSize = new System.Drawing.Size(250, 280);
            this.Controls.AddRange(new Control[] { txtFirstName, txtLastName, txtEmail, txtPhone, txtPassword, btnRegister });
            this.Text = "Register";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}
