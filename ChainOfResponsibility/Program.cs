using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();    
            VicePresident vicePresident = new VicePresident();  
            President president = new President();

            manager.SetSuccessor(vicePresident);  // yöneticinin üstü başkan yardımcısı 
            vicePresident.SetSuccessor(president);  // başkan yardımcısının üstü başkan şeklinde bir tanımlama. 

            Expense expense = new Expense() { Detail="Training", Amount=110}; // harcamam tanımlama. 
            manager.HandlerExpense(expense); // harcamayı manager'a gönderiyoruz. 

            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandlerExpense(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase successor) // üst olarak gönderilecek successor 
        {
            Successor = successor;
        }
    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandlerExpense(Expense expense)
        {
           if (expense.Amount <= 100)
            {
                Console.WriteLine("Manager handled the expense");
            }
           else if (Successor != null) 
            {
                Successor.HandlerExpense(expense); 
            }
        }
    }
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandlerExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount <= 1000)
            {
                Console.WriteLine("Vice President handled the expense");
            }
            else if (Successor != null)
            {
                Successor.HandlerExpense(expense);
            }
        }
    }

    class President : ExpenseHandlerBase
    {
        public override void HandlerExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense");
            }
        }
    }

}
