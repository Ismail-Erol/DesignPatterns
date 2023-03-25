using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();

            Console.ReadLine();

        }
    }

    class CustomerManager
    {
       private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4Net : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Lgged with log4Net"); 
        }
    }

    class NLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Lgged with Nlog");

        }
    }

    // ılogger olan ve hiçbirşey yapmayan stublogger sınıfımız. bunu test için kullanacağız. 
    class StubLogger : ILogger
    {
        // singleton oluşturuyoruz. 
        private static StubLogger _stubloger;
        private static object _lock = new object();

        private StubLogger() { }

        // kendini döndüren bir stubloggler oluşturuyoruz. 

        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubloger == null)
                {
                    _stubloger = new StubLogger();
                }
            }
            return _stubloger;  
        }
        public void Log()
        {
            
        }
    }

    // bunun test sınıfı olduğunu düşündüğümüzde bizim yaptığımız testin loglanmması için bir yöntem kullanmamız gerekiyor. 
    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }


}
