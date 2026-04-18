namespace CarRenting
{
    partial class GalleryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxCarImage;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblImageCounter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBoxCarImage = new System.Windows.Forms.PictureBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblImageCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCarImage
            // 
            this.pictureBoxCarImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxCarImage.Name = "pictureBoxCarImage";
            this.pictureBoxCarImage.Size = new System.Drawing.Size(600, 400);
            this.pictureBoxCarImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCarImage.TabIndex = 0;
            this.pictureBoxCarImage.TabStop = false;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(12, 420);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 30);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "< Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(537, 420);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 30);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblImageCounter
            // 
            this.lblImageCounter.Location = new System.Drawing.Point(270, 420);
            this.lblImageCounter.Name = "lblImageCounter";
            this.lblImageCounter.Size = new System.Drawing.Size(100, 30);
            this.lblImageCounter.TabIndex = 3;
            this.lblImageCounter.Text = "0 / 0";
            this.lblImageCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GalleryForm
            // 
            this.ClientSize = new System.Drawing.Size(624, 461);
            this.Controls.Add(this.lblImageCounter);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.pictureBoxCarImage);
            this.Name = "GalleryForm";
            this.Text = "Car Image Gallery";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarImage)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
