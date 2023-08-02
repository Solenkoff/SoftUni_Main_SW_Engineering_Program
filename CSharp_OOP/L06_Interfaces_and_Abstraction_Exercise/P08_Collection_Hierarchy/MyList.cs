using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : Collection, IMyListable
    {
        public int Used => this.Strings.Count;

        public int Add(string @string)
        {
            this.Strings.Insert(0, @string);
            return 0;
        }

        public string Remove()
        {
            string firstElement = this.Strings[0];
            this.Strings.RemoveAt(0);
            return firstElement;
        }
    }
}
