using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();
            ReadCommand(Console.ReadLine(), filters);
            Print(people, filters);

        }

        private static void Print(List<string> people, Dictionary<string, Predicate<string>> filters)
        {
            foreach (var filter in filters)
            {
                people = people.Where(w => !filter.Value(w)).ToList();
            }
            Console.WriteLine(string.Join(" ", people));
        }

        private static void ReadCommand(string command, Dictionary<string, Predicate<string>> filters)
        {
            if (command == "Print")
            {
                return;
            }
            string[] tokens = command
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            string action = tokens[0];
            string filterType = tokens[1];
            string value = tokens[2];
            string filterName = filterType + value;

            Predicate<string> filter = CreateFilter(filterType, value);

            switch (action)
            {
                case "Add filter":
                    filters.Add(filterName, filter);
                    break;
                case "Remove filter":
                    filters.Remove(filterName);
                    break;
            }
            ReadCommand(Console.ReadLine(), filters);
        }

        private static Predicate<string> CreateFilter(string filterType, string value)
        {
            switch (filterType)
            {
                case "Starts with":
                    return x => x.StartsWith(value);
                case "Ends with":
                    return x => x.EndsWith(value);
                case "Contains":
                    return x => x.Contains(value);
                case "Length":
                    return x => x.Length == 0;
                default:
                    return x => x == null;
            }
        }
    }
}
