using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.StackImplementation
{
    public class NewStack<T>
    {
        private const int InitialSize = 4;

        private T[] array;
        private int counter;

        public NewStack() : this(InitialSize) { }

        public NewStack(int initialSize)
        {
            this.array = new T[initialSize];
            this.counter = 0;
        }

        
        public void Push(T element)
        {
            if (this.counter == this.array.Length)
            {
                ResizeStack();
            }
            array[counter] = element;
            counter++;
        }

        public T Peek()
        {
            if (this.counter==0)
            {
                throw new ArgumentException("The stack is empty");
            }

            T objectToReturn = this.array[this.counter - 1];

            return objectToReturn;
        }

        public int Count { get { return this.counter;} }

        public T Pop()
        {
            counter--;
            return this.Peek();
        }

        private void ResizeStack()
        {
            T[] newArray = new T[2 * this.array.Length];
            Array.Copy(this.array, newArray, this.array.Length);
            this.array = newArray;
        }
    }
}
