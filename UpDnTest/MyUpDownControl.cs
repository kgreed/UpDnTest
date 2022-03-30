using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpDnTest
{
    //https://stackoverflow.com/questions/71674248/numericupdown-valuechanged-event-not-firing-when-number-is-typed/71681092#71681092
    public class NumericUpDownEx : NumericUpDown
    {

        public NumericUpDownEx() { }

        public virtual decimal CurrentEditValue { get; internal set; } = 0M;

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            // Use CurrentCulture as IFormatProvider
            if (decimal.TryParse(Text, out decimal v))
            {
                CurrentEditValue = v;
                OnValueChanged(e);
            }
        }

        protected override void OnValueChanged(EventArgs e)
        {
            Console.WriteLine($"OnValueChanged: CurrentEditValue={CurrentEditValue}");
            base.OnValueChanged(e);
        }
    }
}
