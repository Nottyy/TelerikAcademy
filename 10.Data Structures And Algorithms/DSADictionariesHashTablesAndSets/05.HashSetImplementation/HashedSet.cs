using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTableImplementation;

namespace _05.HashSetImplementation
{
    public class HashedSet<T>
    {
        private SampleHashTable<int, T> hashTable;

        public HashedSet()
        {
            this.hashTable = new SampleHashTable<int, T>();
        }

        public int Count
        {
            get
            {
                return HashTable.Count;
            }
        }

        public SampleHashTable<int, T> HashTable
        {
            get
            {
                return this.hashTable;
            }

            private set
            {
                this.hashTable = value;
            }
        }

        public void Add(T item)
        {
            this.HashTable.Add(item.GetHashCode(), item);
        }

        public void Remove(T item)
        {
            this.HashTable.Remove(item.GetHashCode());
        }

        public void Clear()
        {
            this.HashTable.Clear();
        }

        public T this[T index]
        {
            get
            {
                return hashTable[index.GetHashCode()];
            }
            set
            {
                hashTable[index.GetHashCode()] = value;
            }
        }

        public IEnumerable<T> Values
        {
            get
            {
                return this.HashTable.Values();
            }
        }

        public HashedSet<T> Union(HashedSet<T> otherSet)
        {
            IEnumerable<T> currentElementsValues = this.Values;
            IEnumerable<T> otherElementsValues = otherSet.Values;
            HashedSet<T> newSet = new HashedSet<T>();

            foreach (var item in currentElementsValues)
            {
                newSet.Add(item);
            }

            foreach (var item in otherElementsValues)
            {
                newSet.Add(item);
            }

            return newSet;
        }

        public HashedSet<T> Intersect(HashedSet<T> otherSet)
        {
            IEnumerable<T> currentElementsValues = this.Values;
            IEnumerable<T> otherElementsValues = otherSet.Values;
            HashedSet<T> newSet = new HashedSet<T>();

            foreach (var currentItem in currentElementsValues)
            {
                foreach (var otherSetItem in otherElementsValues)
                {
                    if (currentItem.Equals(otherSetItem))
                    {
                        newSet.Add(otherSetItem);
                    }
                }
            }

            return newSet;
        }
    }
}
