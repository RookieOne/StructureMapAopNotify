using System;
using Castle.DynamicProxy;
using StructureMap;

namespace StructureMapAopNotify.StructureMap
{
    public class StructureMapProxyBuilder : IProxyBuilder
    {
        public StructureMapProxyBuilder(IContainer container)
        {
            _Container = container;
        }

        readonly IContainer _Container;

        public Type CreateClassProxy(Type classToProxy, ProxyGenerationOptions options)
        {
            return null;
            //return _Container.GetInstance(classToProxy);
        }

        public Type CreateClassProxy(Type classToProxy, Type[] additionalInterfacesToProxy,
                                     ProxyGenerationOptions options)
        {
            throw new NotImplementedException();
        }

        public Type CreateInterfaceProxyTypeWithTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy,
                                                       Type targetType, ProxyGenerationOptions options)
        {
            throw new NotImplementedException();
        }

        public Type CreateInterfaceProxyTypeWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy,
                                                          ProxyGenerationOptions options)
        {
            throw new NotImplementedException();
        }

        public Type CreateInterfaceProxyTypeWithTargetInterface(Type interfaceToProxy,
                                                                Type[] additionalInterfacesToProxy,
                                                                ProxyGenerationOptions options)
        {
            throw new NotImplementedException();
        }

        public ModuleScope ModuleScope
        {
            get { throw new NotImplementedException(); }
        }
    }
}