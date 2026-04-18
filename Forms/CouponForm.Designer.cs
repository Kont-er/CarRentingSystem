using System.Windows.Forms;

namespace CarRentalApp
{
    partial class CouponForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCoupons;
        private TextBox txtCode, txtDiscount;
        private DateTimePicker dtpExpiry;
        private Button btnAddCoupon, btnDeleteCoupon;
        private Button btnSendCouponInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCoupons = new System.Windows.Forms.DataGridView();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.btnAddCoupon = new System.Windows.Forms.Button();
            this.btnDeleteCoupon = new System.Windows.Forms.Button();
            this.btnSendCouponInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoupons)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCoupons
            // 
            this.dgvCoupons.ColumnHeadersHeight = 29;
            this.dgvCoupons.Location = new System.Drawing.Point(26, 12);
            this.dgvCoupons.Name = "dgvCoupons";
            this.dgvCoupons.ReadOnly = true;
            this.dgvCoupons.RowHeadersWidth = 51;
            this.dgvCoupons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCoupons.Size = new System.Drawing.Size(454, 180);
            this.dgvCoupons.TabIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(12, 230);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 22);
            this.txtCode.TabIndex = 1;
            this.txtCode.Text = "Code";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(120, 230);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(100, 22);
            this.txtDiscount.TabIndex = 2;
            this.txtDiscount.Text = "Discount %";
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.Location = new System.Drawing.Point(230, 230);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.Size = new System.Drawing.Size(200, 22);
            this.dtpExpiry.TabIndex = 3;
            // 
            // btnAddCoupon
            // 
            this.btnAddCoupon.Location = new System.Drawing.Point(199, 270);
            this.btnAddCoupon.Name = "btnAddCoupon";
            this.btnAddCoupon.Size = new System.Drawing.Size(75, 23);
            this.btnAddCoupon.TabIndex = 4;
            this.btnAddCoupon.Text = "Add";
            // 
            // btnDeleteCoupon
            // 
            this.btnDeleteCoupon.Location = new System.Drawing.Point(280, 270);
            this.btnDeleteCoupon.Name = "btnDeleteCoupon";
            this.btnDeleteCoupon.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCoupon.TabIndex = 5;
            this.btnDeleteCoupon.Text = "Delete";
            // 
            // btnSendCouponInfo
            // 
            this.btnSendCouponInfo.Location = new System.Drawing.Point(355, 270);
            this.btnSendCouponInfo.Name = "btnSendCouponInfo";
            this.btnSendCouponInfo.Size = new System.Drawing.Size(75, 23);
            this.btnSendCouponInfo.TabIndex = 6;
            this.btnSendCouponInfo.Text = "Send Info";
            // 
            // CouponForm
            // 
            this.ClientSize = new System.Drawing.Size(666, 320);
            this.Controls.Add(this.dgvCoupons);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.dtpExpiry);
            this.Controls.Add(this.btnAddCoupon);
            this.Controls.Add(this.btnDeleteCoupon);
            this.Controls.Add(this.btnSendCouponInfo);
            this.Name = "CouponForm";
            this.Text = "Manage Coupons";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoupons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
