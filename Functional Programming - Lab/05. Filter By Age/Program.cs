using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<Person, string, int, bool> Filter = (per, condition, thresHold) =>
            {
                if (condition == "younger")
                {
                    if (per.Age < thresHold)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (per.Age >= thresHold)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            };
            Action<Person, string> Print = (person, format) =>
            {
                string[] splitted = format.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (splitted.Length == 2)
                {
                    if (splitted[0] == "name")
                    {
                        Console.WriteLine($"{person.Name} - {person.Age}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Age} - {person.Name}");
                    }
                }
                else
                {
                    if (splitted[0] == "name")
                    {
                        Console.WriteLine($"{person.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Age}");
                    }
                }
            };
            List<Person> people = new List<Person>();
            ReadPeople(int.Parse(Console.ReadLine()), people);

            string condition = Console.ReadLine();
            int thresHold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            people.Where(p => Filter(p, condition, thresHold))
                .ToList()
                .ForEach(p => Print(p, format));
        }

        private static void ReadPeople(int count, List<Person> people)
        {
            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(new Person(tokens[0], int.Parse(tokens[1])));
            }
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
