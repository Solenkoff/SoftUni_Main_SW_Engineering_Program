using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IMyListable : IAddRemovable
    {
        int Used { get; }
    }
}
