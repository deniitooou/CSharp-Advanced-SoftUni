using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ForceSide> forceSides = new List<ForceSide>();

            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string curForceSideName = tokens[0];
                    string curForceUserName = tokens[1];

                    if (!forceSides.Any(side => side.Users.Contains(curForceUserName)))
                    {
                        AddNewUser(forceSides, curForceSideName, curForceUserName);
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string curForceSideName = tokens[1];
                    string curForceUserName = tokens[0];

                    if (forceSides.Any(side => side.Users.Contains(curForceUserName)))
                    {
                        ForceSide oldForceSide = forceSides.Find(side => side.Users.Contains(curForceUserName));

                        oldForceSide.Users.Remove(curForceUserName);

                        if (!forceSides.Any(side => side.Name == curForceSideName))
                        {
                            forceSides.Add(new ForceSide(curForceSideName));
                        }
                        ForceSide newForceSide = forceSides.Find(side => side.Name == curForceSideName);
                        newForceSide.Users.Add(curForceUserName);
                        Console.WriteLine($"{curForceUserName} joins the {curForceSideName} side!");
                    }
                    else
                    {
                        AddNewUser(forceSides, curForceSideName, curForceUserName);
                        Console.WriteLine($"{curForceUserName} joins the {curForceSideName} side!");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var side in forceSides.OrderByDescending(side => side.Users.Count).ThenBy(side => side.Name))
            {
                if (side.Users.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Name}, Members: {side.Users.Count}");
                    foreach (var user in side.Users)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }

        }
        static void AddNewUser(List<ForceSide> forceSides, string curForceSideName, string curForceUserName)
        {
            if (!forceSides.Any(forceSide => forceSide.Name == curForceSideName))
            {
                forceSides.Add(new ForceSide(curForceSideName));
            }
            var curForceSide = forceSides.Find(forceSide => forceSide.Name == curForceSideName);
            curForceSide.Users.Add(curForceUserName);
        }
    }
    class ForceSide
    {
        public ForceSide(string name)
        {
            Name = name;
            Users = new SortedSet<string>();
        }

        public string Name { get; set; }
        public SortedSet<string> Users { get; set; }
    }
}

