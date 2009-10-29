using System;
using System.Collections.Generic;
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
            var generator = new ProxyGenerator();

            var constructor = _ConcreteType.GetConstructors()[0];
            var parameters = constructor.GetParameters();

            List<object> args = new List<object>();
            foreach (var parameter in parameters)
            {
                args.Add(App.Container.GetInstance(parameter.ParameterType));
            }

            var interceptors = new List<IInterceptor>();
            interceptors.Add(new NotifyInterceptor());


            return generator.CreateClassProxy(_ConcreteType, interceptors.ToArray(), args.ToArray());
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

    public class MyBuildPolicy : IBuildPolicy
    {
        public MyBuildPolicy(Type concreteType)
        {
            _ConcreteType = concreteType;
        }

        readonly Type _ConcreteType;

        public object Build(BuildSession buildSession, Type pluginType, Instance instance)
        {
            var generator = new ProxyGenerator();

            var constructor = _ConcreteType.GetConstructors()[0];
            var parameters = constructor.GetParameters();

            List<object> args = new List<object>();
            foreach (var parameter in parameters)
            {
                args.Add(App.Container.GetInstance(parameter.ParameterType));
            }

            var interceptors = new List<IInterceptor>();
            interceptors.Add(new NotifyInterceptor());


            return generator.CreateClassProxy(_ConcreteType, interceptors.ToArray(), args.ToArray());
        }

        public IBuildPolicy Clone()
        {
            return new MyBuildPolicy(_ConcreteType);
        }

        public void EjectAll()
        {
        }
    }
}