using System.Windows.Forms;

namespace CarRentalApp
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCustomers;
        private CheckBox chkRegular;
        private Button btnUpdateCustomer;
        private Button btnBanCustomer;
        private Label lblRentedCarInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.chkRegular = new System.Windows.Forms.CheckBox();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnBanCustomer = new System.Windows.Forms.Button();
            this.lblRentedCarInfo = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeight = 29;
            this.dgvCustomers.Location = new System.Drawing.Point(12, 12);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(753, 200);
            this.dgvCustomers.TabIndex = 0;
            // 
            // chkRegular
            // 
            this.chkRegular.AutoSize = true;
            this.chkRegular.Location = new System.Drawing.Point(210, 230);
            this.chkRegular.Name = "chkRegular";
            this.chkRegular.Size = new System.Drawing.Size(90, 20);
            this.chkRegular.TabIndex = 2;
            this.chkRegular.Text = "Is Regular";
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Location = new System.Drawing.Point(320, 230);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCustomer.TabIndex = 3;
            this.btnUpdateCustomer.Text = "Update";
            // 
            // btnBanCustomer
            // 
            this.btnBanCustomer.Location = new System.Drawing.Point(410, 230);
            this.btnBanCustomer.Name = "btnBanCustomer";
            this.btnBanCustomer.Size = new System.Drawing.Size(120, 23);
            this.btnBanCustomer.TabIndex = 4;
            this.btnBanCustomer.Text = "Ban Customer";
            // 
            // lblRentedCarInfo
            // 
            this.lblRentedCarInfo.AutoEllipsis = true;
            this.lblRentedCarInfo.Location = new System.Drawing.Point(12, 265);
            this.lblRentedCarInfo.Name = "lblRentedCarInfo";
            this.lblRentedCarInfo.Size = new System.Drawing.Size(520, 23);
            this.lblRentedCarInfo.TabIndex = 5;
            this.lblRentedCarInfo.Text = "Rented Car Info will appear here";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(12, 230);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(180, 22);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.Text = "New Phone";
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // CustomerForm
            // 
            this.ClientSize = new System.Drawing.Size(870, 300);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.chkRegular);
            this.Controls.Add(this.btnUpdateCustomer);
            this.Controls.Add(this.btnBanCustomer);
            this.Controls.Add(this.lblRentedCarInfo);
            this.Name = "CustomerForm";
            this.Text = "Manage Customers";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox txtPhone;
    }
}
