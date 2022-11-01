using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPasswords = new Dictionary<string, string>();
            List<Student> students = new List<Student>();

            string[] tokens = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            while (tokens[0] != "end of contests")
            {
                string curContestName = tokens[0];
                string curPassword = tokens[1];
                contestPasswords.Add(curContestName, curPassword);

                tokens = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] submissions = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            while (submissions[0] != "end of submissions")
            {
                string curContest = submissions[0];
                string curPassword = submissions[1];
                string curStudentName = submissions[2];
                int curPoints = int.Parse(submissions[3]);

                if (contestPasswords.ContainsKey(curContest))
                {
                    if (contestPasswords[curContest] == curPassword)
                    {
                        if (!students.Any(student => student.Name == curStudentName))
                        {
                            students.Add(new Student(curStudentName));
                        }
                        var curStudent = students.Find(student => student.Name == curStudentName);
                        if (!curStudent.Contests.ContainsKey(curContest))
                        {
                            curStudent.Contests.Add(curContest, curPoints);
                        }
                        else
                        {
                            if (curStudent.Contests[curContest] < curPoints)
                            {
                                curStudent.Contests[curContest] = curPoints;
                            }
                        }
                    }
                }
                submissions = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            Student bestCandidate = FindBestCandidate(students);
            Console.WriteLine($"Best candidate is {bestCandidate.Name} with total {bestCandidate.TotalPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in students.OrderBy(student => student.Name).ToList())
            {
                Console.WriteLine(student.Name);
                foreach (var contest in student.Contests.OrderByDescending(contest => contest.Value).ToList())
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static Student FindBestCandidate(List<Student> students)
        {
            var bestPoints = students.Max(student => student.TotalPoints);
            var bestStudent = students.Find(students => students.TotalPoints == bestPoints);

            return bestStudent;
        }
    }
    class Student
    {
        public Student(string name)
        {
            this.Name = name;
            this.Contests = new Dictionary<string, int>();
        }
        public string Name { get; set; }
        public Dictionary<string, int> Contests { get; set; }
        public int TotalPoints { get { return Contests.Values.Sum(); } }
    }
}

