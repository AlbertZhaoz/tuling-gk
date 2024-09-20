using QuartZ.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkService
{
    public class BaseService
    {
        public T GetInstance<T>() => IOCCollection.GetService<T>();
    }
}
