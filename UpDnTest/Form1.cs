namespace UpDnTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool loading;
        private bool changingDiscount;
        private void updnDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (loading) return;
            changingDiscount = true;
            CalculatePriceFromRetailAndDiscount( updnDiscount.CurrentEditValue);
            CalculateSQMRateFromPriceAndSqM();
            changingDiscount = false;
          
            
        }

        private void txtSQMRate_TextChanged(object sender, EventArgs e)
        {
           CalculateDiscountFromPriceAndRetail();
           CalculatePriceFromRetailAndDiscount(updnDiscount.CurrentEditValue);
            
        }
      
       
        private void Form1_Load(object sender, EventArgs e)
        {
            loading = true;
            txtRetailPrice.Text = "100";
            txtArea.Text = "4.00";
            updnDiscount.Value = 10;
            loading = false;

            CalculatePriceFromRetailAndDiscount(updnDiscount.Value);
            CalculateSQMRateFromPriceAndSqM();
//            CalculateDiscountFromPriceAndRetail();
        }

        public Decimal RetailPrice => Convert.ToDecimal((txtRetailPrice.Text=="" ? "0" : txtRetailPrice.Text));
        public Decimal SQM => Convert.ToDecimal(txtArea.Text == "" ? "0" :txtArea.Text );

        

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
            if (changingDiscount)  return; // setting control while it is being edited leads to user frustration.
           
            updnDiscount.Value = (RetailPrice == 0)? 0: (1 - Result / RetailPrice) * 100;
            
        }

        private void CalculateSQMRateFromPriceAndSqM()
        {
            SQMRate = (SQM== 0)? 0: Result / SQM;
        }

        private void CalculatePriceFromRetailAndDiscount(decimal discountPercent)
        {
            Result = RetailPrice * (1 - discountPercent / 100);
        }

    }
}