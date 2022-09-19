using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool isBalanced = true;
            Stack<char> parentheses = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                {
                    parentheses.Push(input[i]);
                }
                else
                {
                    if (input[i] == ')')
                    {
                        if (parentheses.Count == 0)
                        {
                            isBalanced = false;
                        }
                        else if (parentheses.Pop() != '(')
                        {
                            isBalanced = false;
                        }
                        else
                        {
                            isBalanced = true;
                        }
                    }

                    else if (input[i] == ']')
                    {
                        if (parentheses.Count == 0)
                        {
                            isBalanced = false;
                        }
                        else if (parentheses.Pop() != '[')
                        {
                            isBalanced = false;
                        }
                        else
                        {
                            isBalanced = true;
                        }
                    }

                    else if (input[i] == '}')
                    {
                        if (parentheses.Count == 0)
                        {
                            isBalanced = false;
                        }
                        else if (parentheses.Pop() != '{')
                        {
                            isBalanced = false;
                        }
                        else
                        {
                            isBalanced = true;
                        }
                    }
                }
            }

            if (!isBalanced || parentheses.Count > 0)
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES");
        }
    }
}
