using System;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomers();

            // Wire event handlers for selection change and ban button
            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
            btnBanCustomer.Click += BtnBanCustomer_Click;
        }

        private void LoadCustomers()
        {
            var customers = CustomerRepository.GetAllCustomers();

            // Project with an additional IsBanned property (assuming you added it in your DB/model)
            dgvCustomers.DataSource = customers.Select(c => new
            {
                c.Id,
                c.FirstName,
                c.LastName,
                c.Email,
                c.Phone,
                c.IsRegular,
                c.IsBanned // if you added this field
            }).ToList();

            lblRentedCarInfo.Text = ""; // clear rented car info on reload
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);

            var customer = new Customer
            {
                Id = id,
                Phone = txtPhone.Text,
                IsRegular = chkRegular.Checked
            };

            CustomerRepository.UpdateCustomer(customer);
            LoadCustomers();
        }

        private void BtnBanCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);
            CustomerRepository.SetCustomerBanStatus(id, true);
            MessageBox.Show("Customer has been banned.");

            LoadCustomers();
        }

        private void DgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                lblRentedCarInfo.Text = "";
                return;
            }

            int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);
            var rentedCar = CustomerRepository.GetCarRentedByCustomer(id);

            if (rentedCar != null)
            {
                lblRentedCarInfo.Text = $"Rented Car: {rentedCar.Make} {rentedCar.Model} ({rentedCar.Year})";
            }
            else
            {
                lblRentedCarInfo.Text = "No car currently rented.";
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
