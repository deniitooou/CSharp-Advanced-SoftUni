using System;
using System.Collections.Generic;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackWithMaxAndMin stack = new StackWithMaxAndMin();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                int operation = int.Parse(tokens[0]);

                if (operation == 1)
                {
                    int num = int.Parse(tokens[1]);
                    stack.push(num);
                }

                else if (operation == 2)
                {
                    stack.pop();
                }

                else if (operation == 3)
                {
                    if (stack.getMax() != null)
                        Console.WriteLine(stack.getMax());
                }

                else if (operation == 4)
                {
                    if (stack.getMin() != null)
                        Console.WriteLine(stack.getMin());
                }
            }

            stack.Print();
        }
    }

    public class StackWithMaxAndMin
    {
        static Stack<int> mainStack = new Stack<int>();
        static Stack<int> trackStackMax = new Stack<int>();
        static Stack<int> trackStackMin = new Stack<int>();

        public void Print()
        {
            Console.WriteLine(String.Join(", ", mainStack));
        }

        public void push(int x)
        {
            mainStack.Push(x);
            if (mainStack.Count == 1)
            {
                trackStackMax.Push(x);
                trackStackMin.Push(x);
                return;
            }

            if (x > trackStackMax.Peek())
            {
                trackStackMax.Push(x);
            }

            if (x < trackStackMin.Peek())
            {
                trackStackMin.Push(x);
            }
            else
                trackStackMax.Push(trackStackMax.Peek());
            {
                trackStackMin.Push(trackStackMin.Peek());
            }
        }

        public int? getMax()
        {
            if (trackStackMax.Count > 0)
            {
                return trackStackMax.Peek();
            }
            return null;
        }

        public int? getMin()
        {
            if (trackStackMin.Count > 0)
            {
                return trackStackMin.Peek();
            }
            return null;
        }

        public void pop()
        {
            if (mainStack.Count > 0)
            {
                mainStack.Pop();
                trackStackMax.Pop();
                trackStackMin.Pop();
            }
        }
    }
}
