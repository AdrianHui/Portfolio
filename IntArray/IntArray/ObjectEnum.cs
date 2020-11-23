using System;
using System.Collections;

namespace IntegerArray
{
    class ObjectEnum : IEnumerator
    {
        private readonly object[] objects;
        private int count = -1;

        public ObjectEnum(object[] objects)
        {
            this.objects = objects;
        }

        public object Current => objects[count];

        public bool MoveNext()
        {
            count++;
            return count < objects.Length;
        }

        public void Reset()
        {
            count = -1;
        }
    }
}
