using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            StringBuilder previousVersion = new StringBuilder();

            Stack<List<string>> operationsTrack = new Stack<List<string>>();

            int operationsCount = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();

            for (int i = 0; i < operationsCount; i++)
            {
                List<string> tokens = input.Split().ToList();
                var command = tokens[0];

                if (command == "1")
                {
                    text = text.Append(tokens[1]);
                    operationsTrack.Push(tokens);
                }
                else if (command == "2")
                {
                    var textToRemove = text.ToString(text.Length - int.Parse(tokens[1]), int.Parse(tokens[1]));
                    text = text.Remove(text.Length - int.Parse(tokens[1]), int.Parse(tokens[1]));

                    tokens.Add(textToRemove);
                    operationsTrack.Push(tokens);
                }
                else if (command == "3")
                {
                    var index = int.Parse(tokens[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command == "4")
                {
                    previousVersion = text;
                    var prevOperation = operationsTrack.Pop();
                    var operation = prevOperation[0];
                    var symbols = prevOperation[1];

                    if (operation == "1")
                    {
                        previousVersion = previousVersion.Remove(previousVersion.Length - symbols.Length, symbols.Length);
                        text = previousVersion;
                    }
                    else if (operation == "2")
                    {
                        var removedText = prevOperation[2];
                        previousVersion = previousVersion.Append(removedText);
                        text = previousVersion;
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
