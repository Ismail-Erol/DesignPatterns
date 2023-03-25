using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    // nesneler arası hiyerarşi ve bu nesnelere istediğimiz zaman ulaşabilmek için kullanıyoruz. 
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee{Name = "ismail dildöken"};
            Employee employee2 = new Employee { Name = "Aylin dildöken" };

            employee1.AddSubordinates(employee2);

            Employee employee3 = new Employee { Name = "Büşra dildöken" };
            employee1.AddSubordinates(employee3);

            Contractor contractor1 = new Contractor { Name="Ali dildöken"};
            employee3.AddSubordinates(contractor1);

            Employee employee4 = new Employee { Name = "Aysun dildöken" };
            employee2.AddSubordinates(employee4);

            Console.WriteLine($"{employee1.Name}");
            foreach (Employee manager in employee1)
            {
                Console.WriteLine($"  {manager.Name}");
                foreach (IPerson person in manager)
                {
                    Console.WriteLine($"    {person.Name}");

                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinates(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinates(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinates(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinates in _subordinates)
            {
                yield return subordinates;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


}
