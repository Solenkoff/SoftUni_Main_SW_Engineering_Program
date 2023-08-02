using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : Collection, IAddRemovable
    {
       

        public int Add(string @string)
        {
            this.Strings.Insert(0, @string);
            return 0;
        }

        public string Remove()
        {
            string @string = this.Strings[Strings.Count - 1];
            this.Strings.RemoveAt(this.Strings.Count - 1);
            return @string;
        }
    }
}
