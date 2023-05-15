using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Generic_Box_Of_String
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
