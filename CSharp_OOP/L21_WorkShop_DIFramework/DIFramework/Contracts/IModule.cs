﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework.Contracts
{
    public interface IModule
    {
        void Configure();
        Type GetMapping(Type currentInterface, object attribute);
        object GetInstance(Type type);
        void SetInstance(Type implementation, object instance);
    }
}
