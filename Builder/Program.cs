using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine($" " +
                $"{model.Id} " +
                $"{model.CategoryName} " +
                $"{model.ProductName} " +
                $"{model.DiscountedPrice} " +
                $"{model.DiscApplied} " +
                $"{model.UnitPrice} ");

            Console.ReadLine();

        }
    }

    class ProductViewModel 
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscApplied { get; set; }

    }


    // business Sınıfı
    abstract class ProductBuilder
    {
        public abstract void GetProductDate();
        public abstract void AppliedDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model= new ProductViewModel();
        public override void AppliedDiscount()
        {
            model.DiscountedPrice = model.UnitPrice *(decimal)0.90;
            model.DiscApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductDate()
        {
            model.Id = 1;
            model.CategoryName = "Teknoloji";
            model.ProductName = "Laptop";
            model.UnitPrice = 2500;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void AppliedDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductDate()
        {
            model.Id = 1;
            model.CategoryName = "Teknoloji";
            model.ProductName = "Laptop";
            model.UnitPrice = 2500;
        }
    }

     class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductDate();
            productBuilder.AppliedDiscount();
        }
    }

}
