using System.Windows.Forms;

namespace CarRentalApp
{
    partial class CarForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCars;
        private TextBox txtMake, txtModel, txtYear, txtRate;
        private Button btnAddCar, btnDeleteCar, btnRecallCar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.btnDeleteCar = new System.Windows.Forms.Button();
            this.btnRecallCar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCars
            // 
            this.dgvCars.ColumnHeadersHeight = 29;
            this.dgvCars.Location = new System.Drawing.Point(12, 12);
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.RowHeadersWidth = 51;
            this.dgvCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCars.Size = new System.Drawing.Size(953, 164);
            this.dgvCars.TabIndex = 0;
            this.dgvCars.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCars_CellContentClick);
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(12, 230);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(100, 22);
            this.txtMake.TabIndex = 1;
            this.txtMake.Text = "Make";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(120, 230);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(100, 22);
            this.txtModel.TabIndex = 2;
            this.txtModel.Text = "Model";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(230, 230);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 22);
            this.txtYear.TabIndex = 3;
            this.txtYear.Text = "Year";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(340, 230);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(100, 22);
            this.txtRate.TabIndex = 4;
            this.txtRate.Text = "Rate";
            // 
            // btnAddCar
            // 
            this.btnAddCar.Location = new System.Drawing.Point(450, 230);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(75, 23);
            this.btnAddCar.TabIndex = 5;
            this.btnAddCar.Text = "Add";
            this.btnAddCar.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // btnDeleteCar
            // 
            this.btnDeleteCar.Location = new System.Drawing.Point(450, 259);
            this.btnDeleteCar.Name = "btnDeleteCar";
            this.btnDeleteCar.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCar.TabIndex = 6;
            this.btnDeleteCar.Text = "Delete";
            this.btnDeleteCar.Click += new System.EventHandler(this.btnDeleteCar_Click);
            // 
            // btnRecallCar
            // 
            this.btnRecallCar.Location = new System.Drawing.Point(450, 288);
            this.btnRecallCar.Name = "btnRecallCar";
            this.btnRecallCar.Size = new System.Drawing.Size(75, 23);
            this.btnRecallCar.TabIndex = 7;
            this.btnRecallCar.Text = "Recall";
            this.btnRecallCar.Click += new System.EventHandler(this.btnRecallCar_Click);
            // 
            // CarForm
            // 
            this.ClientSize = new System.Drawing.Size(977, 343);
            this.Controls.Add(this.dgvCars);
            this.Controls.Add(this.txtMake);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.btnAddCar);
            this.Controls.Add(this.btnDeleteCar);
            this.Controls.Add(this.btnRecallCar);
            this.Name = "CarForm";
            this.Text = "Manage Cars";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
