using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hashCode = Console.ReadLine();
            HashSet<string> people = new HashSet<string>();
            HashSet<string> toBePrinted = new HashSet<string>();

            while (!hashCode.ToLower().Contains("end"))
            {
                if (hashCode.ToLower().Contains("party"))
                {
                    hashCode = Console.ReadLine();

                    while (people.Contains(hashCode))
                    {
                        if (hashCode.ToLower().Contains("end"))
                        {
                            break;
                        }

                        people.Remove(hashCode);
                        hashCode = Console.ReadLine();
                    }
                }
                else
                {
                    people.Add(hashCode);
                    hashCode = Console.ReadLine();
                }
            }

            Console.WriteLine(people.Count);
            foreach (string person in people)
            {
                if (char.IsDigit(person[0]))
                {
                    Console.WriteLine(person);
                }
                else
                {
                    toBePrinted.Add(person);
                }
            }

            foreach (string person in toBePrinted)
            {
                Console.WriteLine(person);
            }
        }
    }
}
