using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculateBase = new Before2010CreditCalculate(); 
            customerManager.SaveCredit();

            customerManager.CreditCalculateBase = new After2010CreditCalculate();
            customerManager.SaveCredit();

            Console.ReadLine();
        }
    }

    abstract class CreditCalculateBase 
    {
        public abstract void CreditCalculate();
    }

    class Before2010CreditCalculate : CreditCalculateBase
    {
        public override void CreditCalculate()
        {
            Console.WriteLine("Credit Calculated Before 2010"); 
        }
    }

    class After2010CreditCalculate : CreditCalculateBase
    {
        public override void CreditCalculate()
        {
            Console.WriteLine("Credit Calculated After 2010");
        }
    }

    // iş katmanında bunu kullandığımızı düşünüyoruz. 

    class CustomerManager
    {
        // burada property yerine injection kullanılabilir. 
        public CreditCalculateBase CreditCalculateBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer Manager Business");
            CreditCalculateBase.CreditCalculate();
        }
    }

}
