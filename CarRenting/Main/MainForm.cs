using System;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); // Load the UI from Designer
        }

        private void btnCars_Click(object sender, EventArgs e)
        {
            // Open Car Management Form
            try
            {
                CarForm carForm = new CarForm();
                carForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open car management. " + ex.Message);
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            // Open Customer Management Form
            try
            {
                CustomerForm customerForm = new CustomerForm();
                customerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open customer management. " + ex.Message);
            }
        }

        private void btnCoupons_Click(object sender, EventArgs e)
        {
            // Open Coupon Management Form
            try
            {
                CouponForm couponForm = new CouponForm();
                couponForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open coupon management. " + ex.Message);
            }
        }
    }
}
