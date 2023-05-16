using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Generic_Box_Of_Integer
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }


        public override string ToString()
        {
            Type valueType = this.Value.GetType();
            string valueTypeFullname = valueType.FullName;

            return $"{valueTypeFullname}: {this.Value}";
        }

    }
}
