﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAddRemovable : IAddable
    {
        string Remove();

    }
}
