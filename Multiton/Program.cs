using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    // belli şarta göre instance üretilir ve şartı sağladığında o instance verilir. 
    internal class Program
    {
        static void Main(string[] args)
        {
            Camera camera1 = Camera.GetCamera("Nikon");
            Camera camera2 = Camera.GetCamera("Nikon");
            Camera camera3 = Camera.GetCamera("canon");
            Camera camera4 = Camera.GetCamera("canon");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);

            Console.ReadLine(); 

        }
    }

    class Camera
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        static object _lock = new object();
        public Guid Id { get; set; }

        private Camera() 
        {
            Id = Guid.NewGuid(); // her instence için bir tane guid oluşturacak. 
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand)) // kameranın içinde bir değer yoksa.
                {
                    _cameras.Add(brand, new Camera()); // ona yeni bir instence ekle. 
                }
            }
            return _cameras[brand];
        }

    }

}
