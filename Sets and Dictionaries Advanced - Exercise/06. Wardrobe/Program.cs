using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int linesCount = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] curClothesInfo = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string curColor = curClothesInfo[0];
                string[] curClothes = curClothesInfo[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(curColor))
                {
                    wardrobe.Add(curColor, new Dictionary<string, int>());
                }

                for (int clothe = 0; clothe < curClothes.Length; clothe++)
                {
                    if (!wardrobe[curColor].ContainsKey(curClothes[clothe]))
                    {
                        wardrobe[curColor].Add(curClothes[clothe], 0);
                    }
                    wardrobe[curColor][curClothes[clothe]]++;
                }
            }

            string[] searchedClotheInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string searchedColor = searchedClotheInfo[0];
            string searchedClothe = searchedClotheInfo[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothe in color.Value)
                {
                    if (clothe.Key == searchedClothe && color.Key == searchedColor)
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
                    }
                }
            }
        }
    }
}
