using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Generic_Count_Method_String
{
    public class Box<T>
        where T : IComparable
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
