using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.QueueImplementation
{
    public class DynamicQueue<T>
    {
        private readonly LinkedList<T> linkedList;

        public DynamicQueue()
        {
            this.linkedList = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            this.linkedList.AddLast(item);
        }

        public T Peek()
        {
            if (this.linkedList.Count == 0)
            {
                throw new ArgumentException("The queue is empty");
            }

            return this.linkedList.First.Value;
        }

        public T Dequeue()
        {
            T itemToTake = this.Peek();
            this.linkedList.RemoveFirst();

            return itemToTake;
        }

        public int Count()
        {
            return this.linkedList.Count();
        }
    } 
}
