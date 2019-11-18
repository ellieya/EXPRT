using System;
namespace EPRT
{
    public class HR : Person
    {
        decimal dollarLimit;


        public HR(string fn, string ln, string em, string d, decimal dLim) : base(fn, ln, em, d)
        {
            dollarLimit = dLim;
        }

        public decimal NumEmps
        {
            get { return dollarLimit; }
            set { dollarLimit = value; }
        }

    }
}
