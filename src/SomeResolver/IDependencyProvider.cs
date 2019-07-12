using System;
using System.Collections.Generic;
using System.Text;

namespace SomeResolver
{
    public interface IDependencyProvider
    {
        TDependency GetDependency<TDependency>();
    }
}
