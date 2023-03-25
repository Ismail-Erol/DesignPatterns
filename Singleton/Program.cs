using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customermanager = CustomerManager.CreateAsSingleton();
            customermanager.Save();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lock = new object();
        private CustomerManager()
        {
            
        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (_lock)
            {
                if (_customerManager == null)
                {                
                        _customerManager = new CustomerManager();
                }
            }
            return _customerManager;

        }

        public void Save()
        {
            Console.WriteLine("Saved Customer");
        }
    }
}
