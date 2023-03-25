using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    // bütün bağımlılıkları ortadan kaldırmak gerekir. 
    // bir class çıplak olarak kalmamalıdır. nesnel zafiyetler oluşturabilir. 
    internal class Program
    {
        static void Main(string[] args)
        {
            // IoC Container kullanımı  
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EF_ProductDal>().InSingletonScope();  // biri senden Iproductddl istediğinde EF_Productdal gönder. singleton kullanılabilir. 

            // bu noktada producmanagerda hangi container'ı tercih ettiğimizi set ediyoruz. örn EF_ProductDal gibi. NH da kullanabiliriz. 
            // ProductManager productManager = new ProductManager(new EF_ProductDal());
            // daha doğru yazımı bu şekilde. 

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();

            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    // veri erişim sınıf 
    class EF_ProductDal : IProductDal 
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF ");
        }
    }

    class NH_ProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh ");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;

        // injection yöntemini bu şekilde uyguluyoruz. 
        public ProductManager(IProductDal productdal)
        {
            _productDal = productdal;
        }

        public void Save()
        {
            // iş kodları
            _productDal.Save();
        }
    }
}
