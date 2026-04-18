using CarRentalApp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CarRenting
{
    public partial class UserForm : Form
    {
        private int userId;

        public UserForm(int userId)
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in InitializeComponent(): " + ex.Message);
                return;
            }
            this.userId = userId;
            LoadUserProfile();
            LoadAvailableCars();
            LoadRentalHistory();
        }

        private void LoadUserProfile()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT FirstName, LastName, Email, Phone, IsRegular FROM Customers WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtFirstName.Text = reader.GetString("FirstName");
                        txtLastName.Text = reader.GetString("LastName");
                        txtEmail.Text = reader.GetString("Email");
                        txtPhone.Text = reader.GetString("Phone");
                        chkIsRegular.Checked = reader.GetBoolean("IsRegular");
                    }
                }
            }
        }

        private void dgvAvailableCars_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAvailableCars.SelectedRows.Count == 0) return;
            int carId = Convert.ToInt32(dgvAvailableCars.SelectedRows[0].Cells["Id"].Value);
            ShowCarAvailability(carId);
        }

        private void ShowCarAvailability(int carId)
        {
            var busyDates = new List<DateTime>();

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(@"
                    SELECT StartDate, EndDate 
                    FROM Rentals
                    WHERE CarId = @CarId AND EndDate >= CURDATE()", conn);
                cmd.Parameters.AddWithValue("@CarId", carId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime start = reader.GetDateTime("StartDate");
                        DateTime end = reader.GetDateTime("EndDate");

                        for (DateTime d = start; d <= end; d = d.AddDays(1))
                        {
                            busyDates.Add(d);
                        }
                    }
                }
            }

            monthCalendar1.BoldedDates = busyDates.ToArray();
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(@"UPDATE Customers 
                    SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, IsRegular = @IsRegular 
                    WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@IsRegular", chkIsRegular.Checked);
                cmd.Parameters.AddWithValue("@Id", userId);

                int rows = cmd.ExecuteNonQuery();

                MessageBox.Show(rows > 0 ? "Profile updated successfully!" : "Update failed.");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Customers SET Password = SHA2(@Password, 256) WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@Id", userId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Password updated successfully.");
        }




        private void LoadAvailableCars()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT Id, Make, Model, Year, DailyRate, IsAvailable FROM Cars ORDER BY IsAvailable DESC, Make, Model";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvAvailableCars.DataSource = dt;
                dgvAvailableCars.Columns["Id"].Visible = false;
            }
        }

        private void LoadRentalHistory()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    Rentals.Id, 
                    Cars.Make AS 'Car Make', 
                    Cars.Model AS 'Car Model', 
                    Rentals.StartDate AS 'Start Date', 
                    Rentals.EndDate AS 'End Date', 
                    Rentals.PaymentStatus AS 'Payment Status', 
                    Rentals.TotalAmount AS 'Total Paid',
                    -- Computed column for currently renting
                    CASE 
                        WHEN (Rentals.EndDate IS NULL OR Rentals.EndDate > CURDATE()) THEN TRUE 
                        ELSE FALSE 
                    END AS 'Currently Renting'
                FROM Rentals 
                JOIN Cars ON Rentals.CarId = Cars.Id 
                WHERE Rentals.CustomerId = @UserId
                ORDER BY Rentals.StartDate DESC";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    var adapter = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dgvRentalHistory.DataSource = dt;

                    if (dgvRentalHistory.Columns.Contains("Id"))
                        dgvRentalHistory.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load rental history: " + ex.Message);
            }
        }



        private void btnRentCar_Click(object sender, EventArgs e)
        {
            if (dgvAvailableCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car to rent.");
                return;
            }

            int carId = Convert.ToInt32(dgvAvailableCars.SelectedRows[0].Cells["Id"].Value);
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (startDate >= endDate)
            {
                MessageBox.Show("End date must be after start date.");
                return;
            }

            if (!IsCarAvailable(carId, startDate, endDate))
            {
                MessageBox.Show("Selected car is not available for the chosen dates.");
                return;
            }

            string paymentMethod = rbBlik.Checked ? "BLIK" : "";

            if (paymentMethod == "")
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            // Calculate price before payment form
            string couponCode = txtCouponCode.Text;

            decimal finalPrice = CalculatePriceWithCoupon(carId, startDate, endDate, couponCode);

            DialogResult confirm = MessageBox.Show($"Total cost including 100 PLN collateral: {finalPrice:F2} PLN. Proceed?",
                                         "Confirm Rental", MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
                return;


            if (paymentMethod == "BLIK")
            {
                var blikForm = new BlikPaymentForm();
                blikForm.ShowDialog();
                if (!blikForm.PaymentSuccessful)
                    return;
            }

            try
            {
                RentalService.RentCar(userId, carId, startDate, endDate, paymentMethod, couponCode);
                MessageBox.Show("Rental successful!");
                LoadRentalHistory();
                LoadAvailableCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rental failed: {ex.Message}");
            }
        }


        private bool IsCarAvailable(int carId, DateTime startDate, DateTime endDate)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(@"
                    SELECT COUNT(*) FROM Rentals
                    WHERE CarId = @CarId
                    AND ((@StartDate BETWEEN StartDate AND EndDate)
                      OR (@EndDate BETWEEN StartDate AND EndDate)
                      OR (StartDate BETWEEN @StartDate AND @EndDate))", conn);

                cmd.Parameters.AddWithValue("@CarId", carId);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
            }
        }

        private decimal GetCarPricePerDay(int carId)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT DailyRate FROM Cars WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", carId);
                object val = cmd.ExecuteScalar();
                return val == null ? 0 : Convert.ToDecimal(val);
            }
        }

        private decimal CalculatePriceWithCoupon(int carId, DateTime startDate, DateTime endDate, string couponCode)
        {
            decimal dailyRate = GetCarPricePerDay(carId);
            int rentalDays = (endDate - startDate).Days;
            decimal basePrice = dailyRate * rentalDays;

            decimal discountPercentage = 0;

            if (!string.IsNullOrWhiteSpace(couponCode))
            {
                // Query coupon from DB
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT DiscountPercentage, ExpiryDate FROM Coupons WHERE Code = @Code LIMIT 1";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", couponCode.Trim());
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var expiryDate = reader.GetDateTime("ExpiryDate");
                                if (expiryDate >= DateTime.Today)
                                {
                                    discountPercentage = reader.GetInt32("DiscountPercentage");
                                }
                                else
                                {
                                    MessageBox.Show("Coupon code expired.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid coupon code.");
                            }
                        }
                    }
                }
            }

            // Apply discount to base price
            decimal discountedPrice = basePrice * (1 - discountPercentage / 100m);

            // Add fixed collateral of 100 PLN
            decimal finalPrice = discountedPrice + 100;

            return finalPrice;
        }


        private void btnExportReport_Click(object sender, EventArgs e)
        {
            if (dgvRentalHistory.SelectedRows.Count == 0) return;

            // Step 1: Get Rental ID from selected row
            int rentalId = Convert.ToInt32(dgvRentalHistory.SelectedRows[0].Cells["Id"].Value);

            // Step 2: Get the rental from the repository
            var rental = RentalRepository.GetRentalById(rentalId);
            if (rental == null)
            {
                MessageBox.Show("Rental not found.");
                return;
            }

            // Step 3: Get the car using CarId
            var car = CarRepository.GetAllCars().FirstOrDefault(c => c.Id == rental.CarId);
            if (car == null)
            {
                MessageBox.Show("Associated car not found.");
                return;
            }

            // Step 4: Only recall if the car is currently rented
            if (!car.IsAvailable)
            {
                car.IsAvailable = true;
                car.CurrentRentalId = null;
                CarRepository.UpdateCar(car);

                RentalRepository.EndRentalForCar(car.Id);

                MessageBox.Show("Car has been recalled and marked as available.");

                LoadAvailableCars();
                LoadRentalHistory();
            }
            else
            {
                MessageBox.Show("This car is already marked as available.");
            }
        }

        private void btnOpenGallery_Click(object sender, EventArgs e)
        {
            int carId = Convert.ToInt32(dgvAvailableCars.SelectedRows[0].Cells["Id"].Value);

            GalleryForm galleryForm = new GalleryForm();
            var gallery = new GalleryForm();
            gallery.LoadCarImages(carId); //7 = carid
            gallery.Show();

          
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
