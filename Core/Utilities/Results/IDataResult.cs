﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    // for data
    public interface IDataResult<T>:IResults
    {   
        T Data { get; }
    }
}