namespace CarRentalApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnCars;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnCoupons;
        private System.Windows.Forms.Label lblTitle;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCars = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnCoupons = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCars
            // 
            this.btnCars.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCars.Location = new System.Drawing.Point(118, 64);
            this.btnCars.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCars.Name = "btnCars";
            this.btnCars.Size = new System.Drawing.Size(205, 44);
            this.btnCars.TabIndex = 1;
            this.btnCars.Text = "Manage Cars";
            this.btnCars.UseVisualStyleBackColor = true;
            this.btnCars.Click += new System.EventHandler(this.btnCars_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCustomers.Location = new System.Drawing.Point(118, 112);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(205, 43);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Manage Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnCoupons
            // 
            this.btnCoupons.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCoupons.Location = new System.Drawing.Point(118, 159);
            this.btnCoupons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCoupons.Name = "btnCoupons";
            this.btnCoupons.Size = new System.Drawing.Size(205, 40);
            this.btnCoupons.TabIndex = 3;
            this.btnCoupons.Text = "Manage Coupons";
            this.btnCoupons.UseVisualStyleBackColor = true;
            this.btnCoupons.Click += new System.EventHandler(this.btnCoupons_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(68, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(297, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Car Rental Manager";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 266);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCars);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnCoupons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Car Rental Admin Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
