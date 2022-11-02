using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"../../../Files/words.txt";
            string textPath = @"../../../Files/text.txt";
            string outputPath = @"../../../Files/output.txt";
            CalculateWordCounts(wordPath, textPath, outputPath);
        }
        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            List<string> words = new List<string>();
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                words = reader.ReadLine().Split(" ").ToList();
                var text = reader.ReadToEnd().Split().ToArray();

                foreach (var word in text)
                {
                    if (words.Contains(word))
                    {
                        if (!wordCounts.ContainsKey(word))
                            wordCounts.Add(word, 0);

                        wordCounts[word]++;

                    }
                }
            }

            using (StreamReader reader = new StreamReader(textFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var (word, count) in wordCounts.OrderByDescending(x => x.Value))
                        writer.WriteLine($"{word} - {count}");
                    
                }
            }
        }
    }
}