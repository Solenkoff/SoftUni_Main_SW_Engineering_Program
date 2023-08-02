using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public abstract class Collection
    {

        private List<string> strings;
        public Collection()
        {
            this.Strings = new List<string>(100);
        }



        public List<string> Strings { get; set; }

    }
}
