﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personalcar = new PersonalCar { Make="BMW", Model="3.20", HirePrice=1500};

            SpecialOffer specialOffer=new SpecialOffer(personalcar);
            specialOffer.DiscountPercentage = 10;
            Console.WriteLine($"concret : {personalcar.HirePrice}");
            Console.WriteLine($"Special Offer : {specialOffer.HirePrice}");

            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommerialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;
        public SpecialOffer(CarBase carBase) : base(carBase) 
        {
            _carBase = carBase;
        }
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice 
        { 
            get { return _carBase.HirePrice - _carBase.HirePrice * DiscountPercentage/100; }
            set { }
        }
    }
}
