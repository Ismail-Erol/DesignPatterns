using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    // amaç nesne üretme malityetlerini minimize etmek. 
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { City="Muğla" , FirtsName="ismail", LastName="Dildöken", Id = 1};

            // burada yeni nesne oluşturma maliyetinden kzanmış oluyoruz. 
            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirtsName = "Aysun";

            Console.WriteLine(customer1.FirtsName);
            Console.WriteLine(customer2.FirtsName);
            Console.ReadLine();

        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }
    }


    public class Customer : Person 
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; } 
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
