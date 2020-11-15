using System;

namespace IntegerArray
{
    class IntArray
    {
		public int count;
		public int[] data;
		public IntArray()
		{
			this.data = new int[4];
			this.count = 0;
		}

		public void Add(int element)
		{
			count++;
			Array.Resize(ref data, count);
			data[count - 1] = element;
		}

		public int Count()
		{
			return count;
		}

		public int Element(int index)
		{
			return data[index];
		}

		public void SetElement(int index, int element)
		{
			var temp = new int[count];
			for (int i = 0; i < count; i++)
            {
				if (i == index)
                {
					temp[i] = element;
                }
                else
                {
					temp[i] = data[i];
				}
            }

			data = temp;
		}

		public bool Contains(int element)
		{
			for (int i = 0; i < count; i++)
            {
				if (data[i] == element)
                {
					return true;
                }
            }

			return false;
		}

		public int IndexOf(int element)
		{
			for (int i = 0; i < count; i++)
            {
				if (data[i] == element)
				{
					return i;
				}
			}

			return -1;
		}

		public void Insert(int index, int element)
		{
			count++;
			var temp = new int[count];
			for (int i = 0; i < count; i++)
			{
				if (index > i)
                {
					temp[i] = data[i];
                }
				else if (index == i)
                {
					temp[i] = element;
                }
                else
                {
					temp[i] = data[i - 1];
                }
			}

			data = temp;
		}

		public void Clear()
		{
			data = new int[0];
			count = 0;
		}

		public void Remove(int element)
		{
			count--;
			var temp = new int[count];
			for (int i = 0; i < count + 1; i++)
			{
				if (IndexOf(element) > i)
				{
					temp[i] = data[i];
				}

				if (IndexOf(element) < i)
				{
					temp[i - 1] = data[i];
				}
			}

			data = temp;
		}

		public void RemoveAt(int index)
		{
			count--;
			var temp = new int[count];
			for (int i = 0; i < count + 1; i++)
			{
				if (i < index)
                {
					temp[i] = data[i];
				}

				if (i > index)
				{
					temp[i - 1] = data[i];
				}
			}

			data = temp;
		}
	}
}
