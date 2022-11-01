using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shop> shops = new List<Shop>();

            var cmd = Console.ReadLine();
            while (cmd != "Revision")
            {
                string[] tokens = cmd.Split(", ");
                var shopName = tokens[0];
                var product = tokens[1];
                var price = double.Parse(tokens[2]);

                var index = shops.FindIndex(x => x.Name == shopName);
                if (index >= 0) shops[index].ProductsPrices.Add(product, price);
                else
                {
                    Shop currentShop = new Shop(shopName, new Dictionary<string, double>());
                    currentShop.ProductsPrices.Add(product, price);
                    shops.Add(currentShop);
                }

                cmd = Console.ReadLine();
            }

            foreach (var x in shops.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{x.Name}->");

                foreach (var item in x.ProductsPrices)
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
            }
        }
    }

    public class Shop
    {
        public Shop(string name, Dictionary<string, double> productsPrices)
        {
            Name = name;
            ProductsPrices = productsPrices;
        }

        public string Name { get; set; }
        public Dictionary<string, double> ProductsPrices { get; set; }
    }
}

