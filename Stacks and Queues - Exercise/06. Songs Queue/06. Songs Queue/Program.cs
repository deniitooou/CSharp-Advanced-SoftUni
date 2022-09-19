using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfSongs = Console.ReadLine().Split(", ").ToList();
            Queue<string> songs = new Queue<string>(listOfSongs);

            while (songs.Count > 0)
            {
                var command = Console.ReadLine();
                if (command == "Play") songs.Dequeue();
                else if (command == "Show") Console.WriteLine(String.Join(", ", songs));
                else
                {
                    Regex regex = new Regex(@"\s{1,}");
                    string[] tokens = regex.Split(command, 2);

                    var song = tokens[1];

                    if (!songs.Contains(song)) songs.Enqueue(song);
                    else Console.WriteLine($"{song} is already contained!");
                }
            }

            if (songs.Count == 0)
                Console.WriteLine("No more songs!");
        }
    }
}
