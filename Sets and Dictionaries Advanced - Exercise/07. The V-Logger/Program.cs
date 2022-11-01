using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggers = new List<Vlogger>();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Statistics")
            {
                if (command.Length == 4)
                {
                    JoiningVlog(vloggers, command);
                }
                else
                {
                    FollowingVlogger(vloggers, command);
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Vlogger bestVlogger = FindBestVlogger(vloggers);
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            Console.WriteLine($"1. {bestVlogger.Name} : {bestVlogger.FollowersCount} followers, {bestVlogger.FollowingCount} following");
            if (bestVlogger.FollowersCount > 0)
            {
                foreach (var follower in bestVlogger.Followers.OrderBy(follower => follower).ToList())
                {
                    Console.WriteLine($"*  {follower}");
                }
            }
            vloggers.Remove(bestVlogger);
            int counter = 2;
            foreach (var vlogger in vloggers.OrderByDescending(vlogger => vlogger.FollowersCount).ThenBy(vlogger => vlogger.FollowingCount).ToList())
            {
                Console.WriteLine($"{counter}. {vlogger.Name} : {vlogger.FollowersCount} followers, {vlogger.FollowingCount} following");
                counter++;
            }
        }

        private static Vlogger FindBestVlogger(List<Vlogger> vloggers)
        {
            var maxFollowers = vloggers.Max(vlogger => vlogger.FollowersCount);
            var bestVloggers = vloggers.Where(vlogger => vlogger.FollowersCount == maxFollowers).ToList();

            var minFollowing = bestVloggers.Min(vlogger => vlogger.FollowingCount);
            Vlogger bestVlogger = bestVloggers.Find(vlogger => vlogger.FollowingCount == minFollowing);

            return bestVlogger;
        }

        private static void FollowingVlogger(List<Vlogger> vloggers, string[] command)
        {
            string curVloggerName = command[0];
            string vloggerToFollow = command[2];

            if (vloggers.Any(vlogger => vlogger.Name == curVloggerName && vloggers.Any(vlogger => vlogger.Name == vloggerToFollow)))
            {
                var curVlogger = vloggers.Find(vlogger => vlogger.Name == curVloggerName);
                var curVloggerToFollow = vloggers.Find(vlogger => vlogger.Name == vloggerToFollow);

                if (curVlogger.Name != curVloggerToFollow.Name)
                {
                    if (!curVloggerToFollow.Followers.Contains(curVlogger.Name))
                    {
                        curVloggerToFollow.Followers.Add(curVlogger.Name);
                        curVlogger.Following.Add(curVloggerToFollow.Name);
                    }
                }
            }
        }

        private static void JoiningVlog(List<Vlogger> vloggers, string[] command)
        {
            string vloggerName = command[0];

            if (!vloggers.Any(vlogger => vlogger.Name == vloggerName))
            {
                vloggers.Add(new Vlogger(vloggerName));
            }
        }
    }

    class Vlogger
    {
        public Vlogger(string name)
        {
            this.Name = name;
            this.Followers = new List<string>();
            this.Following = new List<string>();
        }
        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }
        public int FollowersCount { get { return this.Followers.Count; } }
        public int FollowingCount { get { return this.Following.Count; } }
    }
}

