using System;

namespace SomeResolver
{
    public interface IDependencyCollection
    {
        IDependencyCollection RegisterDependency<TInterface, TImplementation>() where TImplementation : TInterface;
        IDependencyCollection RegisterDependency<TImplementation>();
        IDependencyProvider BuildDependencyProvider();
    }
}
