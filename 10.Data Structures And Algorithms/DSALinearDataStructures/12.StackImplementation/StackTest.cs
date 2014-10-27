using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.StackImplementation
{
    class StackTest
    {
        static void Main(string[] args)
        {
            NewStack<int> stack = new NewStack<int>();
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            Console.WriteLine(stack.Peek());
            int element = stack.Pop();
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Count);
        }
    }
}
