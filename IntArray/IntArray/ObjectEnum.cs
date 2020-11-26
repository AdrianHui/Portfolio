using System;
using System.Collections;

namespace IntegerArray
{
    class ObjectEnum : IEnumerator
    {
        private readonly ObjectArray objects;
        private int position = -1;

        public ObjectEnum(ObjectArray objects)
        {
            this.objects = objects;
        }

        public object Current => objects[position];

        public bool MoveNext()
        {
            position++;
            return position < objects.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
