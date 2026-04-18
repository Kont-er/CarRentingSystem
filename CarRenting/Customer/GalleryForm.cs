using CarRentalApp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRenting
{
    public partial class GalleryForm : Form
    {
        private List<string> imageUrls = new List<string>();
        private int currentIndex = 0;

        public GalleryForm()
        {
            InitializeComponent();
        }

        public void LoadCarImages(int carId)
        {
            imageUrls.Clear();
            currentIndex = 0;

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT ImageURL FROM CarImages WHERE CarId = @CarId", conn);
                cmd.Parameters.AddWithValue("@CarId", carId);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string url = reader["ImageURL"].ToString();
                    imageUrls.Add(url);
                }
            }

            if (imageUrls.Count > 0)
            {
                ShowImage(0);
            }
            else
            {
                pictureBoxCarImage.Image = null;
                lblImageCounter.Text = "No images";
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
            }
        }

        private void ShowImage(int index)
        {
            if (index < 0 || index >= imageUrls.Count)
                return;

            try
            {
                // Assuming URLs are either file paths or URLs
                var request = System.Net.WebRequest.Create(imageUrls[index]);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBoxCarImage.Image = Bitmap.FromStream(stream);
                }
            }
            catch
            {
                // Fallback if image fails to load
                pictureBoxCarImage.Image = null;
            }

            currentIndex = index;
            lblImageCounter.Text = $"{currentIndex + 1} / {imageUrls.Count}";

            btnPrev.Enabled = currentIndex > 0;
            btnNext.Enabled = currentIndex < imageUrls.Count - 1;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                ShowImage(currentIndex - 1);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < imageUrls.Count - 1)
            {
                ShowImage(currentIndex + 1);
            }
        }
    }
}
