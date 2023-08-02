using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : Collection, IAddable
    {
        private int index = 0;

        public AddCollection()
            : base()
        {

        }
        public int Add(string @string)
        {
           this.Strings.Add(@string);
            return index++;
        }
    }
}
