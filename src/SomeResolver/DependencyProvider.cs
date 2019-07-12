using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SomeResolver
{
    internal class DependencyProvider : IDependencyProvider
    {
        private readonly Dictionary<Type, Type> _dependencies;

        internal DependencyProvider(Dictionary<Type, Type> dependencies)
        {
            _dependencies = dependencies ?? throw new ArgumentNullException(nameof(dependencies));
        }

        private IEnumerable<object> ResolveDependencies(ConstructorInfo constructorInfo)
        {
            if (constructorInfo == null)
                throw new ArgumentNullException(nameof(constructorInfo));

            var dependencies = new List<object>();

            foreach (var parameter in constructorInfo.GetParameters())
                dependencies.Add(GetDependency(parameter.ParameterType));

            return dependencies;
        }

        private object GetDependency(Type type)
        {
            var dependency = _dependencies.FirstOrDefault(registration => registration.Key == type).Value;

            if (dependency == null)
                return null;

            var constructors = dependency.GetConstructors();

            // Assume instantiation should be done with first constructor found with parameters.
            var ctor = constructors.FirstOrDefault(c => c.GetParameters().Any());

            if (ctor == null)
                return Activator.CreateInstance(dependency);

            var dependencies = ResolveDependencies(ctor);

            return ctor.Invoke(dependencies.ToArray());
        }

        public TDependency GetDependency<TDependency>()
            => (TDependency) GetDependency(typeof(TDependency));
    }
}
