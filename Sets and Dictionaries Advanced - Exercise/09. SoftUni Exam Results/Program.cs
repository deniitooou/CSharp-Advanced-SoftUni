using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> studentPoints = new Dictionary<string, int>();
            Dictionary<string, int> languageSubmissions = new Dictionary<string, int>();

            string[] tokens = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
            while (tokens[0] != "exam finished")
            {
                if (tokens.Length == 3)
                {
                    string curStudentName = tokens[0];
                    string curLanguageName = tokens[1];
                    int curPoints = int.Parse(tokens[2]);

                    if (!studentPoints.ContainsKey(curStudentName))
                    {
                        studentPoints.Add(curStudentName, curPoints);
                    }
                    else
                    {
                        if (curPoints > studentPoints[curStudentName])
                        {
                            studentPoints[curStudentName] = curPoints;
                        }
                    }

                    if (!languageSubmissions.ContainsKey(curLanguageName))
                    {
                        languageSubmissions.Add(curLanguageName, 0);
                    }
                    languageSubmissions[curLanguageName]++;
                }
                else
                {
                    string bannedStudentName = tokens[0];
                    if (studentPoints.ContainsKey(bannedStudentName))
                    {
                        studentPoints.Remove(bannedStudentName);
                    }
                }

                tokens = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Results:");
            foreach (var student in studentPoints.OrderByDescending(student => student.Value).ThenBy(student => student.Key).ToList())
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var language in languageSubmissions.OrderByDescending(language => language.Value).ThenBy(language => language.Key).ToList())
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}

