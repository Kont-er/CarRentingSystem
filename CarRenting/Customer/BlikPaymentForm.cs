using System;
using System.Linq;
using System.Windows.Forms;

public class BlikPaymentForm : Form
{
    public bool PaymentSuccessful { get; private set; } = false;

    private Label lblPrompt;
    private TextBox txtBlikCode;
    private Button btnSubmit;

    public BlikPaymentForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.lblPrompt = new Label();
        this.txtBlikCode = new TextBox();
        this.btnSubmit = new Button();

        // Label
        this.lblPrompt.Text = "Enter 6-digit BLIK code:";
        this.lblPrompt.Dock = DockStyle.Top;
        this.lblPrompt.Height = 25;

        // TextBox
        this.txtBlikCode.MaxLength = 6;
        this.txtBlikCode.Dock = DockStyle.Top;
        this.txtBlikCode.Height = 25;

        // Button
        this.btnSubmit.Text = "Submit";
        this.btnSubmit.Dock = DockStyle.Top;
        this.btnSubmit.Height = 30;
        this.btnSubmit.Click += BtnSubmit_Click;

        // Form setup
        this.Controls.Add(this.btnSubmit);
        this.Controls.Add(this.txtBlikCode);
        this.Controls.Add(this.lblPrompt);

        this.Text = "BLIK Payment";
        this.StartPosition = FormStartPosition.CenterParent;
        this.ClientSize = new System.Drawing.Size(250, 100);
    }

    private void BtnSubmit_Click(object sender, EventArgs e)
    {
        string code = txtBlikCode.Text.Trim();

        if (code.Length == 6 && code.All(char.IsDigit))
        {
            PaymentSuccessful = true;
            MessageBox.Show("Payment successful!");
            this.Close();
        }
        else
        {
            MessageBox.Show("Invalid BLIK code. Please enter exactly 6 digits.");
        }
    }
}
