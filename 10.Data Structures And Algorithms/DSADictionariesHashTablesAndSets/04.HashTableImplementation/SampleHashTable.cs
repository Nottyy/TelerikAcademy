using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableImplementation
{
    public class SampleHashTable<K,T>
    {
        private LinkedList<KeyValuePair<K, T>>[] container;
        private int count;
        private int capacity;

        public SampleHashTable()
        {
            this.container = new LinkedList<KeyValuePair<K, T>>[16];
            this.count = 0;
            this.capacity = 0;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }

        public void Clear()
        {
            LinkedList<KeyValuePair<K, T>>[] clearedList = new LinkedList<KeyValuePair<K, T>>[16];
            this.container = clearedList;

            this.count = 0;
            this.capacity = 0;
        }

        private void AutoGrow()
        {
            LinkedList<KeyValuePair<K, T>>[] expandedArray = new LinkedList<KeyValuePair<K, T>>[2 * this.Capacity];
            Array.Copy(this.container, expandedArray,this.Capacity);
            this.container = expandedArray;
        }

        public void Add(K key, T value)
        {
            if (key == null || value == null)
            {
                throw new ArgumentNullException("The key or the value cannot be null.");
            }

            if (this.Capacity >= this.container.Length * 0.75)
            {
                this.AutoGrow();
            }

            int index = Math.Abs(key.GetHashCode() % this.container.Length);

            if (this.container[index] == null)
            {
                this.container[index] = new LinkedList<KeyValuePair<K, T>>();
                this.Capacity++;
            }

            var currentElement = this.container[index].First;

            while (currentElement != null)
            {
                if (currentElement.Value.Key.Equals(key))
                {
                    //throw new ArgumentException("Key already exists!");
                    return;
                }

                currentElement = currentElement.Next;
            }

            this.container[index].AddLast(new KeyValuePair<K, T>(key, value));
            this.Count++;
        }

        public void Remove(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null!");
            }

            int index = key.GetHashCode() % this.container.Length;

            if (this.container[index] == null)
            {
                throw new NullReferenceException("Key does not exist!");
            }

            var currentElement = this.container[index].First;
            bool existingKey = false;

            while (currentElement != null)
            {
                if (currentElement.Value.Key.Equals(key))
                {
                    this.container[index].Remove(currentElement);
                    this.Count--;
                    existingKey = true;
                    break;
                }

                currentElement = currentElement.Next;
            }

            if (this.container[index].First == null)
            {
                this.capacity -= 1;
            }

            if (!existingKey)
            {
                throw new ArgumentException("The key does not exist!");
            }
        }

        public T Find(K key)
        {
            if (key == null)
            {
                throw new ArgumentException("Key cannot be null.");
            }

            int index = Math.Abs(key.GetHashCode() % this.container.Length);

            if (this.container[index] == null)
            {
                throw new ArgumentException("There is no element with this key.");
            }
            else
            {
                foreach (var item in this.container[index])
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }
            }

            throw new ArgumentException("There is no element with this key.");
        }

        public T this[K key]
        {
            get
            {
                return Find(key);
            }
            set
            {
                int index = key.GetHashCode() % this.container.Length;

                if (this.container[index] == null)
                {
                    this.container[index] = new LinkedList<KeyValuePair<K, T>>();
                }

                bool exist = false;
                var currentElement = this.container[index].First;

                while (currentElement != null)
                {
                    if (currentElement.Value.Key.Equals(key))
                    {
                        currentElement.Value = new KeyValuePair<K, T>(key, value);
                        exist = true;
                        break;
                    }

                    currentElement = currentElement.Next;
                }

                if (!exist)
                {
                    throw new ArgumentException("Key does not exist.");
                }
            }
        }

        public List<K> Keys()
        {
            var keys = new List<K>();

            foreach (var item in this.container)
            {
                if (item != null)
                {
                    var currentLinkedList = item.First;

                    while (currentLinkedList != null)
                    {
                        keys.Add(currentLinkedList.Value.Key);
                        currentLinkedList = currentLinkedList.Next;
                    }
                }
            }

            return keys;
        }

        public List<T> Values()
        {
            var values = new List<T>();

            foreach (var item in this.container)
            {
                if (item != null)
                {
                    var currentLinkedList = item.First;

                    while (currentLinkedList != null)
                    {
                        values.Add(currentLinkedList.Value.Value);
                        currentLinkedList = currentLinkedList.Next;
                    }
                }
            }

            return values;
        }
    }
}
