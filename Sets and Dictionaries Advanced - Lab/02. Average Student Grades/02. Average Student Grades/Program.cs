using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine().Split();
                var studentName = data[0];
                var studentGrade = decimal.Parse(data[1]);

                if (!studentsGrades.ContainsKey(studentName))
                    studentsGrades.Add(studentName, new List<decimal>());

                studentsGrades[studentName].Add(studentGrade);
            }

            foreach (var student in studentsGrades)
                Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value.Select(grade => grade.ToString("F2")))} (avg: {student.Value.Average():f2})");

        }
    }
}