using System;
using System.Collections;

namespace IntegerArray
{
    class ObjectEnum : IEnumerator
    {
        private readonly object[] objects;
        private int position = -1;

        public ObjectEnum(object[] objects)
        {
            this.objects = objects;
        }

        public object Current => objects[position];

        public bool MoveNext()
        {
            position++;
            return position < objects.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
