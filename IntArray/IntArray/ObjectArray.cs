using System;
using System.Collections;

namespace IntegerArray
{
    class ObjectArray : IEnumerable
    {
        private object[] data;

        public ObjectArray()
        {
            data = new object[4];
        }

        public int Count { get; private set; }

        public virtual object this[int index] { get => data[index]; set => data[index] = value; }

        public IEnumerator GetEnumerator()
        {
            return new ObjectEnum(this);
        }

        public virtual void Add(object element)
        {
            ExpandCheck();
            data[Count] = element;
            Count++;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(object element)
        {
            return GetIndex(element);
        }

        public virtual void Insert(int index, object element)
        {
            ShiftRight(index);
            data[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(object element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        private void ExpandCheck()
        {
            if (Count != data.Length)
            {
                return;
            }

            Array.Resize(ref data, data.Length * 2);
        }

        private void ShiftRight(int stopIndex)
        {
            for (int i = Count; i > stopIndex; i--)
            {
                ExpandCheck();
                data[i] = data[i - 1];
            }
        }

        private void ShiftLeft(int startIndex)
        {
            for (int i = startIndex; i < Count; i++)
            {
                data[i] = i == Count - 1 ? default : data[i + 1];
            }
        }

        private int GetIndex(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (data[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}