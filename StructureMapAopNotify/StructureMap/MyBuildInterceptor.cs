using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using StructureMap;
using StructureMap.Pipeline;
using StructureMapAopNotify.CastleDynamicProxy;

namespace StructureMapAopNotify.StructureMap
{
    public class MyBuildInterceptor : IBuildInterceptor
    {
        public MyBuildInterceptor(Type concreteType)
        {
            _ConcreteType = concreteType;
        }

        readonly Type _ConcreteType;

        public object Build(BuildSession buildSession, Type pluginType, Instance instance)
        {
            var constructorArgs = _ConcreteType
                .GetConstructors()
                .FirstOrDefault()
                .GetParameters()
                .Select(p => buildSession.CreateInstance(p.ParameterType))
                .ToArray();


            var interceptors = new List<IInterceptor>
                                   {
                                       new NotifyInterceptor()
                                   }
                                   .ToArray();

            return new ProxyGenerator().CreateClassProxy(_ConcreteType, interceptors, constructorArgs);
        }

        public IBuildPolicy Clone()
        {
            return InnerPolicy.Clone();
        }

        public void EjectAll()
        {
            InnerPolicy.EjectAll();
        }

        public IBuildPolicy InnerPolicy { get; set; }
    }
}