namespace CarRenting
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnOpenGallery;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.chkIsRegular = new System.Windows.Forms.CheckBox();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.tabAvailableCars = new System.Windows.Forms.TabPage();
            this.dgvAvailableCars = new System.Windows.Forms.DataGridView();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnRentCar = new System.Windows.Forms.Button();
            this.rbCard = new System.Windows.Forms.RadioButton();
            this.rbTransfer = new System.Windows.Forms.RadioButton();
            this.rbBlik = new System.Windows.Forms.RadioButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtCouponCode = new System.Windows.Forms.TextBox();
            this.btnOpenGallery = new System.Windows.Forms.Button();
            this.tabRentalHistory = new System.Windows.Forms.TabPage();
            this.dgvRentalHistory = new System.Windows.Forms.DataGridView();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabAvailableCars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableCars)).BeginInit();
            this.tabRentalHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabProfile);
            this.tabControlMain.Controls.Add(this.tabAvailableCars);
            this.tabControlMain.Controls.Add(this.tabRentalHistory);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(979, 392);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.label2);
            this.tabProfile.Controls.Add(this.label1);
            this.tabProfile.Controls.Add(this.txtFirstName);
            this.tabProfile.Controls.Add(this.txtLastName);
            this.tabProfile.Controls.Add(this.txtEmail);
            this.tabProfile.Controls.Add(this.txtPhone);
            this.tabProfile.Controls.Add(this.chkIsRegular);
            this.tabProfile.Controls.Add(this.btnSaveProfile);
            this.tabProfile.Controls.Add(this.btnChangePassword);
            this.tabProfile.Controls.Add(this.txtNewPassword);
            this.tabProfile.Controls.Add(this.txtConfirmPassword);
            this.tabProfile.Location = new System.Drawing.Point(4, 25);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Size = new System.Drawing.Size(1050, 442);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(20, 30);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 22);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Text = "First Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(20, 70);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 22);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.Text = "Last Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(20, 110);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "Email";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(20, 150);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 22);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Text = "Phone";
            // 
            // chkIsRegular
            // 
            this.chkIsRegular.AutoSize = true;
            this.chkIsRegular.Location = new System.Drawing.Point(20, 190);
            this.chkIsRegular.Name = "chkIsRegular";
            this.chkIsRegular.Size = new System.Drawing.Size(137, 20);
            this.chkIsRegular.TabIndex = 4;
            this.chkIsRegular.Text = "Regular Customer";
            this.chkIsRegular.UseVisualStyleBackColor = true;
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.Location = new System.Drawing.Point(20, 230);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(100, 30);
            this.btnSaveProfile.TabIndex = 5;
            this.btnSaveProfile.Text = "Save Profile";
            this.btnSaveProfile.UseVisualStyleBackColor = true;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(280, 138);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(120, 47);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(250, 50);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(200, 22);
            this.txtNewPassword.TabIndex = 7;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(250, 95);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 22);
            this.txtConfirmPassword.TabIndex = 8;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // tabAvailableCars
            // 
            this.tabAvailableCars.Controls.Add(this.dgvAvailableCars);
            this.tabAvailableCars.Controls.Add(this.dtpStartDate);
            this.tabAvailableCars.Controls.Add(this.dtpEndDate);
            this.tabAvailableCars.Controls.Add(this.btnRentCar);
            this.tabAvailableCars.Controls.Add(this.rbCard);
            this.tabAvailableCars.Controls.Add(this.rbTransfer);
            this.tabAvailableCars.Controls.Add(this.rbBlik);
            this.tabAvailableCars.Controls.Add(this.monthCalendar1);
            this.tabAvailableCars.Controls.Add(this.txtCouponCode);
            this.tabAvailableCars.Controls.Add(this.btnOpenGallery);
            this.tabAvailableCars.Location = new System.Drawing.Point(4, 25);
            this.tabAvailableCars.Name = "tabAvailableCars";
            this.tabAvailableCars.Size = new System.Drawing.Size(971, 363);
            this.tabAvailableCars.TabIndex = 1;
            this.tabAvailableCars.Text = "Available Cars";
            this.tabAvailableCars.UseVisualStyleBackColor = true;
            // 
            // dgvAvailableCars
            // 
            this.dgvAvailableCars.AllowUserToAddRows = false;
            this.dgvAvailableCars.AllowUserToDeleteRows = false;
            this.dgvAvailableCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableCars.Location = new System.Drawing.Point(22, 20);
            this.dgvAvailableCars.MultiSelect = false;
            this.dgvAvailableCars.Name = "dgvAvailableCars";
            this.dgvAvailableCars.ReadOnly = true;
            this.dgvAvailableCars.RowHeadersWidth = 51;
            this.dgvAvailableCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableCars.Size = new System.Drawing.Size(555, 204);
            this.dgvAvailableCars.TabIndex = 0;
            this.dgvAvailableCars.SelectionChanged += new System.EventHandler(this.dgvAvailableCars_SelectionChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(20, 230);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtpStartDate.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(240, 230);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 22);
            this.dtpEndDate.TabIndex = 2;
            // 
            // btnRentCar
            // 
            this.btnRentCar.Location = new System.Drawing.Point(20, 310);
            this.btnRentCar.Name = "btnRentCar";
            this.btnRentCar.Size = new System.Drawing.Size(100, 30);
            this.btnRentCar.TabIndex = 3;
            this.btnRentCar.Text = "Rent Car";
            this.btnRentCar.UseVisualStyleBackColor = true;
            this.btnRentCar.Click += new System.EventHandler(this.btnRentCar_Click);
            // 
            // rbCard
            // 
            this.rbCard.AutoSize = true;
            this.rbCard.Location = new System.Drawing.Point(20, 270);
            this.rbCard.Name = "rbCard";
            this.rbCard.Size = new System.Drawing.Size(57, 20);
            this.rbCard.TabIndex = 4;
            this.rbCard.TabStop = true;
            this.rbCard.Text = "Card";
            this.rbCard.UseVisualStyleBackColor = true;
            // 
            // rbTransfer
            // 
            this.rbTransfer.AutoSize = true;
            this.rbTransfer.Location = new System.Drawing.Point(100, 270);
            this.rbTransfer.Name = "rbTransfer";
            this.rbTransfer.Size = new System.Drawing.Size(78, 20);
            this.rbTransfer.TabIndex = 5;
            this.rbTransfer.TabStop = true;
            this.rbTransfer.Text = "Transfer";
            this.rbTransfer.UseVisualStyleBackColor = true;
            // 
            // rbBlik
            // 
            this.rbBlik.AutoSize = true;
            this.rbBlik.Location = new System.Drawing.Point(200, 270);
            this.rbBlik.Name = "rbBlik";
            this.rbBlik.Size = new System.Drawing.Size(55, 20);
            this.rbBlik.TabIndex = 6;
            this.rbBlik.TabStop = true;
            this.rbBlik.Text = "BLIK";
            this.rbBlik.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(635, 20);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // txtCouponCode
            // 
            this.txtCouponCode.Location = new System.Drawing.Point(261, 268);
            this.txtCouponCode.Name = "txtCouponCode";
            this.txtCouponCode.Size = new System.Drawing.Size(200, 22);
            this.txtCouponCode.TabIndex = 7;
            this.txtCouponCode.Text = "Enter coupon code";
            // 
            // btnOpenGallery
            // 
            this.btnOpenGallery.Location = new System.Drawing.Point(140, 310);
            this.btnOpenGallery.Name = "btnOpenGallery";
            this.btnOpenGallery.Size = new System.Drawing.Size(120, 30);
            this.btnOpenGallery.TabIndex = 8;
            this.btnOpenGallery.Text = "Open Gallery";
            this.btnOpenGallery.UseVisualStyleBackColor = true;
            this.btnOpenGallery.Click += new System.EventHandler(this.btnOpenGallery_Click);
            // 
            // tabRentalHistory
            // 
            this.tabRentalHistory.Controls.Add(this.dgvRentalHistory);
            this.tabRentalHistory.Controls.Add(this.btnExportReport);
            this.tabRentalHistory.Location = new System.Drawing.Point(4, 25);
            this.tabRentalHistory.Name = "tabRentalHistory";
            this.tabRentalHistory.Size = new System.Drawing.Size(971, 363);
            this.tabRentalHistory.TabIndex = 2;
            this.tabRentalHistory.Text = "Rental History";
            this.tabRentalHistory.UseVisualStyleBackColor = true;
            // 
            // dgvRentalHistory
            // 
            this.dgvRentalHistory.AllowUserToAddRows = false;
            this.dgvRentalHistory.AllowUserToDeleteRows = false;
            this.dgvRentalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalHistory.Location = new System.Drawing.Point(20, 20);
            this.dgvRentalHistory.MultiSelect = false;
            this.dgvRentalHistory.Name = "dgvRentalHistory";
            this.dgvRentalHistory.ReadOnly = true;
            this.dgvRentalHistory.RowHeadersWidth = 51;
            this.dgvRentalHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentalHistory.Size = new System.Drawing.Size(753, 233);
            this.dgvRentalHistory.TabIndex = 0;
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(20, 310);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(120, 30);
            this.btnExportReport.TabIndex = 1;
            this.btnExportReport.Text = "Recall early";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "New password:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Confirm password:";
            // 
            // UserForm
            // 
            this.ClientSize = new System.Drawing.Size(979, 392);
            this.Controls.Add(this.tabControlMain);
            this.Name = "UserForm";
            this.Text = "Car Renting Application";
            this.tabControlMain.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            this.tabAvailableCars.ResumeLayout(false);
            this.tabAvailableCars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableCars)).EndInit();
            this.tabRentalHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabAvailableCars;
        private System.Windows.Forms.TabPage tabRentalHistory;

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.CheckBox chkIsRegular;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;

        private System.Windows.Forms.DataGridView dgvAvailableCars;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnRentCar;
        private System.Windows.Forms.RadioButton rbCard;
        private System.Windows.Forms.RadioButton rbTransfer;
        private System.Windows.Forms.RadioButton rbBlik;
        private System.Windows.Forms.TextBox txtCouponCode;

        private System.Windows.Forms.DataGridView dgvRentalHistory;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

