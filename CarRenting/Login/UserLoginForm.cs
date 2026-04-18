using CarRenting;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CarRenting
{
    public partial class UserLoginForm : Form
    {
        public UserLoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string firstName = txtUsername.Text.Trim(); // Using FirstName as username
            string password = txtPassword.Text;

            int userId;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(password))
            {
                // Default login as user with ID 13
                userId = 11;
            }
            else
            {
                userId = AuthenticateCustomer(firstName, password);
                if (userId == -1)
                {
                    MessageBox.Show("Invalid first name or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Temporarily hide this form
            this.Hide();

            // Create and show the UserForm
            UserForm userForm = new UserForm(userId);
            userForm.FormClosed += (s, args) => this.Show(); // Show login form again when UserForm closes
            userForm.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }


        private int AuthenticateCustomer(string firstName, string password)
        {
            using (var conn = new MySqlConnection("server=localhost;uid=root;pwd=root;database=carrentaldb"))
            {
                conn.Open();

                var cmd = new MySqlCommand(
                    "SELECT Id FROM Customers WHERE FirstName = @FirstName AND PasswordHash = @Password",
                    conn
                );
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@Password", password);

                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
    }
}
