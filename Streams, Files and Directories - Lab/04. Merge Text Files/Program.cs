using System;
using System.Collections.Generic;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }
        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> firstInputLines = new List<string>();

            using (StreamReader reader = new StreamReader(firstInputFilePath))
            {
                var line = reader.ReadLine();
                firstInputLines.Add(line);
            }

            List<string> secondInputLines = new List<string>();

            using (StreamReader reader = new StreamReader(secondInputFilePath))
            {
                var line = reader.ReadLine();
                secondInputLines.Add(line);
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < Math.Max(firstInputLines.Count, secondInputLines.Count); i++)
                {
                    if (i < firstInputLines.Count)
                        writer.WriteLine(firstInputLines[i]);

                    if( i < secondInputLines.Count)
                    writer.WriteLine(secondInputLines[i]);
                }
            }
        }

    }
}