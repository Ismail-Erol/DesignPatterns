﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    // basit sipariş takip örneği üzerinde göreceğiz. 
    // 
    internal class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockController stockController = new StockController();
            stockController.TakeOrder(buyStock); // stoktan birşey almak istiyoruz. 
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);

            stockController.PlaceOrder();

            Console.ReadLine();
        }
    }

    class StockManager 
    {
        // veritabanından ürün çekilmiş gibi düşün.
        private string _name = "laptop";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine($"Stock : {_name}, {_quantity} bought!");
        }

        public void Sell()
        {
            Console.WriteLine($"Stock : {_name}, {_quantity} sold!");
        }

    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        private StockManager _stockManager;

        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
           _stockManager.Buy();
        }
    }

    class SellStock : IOrder
    {
        private StockManager _stockManager;

        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)  // burada bir sipariş nesnesi gönderiyoruz. buradaki işlem alma yada satma işlemi olabilir. 
        {
            _orders.Add(order);
        }

        public void PlaceOrder()
        {
            foreach (IOrder order in _orders)
            {
                order.Execute();
            }

            _orders.Clear();
        }
    }

}
