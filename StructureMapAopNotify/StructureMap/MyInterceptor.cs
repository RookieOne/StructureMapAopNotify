using System;
using System.Collections.Generic;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using StructureMap;
using StructureMap.Interceptors;
using StructureMapAopNotify.CastleDynamicProxy;
using StructureMapAopNotify.ViewModels;

namespace StructureMapAopNotify.StructureMap
{
    public class MyInterceptor : TypeInterceptor
    {
        public object Process(object target, IContext context)
        {
            var generator = new ProxyGenerator();
            var type = target.GetType();

            var constructor = type.GetConstructors()[0];
            var parameters = constructor.GetParameters();

            List<object> args = new List<object>();
            foreach (var parameter in parameters)
            {
                args.Add(App.Container.GetInstance(parameter.ParameterType));
            }

            var interceptors = new List<IInterceptor>();
            interceptors.Add(new NotifyInterceptor());

            return generator.CreateClassProxy(typeof (MyViewModel), interceptors.ToArray(), args.ToArray());
        }

        public bool MatchesType(Type type)
        {
            return type.CanBeCastTo(typeof (BaseViewModel));
        }
    }
}