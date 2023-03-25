using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factroy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactroy_2());
            customerManager.Save();

            Console.ReadLine();
        }
    }

    public class LoggerFactroy: ILoggerFactory
    {
        public Ilogger CreateLogger()
        {
            // bu kısımda gerekirse bir iş geliştirip duruma göre logger seçeneklerini çoğaltıp seçebiliriz.
            return new IDLogger();
        }
    }

    // yeri geldiğinde başka fabrikalarla da çalışabiliriz. 
    public class LoggerFactroy_2 : ILoggerFactory
    {
        public Ilogger CreateLogger()
        {
            
            return new Log4NetLogger();
        }
    }

    public interface ILoggerFactory
    {
        Ilogger CreateLogger();
    }

    public interface Ilogger
    {
        void Log();
    }

    // burada kendi yazığımız bir logger olabilir. 
    public class IDLogger : Ilogger
    {
        public void Log()
        {
            Console.WriteLine("Log with IDLogger"); 
        }
    }

    public class Log4NetLogger : Ilogger
    {
        public void Log()
        {
            Console.WriteLine("Log with Log4NetLogger");
        }
    }

    // iş sınıfımız 
    public class CustomerManager
    {
        // burada bir inejcition yapıyoruz. 
        // herhangi b,ir factory ye bağımlı kalmadan istediğimizi seçebiliriz. 
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            Ilogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }

}
