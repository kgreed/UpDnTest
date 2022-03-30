namespace UpDnTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void updnDiscount_ValueChanged(object sender, EventArgs e)
        {
            CalculateSQMRateFromPriceAndSqM();
            CalculatePriceFromRetailAndDiscount();
        }

        private void txtSQMRate_TextChanged(object sender, EventArgs e)
        {
            CalculateDiscountFromPriceAndRetail();
            CalculatePriceFromRetailAndDiscount();
            
        }

        private bool loading;
        private void Form1_Load(object sender, EventArgs e)
        {
            loading = true;
            txtRetailPrice.Text = "100";
            txtArea.Text = "4.00";
            updnDiscount.Value = 10;
            loading = false;

             CalculatePriceFromRetailAndDiscount();
             CalculateSQMRateFromPriceAndSqM();
//            CalculateDiscountFromPriceAndRetail();
        }

        public Decimal RetailPrice => Convert.ToDecimal(txtRetailPrice.Text);
        public Decimal SQM => Convert.ToDecimal(txtArea.Text == "" ? "0" :txtArea.Text );

        public decimal PercentDiscount
        {
            get  =>Convert.ToDecimal(updnDiscount.Value);
            set
            {
                if (loading ) return;
                updnDiscount.Value = value;
            }
        }

        public decimal SQMRate
        {
            get => Convert.ToDecimal(txtSQMRate);
            set
            {
                if (loading) return;
                txtSQMRate.Text = value.ToString();
            }

        }
        public Decimal Result
        {
            get => Convert.ToDecimal( txtResult.Text =="" ? "0": txtResult.Text);
            set
            {
                if (loading) return;
                txtResult.Text = value.ToString();
            }
        }

        private void CalculateDiscountFromPriceAndRetail()
        {
            PercentDiscount = (1 - Result / RetailPrice) * 100;
        }

        private void CalculateSQMRateFromPriceAndSqM()
        {
            SQMRate = (SQM== 0)? 0: Result / SQM;
        }

        private void CalculatePriceFromRetailAndDiscount()
        {
            Result = RetailPrice * (1 - PercentDiscount / 100);
        }

    }
}