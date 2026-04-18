using CarRentalApp;
//using CarRenting.Login;
using System;
using System.Windows.Forms;

namespace CarRenting
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide(); // Temporarily hide LoginForm
            var mainForm = new MainForm();

            // When MainForm is closed, show LoginForm again
            mainForm.FormClosed += (s, args) => this.Show();
            mainForm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            this.Hide(); // Temporarily hide LoginForm
            var userLogin = new UserLoginForm();

            // When UserLoginForm is closed, show LoginForm again
            userLogin.FormClosed += (s, args) => this.Show();
            userLogin.Show();
        }

    }
}
