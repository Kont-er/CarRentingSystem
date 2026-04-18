using System;
using System.Linq;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CarRentalApp
{
    public partial class CouponForm : Form
    {
        public CouponForm()
        {
            InitializeComponent();
            LoadCoupons();
        }

        private void LoadCoupons()
        {
            var coupons = CouponRepository.GetAllCoupons();
            dgvCoupons.DataSource = coupons.Select(c => new {
                c.Id,
                c.Code,
                c.DiscountPercentage,
                c.ExpiryDate
            }).ToList();
        }
        private void btnSendCouponInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("coupon info sent to those subscribed to the newsletter");
        }

        private void btnAddCoupon_Click(object sender, EventArgs e)
        {
            var coupon = new Coupon
            {
                Code = txtCode.Text,
                DiscountPercentage = int.Parse(txtDiscount.Text),
                ExpiryDate = dtpExpiry.Value.Date
            };
            CouponRepository.AddCoupon(coupon);
            LoadCoupons();
        }

        private void btnDeleteCoupon_Click(object sender, EventArgs e)
        {
            if (dgvCoupons.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvCoupons.SelectedRows[0].Cells["Id"].Value);
            CouponRepository.DeleteCoupon(id);
            LoadCoupons();
        }
    }
}
