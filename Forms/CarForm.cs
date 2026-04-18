using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CarRentalApp
{
    public partial class CarForm : Form
    {
        public CarForm()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            var cars = CarRepository.GetAllCars();
            var customers = CustomerRepository.GetAllCustomers();

            var carData = from c in cars
                          let rentalId = c.CurrentRentalId
                          let rental = rentalId != null ? RentalRepository.GetRentalById(rentalId.Value) : null
                          let customer = rental != null ? customers.FirstOrDefault(cust => cust.Id == rental.CustomerId) : null
                          select new
                          {
                              c.Id,
                              c.Make,
                              c.Model,
                              c.Year,
                              c.DailyRate,
                              c.IsAvailable,
                              RentedBy = customer != null ? $"{customer.FirstName} {customer.LastName}" : "Available"
                          };

            dgvCars.Columns.Clear();
            dgvCars.DataSource = carData.ToList();

            var unavailableCol = new DataGridViewCheckBoxColumn
            {
                Name = "SetUnavailable",
                HeaderText = "Set Unavailable",
                FalseValue = false,
                TrueValue = true
            };
            dgvCars.Columns.Add(unavailableCol);

            var availableCol = new DataGridViewCheckBoxColumn
            {
                Name = "SetAvailable",
                HeaderText = "Set Available",
                FalseValue = false,
                TrueValue = true
            };
            dgvCars.Columns.Add(availableCol);
        }


        private void btnAddCar_Click(object sender, EventArgs e)
        {
            var car = new Car
            {
                Make = txtMake.Text,
                Model = txtModel.Text,
                Year = int.Parse(txtYear.Text),
                DailyRate = decimal.Parse(txtRate.Text),
                IsAvailable = true
            };
            CarRepository.AddCar(car);
            LoadCars();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvCars.SelectedRows[0].Cells["Id"].Value);
            CarRepository.DeleteCar(id);
            LoadCars();
        }

        private void btnRecallCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0) return;
            int carId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells["Id"].Value);

            var car = CarRepository.GetAllCars().FirstOrDefault(c => c.Id == carId);
            if (car != null && !car.IsAvailable)
            {
                car.IsAvailable = true;
                car.CurrentRentalId = null;
                CarRepository.UpdateCar(car);

                RentalRepository.EndRentalForCar(carId);

                MessageBox.Show("Car has been recalled and marked as available.");
                LoadCars();
            }
        }


        private void dgvCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int carId = Convert.ToInt32(dgvCars.Rows[e.RowIndex].Cells["Id"].Value);
            var car = CarRepository.GetAllCars().FirstOrDefault(c => c.Id == carId);
            if (car == null) return;

            string colName = dgvCars.Columns[e.ColumnIndex].Name;

            if (colName == "SetUnavailable" && car.IsAvailable)
            {
                car.IsAvailable = false;
                CarRepository.UpdateCar(car);
                MessageBox.Show("Car marked as unavailable.");
                LoadCars();
            }
            else if (colName == "SetAvailable" && !car.IsAvailable)
            {
                car.IsAvailable = true;
                car.CurrentRentalId = null;
                CarRepository.UpdateCar(car);
                RentalRepository.EndRentalForCar(car.Id);
                MessageBox.Show("Car marked as available.");
                LoadCars();
            }

        }
    }
}
