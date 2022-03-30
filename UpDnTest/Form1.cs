namespace UpDnTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool loading;
       
        private void updnDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (changingSQMRate) return;
            changingDiscountPercent = true;
            CalculatePriceFromRetailAndDiscount( );
            CalculateSQMRateFromPriceAndSqM();
            changingDiscountPercent = false;
          
            
        }
        bool changingDiscountPercent;
        bool changingSQMRate = true;
        private void txtSQMRate_TextChanged(object sender, EventArgs e)
        { if (loading) return;
        
           if (changingDiscountPercent) return;
           changingSQMRate = true;
           CalculatePriceFromSQMRateAndSQM();
           CalculateDiscountFromPriceAndRetail( );
           changingSQMRate = false;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            loading = true;
            txtRetailPrice.Text = "100";
            txtArea.Text = "4.00";
            updnDiscount.Value = 10;
            loading = false;

            CalculatePriceFromRetailAndDiscount();
            CalculateSQMRateFromPriceAndSqM();
 
        }

        public Decimal RetailPrice => Convert.ToDecimal((txtRetailPrice.Text=="" ? "0" : txtRetailPrice.Text));
        public Decimal SQM => Convert.ToDecimal(txtArea.Text == "" ? "0" :txtArea.Text );

        

        public decimal SQMRate
        {
            get => Convert.ToDecimal(txtSQMRate.Text);
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
           
           
            updnDiscount.Value = (RetailPrice == 0)? 0: (1 - Result / RetailPrice) * 100;
            
        }
        private void CalculatePriceFromSQMRateAndSQM()
        {
            Result = SQM * SQMRate;
        }
        private void CalculateSQMRateFromPriceAndSqM()
        {
            SQMRate = (SQM== 0)? 0: Result / SQM;
        }

        private void CalculatePriceFromRetailAndDiscount()
        {
            Result = RetailPrice * (1 - updnDiscount.CurrentEditValue / 100);
        }
        private void CalculateDisc()
        {
            Result = RetailPrice * (1 - updnDiscount.CurrentEditValue / 100);
        }
    }
}