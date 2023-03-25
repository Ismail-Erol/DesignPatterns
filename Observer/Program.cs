using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    // kendisine abone olunan sistemlerin bir işlem olduğunda devreye girmesini sağlayan tasarım desenidir. 
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver); 
            productManager.Attach(new EmployeeObserver());
            productManager.Detach(customerObserver);

            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price Updated");
            Notify(); 
        }

        public void Attach(Observer observer) // abonelik başlatma
        {
            _observers.Add(observer);
        }
        public void Detach(Observer observer) // abonelik bitirme
        {
            _observers.Remove(observer);
        }

        public void Notify() // abonelik Bilgilendirme 
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

    }
    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Customer : Product Price Changed"); 
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Employee : Product Price Changed");
        }
    }
}
