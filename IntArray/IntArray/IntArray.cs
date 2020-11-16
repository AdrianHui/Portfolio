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
			if (count >= data.Length)
			{
				Array.Resize(ref data, data.Length * 2);
			}

			data[count] = element;
			count++;
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
			var temp = new int[data.Length];
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
			var temp = new int[data.Length];
			for (int i = 0; i < count + 1; i++)
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

			count++;
			data = temp;
		}

		public void Clear()
		{
			data = new int[4];
			count = 0;
		}

		public void Remove(int element)
		{
			var temp = new int[data.Length];
			for (int i = 0; i < count; i++)
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

			count--;
			data = temp;
		}

		public void RemoveAt(int index)
		{
			var temp = new int[data.Length];
			for (int i = 0; i < count; i++)
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

			count--;
			data = temp;
		}
	}
}
