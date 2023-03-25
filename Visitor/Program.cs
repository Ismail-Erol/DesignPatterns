using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    // ziyaretçi tasarım deseni  
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager { Name="İsmail", Salary=1500};
            Manager manager2 = new Manager { Name = "Aylin", Salary = 1000 };

            Worker worker = new Worker { Name  ="Sude", Salary=800 };   
            Worker worker2 = new Worker { Name = "Gülnaz", Salary=750 };

            manager.Subordinates.Add(manager2);   
            manager2.Subordinates.Add(worker);
            manager2.Subordinates.Add(worker2);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(manager);

            PayRollVisitor payRollVisitor = new PayRollVisitor();   
            PayRiseVisitor payRiseVisitor = new PayRiseVisitor();

            organisationalStructure.Accept(payRollVisitor);
            organisationalStructure.Accept(payRiseVisitor);


            Console.ReadLine();
        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstemployee)
        {
            Employee = firstemployee;
        }

        // ziyaret işlemlerini yapacak nesne
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }

    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    // bütün personel için yapılacak işlemleri canlandırır. 
    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);

    }

    // burada istediğimiz kadar VisitorBase olabilecek iş sınıfı ekleyebiliriz. 
    // bu iş sınıfda maaş ödemesi gibi bir işlem olacak. 
    class PayRollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            // bu alanda iş kodlarının olduğunu düşünmek gerek
            Console.WriteLine($"{worker.Name} paid {worker.Salary}");
        }

        public override void Visit(Manager manager)
        {
            // bu alanda iş kodlarının olduğunu düşünmek gerek
            Console.WriteLine($"{manager.Name} paid {manager.Salary}");
        }
    }

    // burada istediğimiz kadar VisitorBase olabilecek iş sınıfı ekleyebiliriz. 
    // bu iş sınıfda maaş artışı gibi bir işlem olacak. 
    class PayRiseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            // bu alanda iş kodlarının olduğunu düşünmek gerek
            Console.WriteLine($"{worker.Name} Salary increased to {worker.Salary * (decimal) 1.1}");
        }

        public override void Visit(Manager manager)
        {
            // bu alanda iş kodlarının olduğunu düşünmek gerek
            Console.WriteLine($"{manager.Name} Salary increased to {manager.Salary *(decimal) 1.3}");
        }
    }
}
