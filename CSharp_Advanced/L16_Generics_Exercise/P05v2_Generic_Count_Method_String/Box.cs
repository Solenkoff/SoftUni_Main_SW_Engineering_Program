using System;
using System.Collections.Generic;
using System.Text;

namespace _05v2_Generic_Count_Method_String
{
    public class Box<T>: IComparable
        where T : IComparable
    {

        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public int CompareTo(object obj)
        {
            Box<T> box = obj as Box<T>;

            int compare = this.Value.CompareTo(box.Value);
            return compare;
        }

        public override string ToString()
        {
            Type valueType = this.Value.GetType();
            string valueTypeFullname = valueType.FullName;

            return $"{valueTypeFullname}: {this.Value}";
        }
    }
}
