namespace FifthSixthAndSeventhTasksGenericList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericList<T>
    {
        // Fields
        private const int defaultCapacity = 4;
        private T[] defaultArray;
        private int size;
        private readonly static T[] emptyArray;

        // Properties
        public int Capacity
        {
            get
            {
                return (int)this.defaultArray.Length;
            }
            set
            {
                if (value < this.size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (value != (int)this.defaultArray.Length)
                {
                    if (value <= 0)
                    {
                        this.defaultArray = GenericList<T>.emptyArray;
                    }
                    else
                    {
                        T[] tArray = new T[value];
                        if (this.size > 0)
                        {
                            Array.Copy(this.defaultArray, 0, tArray, 0, this.size);
                        }
                        this.defaultArray = tArray;
                    }
                }
            }
        }

        public int Count { get { return this.size; } }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return this.defaultArray[index];
                }
            }
            set
            {
                if (index < 0 || index >= size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.defaultArray[index] = value;
                }
            }
        }

        // Constructors
        public GenericList()
        {
            this.defaultArray = GenericList<T>.emptyArray;
        }

        public GenericList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (capacity == 0)
            {
                this.defaultArray = GenericList<T>.emptyArray;
            }
            else
            {
                this.defaultArray = new T[capacity];
            }
        }

        public GenericList(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                int count = array.Length;
                this.defaultArray = new T[count];
                array.CopyTo(this.defaultArray, 0);
                this.size = count;
            }
        }

        // Methods

        private void EnsureCapacity(int min)
        {
            int length;

            if ((int)this.defaultArray.Length < min)
            {
                if ((int)this.defaultArray.Length == 0)
                {
                    length = 4;
                }
                else
                {
                    length = (int)this.defaultArray.Length * 2;
                }

                int num = length;

                if (num > 2146435071)
                {
                    num = 2146435071;
                }
                if (num < min)
                {
                    num = min;
                }
                this.Capacity = num;
            }
        }

        public void Add(T item)
        {
            if (this.size == (int)this.defaultArray.Length)
            {
                EnsureCapacity(this.size + 1);
            }

            this.defaultArray[this.size] = item;
            this.size++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.size)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.size--;
            if (index < this.size)
            {
                Array.Copy(this.defaultArray, index + 1, this.defaultArray, index, this.size - index);
            }
            T t = default(T);
            this.defaultArray[this.size] = t;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.size)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (this.size == (int)this.defaultArray.Length)
            {
                EnsureCapacity(this.size + 1);
            }

            if (index < this.size)
            {
                Array.Copy(this.defaultArray, index, this.defaultArray, index + 1, this.size - index);
            }

            this.defaultArray[index] = item;
            this.size++;
        }

        public void Clear()
        {
            if (this.size > 0)
            {
                Array.Clear(this.defaultArray, 0, this.size);
                this.size = 0;
            }
        }

        public int FindIndex(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException("match");
            }

            int num = 0;
            while (num < this.size)
            {
                if (!match(this.defaultArray[num]))
                {
                    num++;
                }
                else
                {
                    return num;
                }
            }

            return -1;
        }

        public T Min()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements.");
            }

            if (this.size == 1)
            {
                return this.defaultArray[0];
            }

            if (this.defaultArray[0] is IComparable<T>)
            {
                T min = this.defaultArray[0];

                for (int i = 1; i < this.size; i++)
                {
                    if ((min as IComparable<T>).CompareTo(this.defaultArray[i]) > 0)
                    {
                        min = this.defaultArray[i];
                    }
                }

                return min;
            }
            else
            {
                throw new ArgumentException("At least one object must implement IComparable.");
            }
        }

        public T Max()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements.");
            }

            if (this.size == 1)
            {
                return this.defaultArray[0];
            }

            if (this.defaultArray[0] is IComparable<T>)
            {
                T max = this.defaultArray[0];

                for (int i = 1; i < this.size; i++)
                {
                    if ((max as IComparable<T>).CompareTo(this.defaultArray[i]) < 0)
                    {
                        max = this.defaultArray[i];
                    }
                }

                return max;
            }
            else
            {
                throw new ArgumentException("At least one object must implement IComparable.");
            }
        }

        public T[] ToArray()
        {
            T[] tArray = new T[this.size];
            Array.Copy(this.defaultArray, 0, tArray, 0, this.size);
            return tArray;
        }

        public override string ToString()
        {
            if (this.size == 0)
            {
                return String.Empty;
            }

            return String.Join(", ", this.ToArray());
        }
    }
}
