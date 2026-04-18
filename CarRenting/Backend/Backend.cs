using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;

namespace CarRentalApp
{
    public static class Database
    {
        public static string ConnectionString = "server=localhost;uid=root;pwd=root;database=carrentaldb";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }

    // ---------------------- Models ----------------------
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public bool IsAvailable { get; set; }
        public int? CurrentRentalId { get; set; }

    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsRegular { get; set; }
        public int? CurrentRentalId { get; set; }
        public bool IsBanned { get; set; }


    }

    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public class Rental
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } // ENUM: "Pending", "Paid"
    }



    // ---------------------- Rental Repository ----------------------
    public static class RentalRepository
    {

        public static Rental GetRentalById(int rentalId)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Rentals WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", rentalId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Rental
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        CarId = Convert.ToInt32(reader["CarId"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        PaymentStatus = reader["PaymentStatus"].ToString()
                    };
                }

                return null;
            }
        }

        public static void EndRentalForCar(int carId)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                int rentalId = -1;
                int customerId = -1;

                // Get active rental for the car
                using (var cmd = new MySqlCommand(
                    "SELECT Id, CustomerId FROM Rentals WHERE CarId = @CarId AND EndDate >= CURDATE() LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@CarId", carId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return; // No active rental to end

                        rentalId = Convert.ToInt32(reader["Id"]);
                        customerId = Convert.ToInt32(reader["CustomerId"]);
                    }
                }

                // Update StartDate to 1 day ago and EndDate to 2 days ago
                using (var updateRentalCmd = new MySqlCommand(
                    "UPDATE Rentals SET StartDate = DATE_SUB(CURDATE(), INTERVAL 1 DAY), EndDate = DATE_SUB(CURDATE(), INTERVAL 2 DAY) WHERE Id = @Id", conn))
                {
                    updateRentalCmd.Parameters.AddWithValue("@Id", rentalId);
                    updateRentalCmd.ExecuteNonQuery();
                }

                // Clear CurrentRentalId from car and customer
                CarRepository.SetCurrentRental(carId, null);
                CustomerRepository.SetCurrentRental(customerId, null);
            }
        }


    }




    // ---------------------- Car Repository ----------------------
    public static class CarRepository
    {
        public static List<Car> GetAllCars()
        {
            var cars = new List<Car>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT Id, Make, Model, Year, DailyRate, IsAvailable, CurrentRentalId FROM Cars", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cars.Add(new Car
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Make = reader["Make"].ToString(),
                        Model = reader["Model"].ToString(),
                        Year = Convert.ToInt32(reader["Year"]),
                        DailyRate = Convert.ToDecimal(reader["DailyRate"]),
                        IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                        CurrentRentalId = reader["CurrentRentalId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CurrentRentalId"])
                    });
                }
            }
            return cars;
        }

        public static void AddCar(Car car)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO Cars (Make, Model, Year, DailyRate, IsAvailable) VALUES (@Make, @Model, @Year, @Rate, @Available)", conn);
                cmd.Parameters.AddWithValue("@Make", car.Make);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@Rate", car.DailyRate);
                cmd.Parameters.AddWithValue("@Available", car.IsAvailable);
                cmd.ExecuteNonQuery();
            }
        }

        public static void SetCurrentRental(int entityId, int? rentalId)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string table = ""; // "Cars" or "Customers" depending on repository

                if (typeof(CarRepository).Name == System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name)
                    table = "Cars";
                else if (typeof(CustomerRepository).Name == System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name)
                    table = "Customers";

                var cmd = new MySqlCommand(
                    $"UPDATE {table} SET CurrentRentalId = @RentalId WHERE Id = @EntityId", conn);

                cmd.Parameters.AddWithValue("@RentalId", (object)rentalId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EntityId", entityId);

                cmd.ExecuteNonQuery();
            }
        }



        public static void UpdateCar(Car car)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Cars SET Make=@Make, Model=@Model, Year=@Year, DailyRate=@Rate, IsAvailable=@Available, CurrentRentalId=@CurrentRentalId WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Make", car.Make);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@Rate", car.DailyRate);
                cmd.Parameters.AddWithValue("@Available", car.IsAvailable);
                cmd.Parameters.AddWithValue("@Id", car.Id);
                cmd.Parameters.AddWithValue("@CurrentRentalId", (object)car.CurrentRentalId ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteCar(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Cars WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static bool IsCarRented(int carId)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT COUNT(*) FROM Rentals WHERE CarId = @CarId", conn);
                cmd.Parameters.AddWithValue("@CarId", carId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }

    // ---------------------- Customer Repository ----------------------
    public static class CustomerRepository
    {
        public static List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Customers", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        IsRegular = Convert.ToBoolean(reader["IsRegular"]),
                        IsBanned = Convert.ToBoolean(reader["IsBanned"])

                    });
                }
            }
            return customers;
        }

        public static void SetCurrentRental(int customerId, int? rentalId)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Customers SET CurrentRentalId=@RentalId WHERE Id=@CustomerId", conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@RentalId", (object)rentalId ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
        public static void SetCustomerBanStatus(int customerId, bool isBanned)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Customers SET IsBanned=@IsBanned WHERE Id=@CustomerId", conn);
                cmd.Parameters.AddWithValue("@IsBanned", isBanned);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.ExecuteNonQuery();
            }
        }

        public static Car GetCarRentedByCustomer(int customerId)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    @"SELECT c.Id, c.Make, c.Model, c.Year, c.DailyRate, c.IsAvailable, c.CurrentRentalId
              FROM Cars c
              JOIN Rentals r ON c.Id = r.CarId
              WHERE r.CustomerId = @CustomerId AND r.EndDate >= CURDATE()
              LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Car
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Make = reader["Make"].ToString(),
                        Model = reader["Model"].ToString(),
                        Year = Convert.ToInt32(reader["Year"]),
                        DailyRate = Convert.ToDecimal(reader["DailyRate"]),
                        IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                        CurrentRentalId = reader["CurrentRentalId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CurrentRentalId"])
                    };
                }

                return null;
            }
        }

        


        public static void UpdateCustomer(Customer customer)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Customers SET FirstName=@FirstName, LastName=@LastName, Phone=@Phone, IsRegular=@IsRegular WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@IsRegular", customer.IsRegular);
                cmd.Parameters.AddWithValue("@Id", customer.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    // ---------------------- Coupon Repository ----------------------
    public static class CouponRepository
    {
        public static List<Coupon> GetAllCoupons()
        {
            var coupons = new List<Coupon>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Coupons", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    coupons.Add(new Coupon
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Code = reader["Code"].ToString(),
                        DiscountPercentage = Convert.ToInt32(reader["DiscountPercentage"]),
                        ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"])
                    });
                }
            }
            return coupons;
        }

        public static void AddCoupon(Coupon coupon)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO Coupons (Code, DiscountPercentage, ExpiryDate) VALUES (@Code, @Discount, @Expiry)", conn);
                cmd.Parameters.AddWithValue("@Code", coupon.Code);
                cmd.Parameters.AddWithValue("@Discount", coupon.DiscountPercentage);
                cmd.Parameters.AddWithValue("@Expiry", coupon.ExpiryDate);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteCoupon(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Coupons WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    // ---------------------- Rental Service ----------------------
    public static class RentalService
    {
        public static void RentCar(int customerId, int carId, DateTime startDate, DateTime endDate, string paymentMethod, string couponCode = null)
        {
            decimal dailyRate = 0;
            decimal discount = 0;
            decimal total = 0;
            int rentalId = 0;


            using (var conn = Database.GetConnection())
            {
                conn.Open();

                // Get Daily Rate
                var rateCmd = new MySqlCommand("SELECT DailyRate FROM Cars WHERE Id = @CarId", conn);
                rateCmd.Parameters.AddWithValue("@CarId", carId);
                dailyRate = Convert.ToDecimal(rateCmd.ExecuteScalar());

                int days = (endDate - startDate).Days + 1;
                total = dailyRate * days;

                if (!string.IsNullOrEmpty(couponCode))
                {
                    var discountCmd = new MySqlCommand("SELECT DiscountPercentage FROM Coupons WHERE Code=@Code AND ExpiryDate >= CURDATE()", conn);
                    discountCmd.Parameters.AddWithValue("@Code", couponCode);
                    var result = discountCmd.ExecuteScalar();
                    if (result != null)
                    {
                        discount = Convert.ToDecimal(result);
                        total -= total * (discount / 100);
                    }
                }

                // Insert Rental
                var rentalCmd = new MySqlCommand("INSERT INTO Rentals (CustomerId, CarId, StartDate, EndDate, TotalAmount, PaymentStatus) VALUES (@CustomerId, @CarId, @Start, @End, @Total, 'Paid')", conn);
                rentalCmd.Parameters.AddWithValue("@CustomerId", customerId);
                rentalCmd.Parameters.AddWithValue("@CarId", carId);
                rentalCmd.Parameters.AddWithValue("@Start", startDate);
                rentalCmd.Parameters.AddWithValue("@End", endDate);
                rentalCmd.Parameters.AddWithValue("@Total", total);
                rentalCmd.ExecuteNonQuery();
                 rentalId = (int)rentalCmd.LastInsertedId;

                // Insert Payment
                var payCmd = new MySqlCommand("INSERT INTO Payments (RentalId, PaymentDate, Amount, Method, CouponCode) VALUES (@RentalId, NOW(), @Amount, @Method, @Coupon)", conn);
                payCmd.Parameters.AddWithValue("@RentalId", rentalId);
                payCmd.Parameters.AddWithValue("@Amount", total);
                payCmd.Parameters.AddWithValue("@Method", paymentMethod);
                payCmd.Parameters.AddWithValue("@Coupon", (object)couponCode ?? DBNull.Value);
                payCmd.ExecuteNonQuery();

                // Mark car as unavailable
                var updateCarCmd = new MySqlCommand("UPDATE Cars SET IsAvailable = 0 WHERE Id=@CarId", conn);
                updateCarCmd.Parameters.AddWithValue("@CarId", carId);
                updateCarCmd.ExecuteNonQuery();
            }

            // Write Receipt
            string receipt = $"Rental Receipt\nDate: {DateTime.Now}\nCustomer ID: {customerId}\nCar ID: {carId}\nStart: {startDate:d}\nEnd: {endDate:d}\nTotal: ${total:F2}\nPayment Method: {paymentMethod}\nCoupon: {couponCode ?? "None"}";
            File.WriteAllText($"Rental_{carId}_{DateTime.Now:yyyyMMddHHmmss}.txt", receipt);

            // Update CurrentRentalId
            CarRepository.SetCurrentRental(carId, rentalId);
            CustomerRepository.SetCurrentRental(customerId, rentalId);

        }
    }
}
