using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    // bir nesnenin içerisinde soyutlanabilir kısımlar varsa onları soyutlamak üzerine çalışır. 
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new EMailSender();
            customerManager.CustomerUpdate();

            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase
    { 
        public  void Save()
        {
            Console.WriteLine("Message Saved");
        }

        public abstract void Send(Body body);
    }

     class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class EMailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"{body.Title} was send via EmailSender");
        }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"{body.Title} was send via SMSSender");

        }
    }


    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }
        public void CustomerUpdate()
        {
            Console.WriteLine("Customer Upated");
            MessageSenderBase.Send(new Body() { Title="About the course"});

        }
    }

}
