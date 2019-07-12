using System;
using System.Collections.Generic;
using System.Text;

namespace SomeResolver
{
    public class DependencyCollection : IDependencyCollection
    {
        private readonly Dictionary<Type, Type> _dependencies;

        public DependencyCollection()
        {
            _dependencies = new Dictionary<Type, Type>();
        }

        public IDependencyCollection RegisterDependency<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _dependencies.Add(typeof(TInterface), typeof(TImplementation));
            return this;
        }

        public IDependencyCollection RegisterDependency<TImplementation>()
        {
            _dependencies.Add(typeof(TImplementation), typeof(TImplementation));
            return this;
        }

        public IDependencyProvider BuildDependencyProvider()
            => new DependencyProvider(_dependencies);
    }
}
