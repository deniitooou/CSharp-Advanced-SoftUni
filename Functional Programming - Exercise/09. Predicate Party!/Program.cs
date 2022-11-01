using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static Action<List<string>, int> removeLength = (l, x) => l.RemoveAll(w => w.Length == x);
        static Action<List<string>, string> removeEnd = (l, s) => l.RemoveAll(w => w.EndsWith(s));
        static Action<List<string>, string> removeStart = (l, s) => l.RemoveAll(w => w.StartsWith(s));

        static Action<List<string>, string> doubleStart = (l, s) =>
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].StartsWith(s))
                {
                    l.Insert(i, l[i]);
                    i++;
                }
            }
        };
        static Action<List<string>, string> doubleEnd = (l, s) =>
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].EndsWith(s))
                {
                    l.Insert(i, l[i]);
                    i++;
                }
            }
        };
        static Action<List<string>, int> doubleLength = (l, x) =>
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Length == x)
                {
                    l.Insert(i, l[i]);
                    i++;
                }
            }
        };

        static Predicate<List<string>> isEmpty = l => l.Count == 0;
        static Action<List<string>> print = l =>
        {
            if (isEmpty(l))
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", l)} are going to the party!");
            }
        };
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Manipulate(Console.ReadLine(), people);
            print(people);
        }

        private static void Manipulate(string command, List<string> people)
        {
            if (command.Contains("Remove"))
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[1])
                {
                    case "StartsWith":
                        removeStart(people, tokens[2]);
                        break;
                    case "EndsWith":
                        removeEnd(people, tokens[2]);
                        break;
                    case "Length":
                        removeLength(people, int.Parse(tokens[2]));
                        break;
                }
            }
            else if (command.Contains("Double"))
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[1])
                {
                    case "StartsWith":
                        doubleStart(people, tokens[2]);
                        break;
                    case "EndsWith":
                        doubleEnd(people, tokens[2]);
                        break;
                    case "Length":
                        doubleLength(people, int.Parse(tokens[2]));
                        break;
                }
            }
            else
            {
                return;
            }
            Manipulate(Console.ReadLine(), people);
        }
    }
}
