using System;
using System.Collections;
using System.Collections.Generic;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Pipeline;

namespace StructureMapAopNotify.StructureMap
{
    public class MyInstanceFactoryInterceptor : IInstanceFactory
    {
        public MyInstanceFactoryInterceptor(Type pluginType)
        {
            _InstanceFactory = new InstanceFactory(pluginType);
        }

        public MyInstanceFactoryInterceptor(PluginFamily family)

        {
            _InstanceFactory = new InstanceFactory(family);
        }

        readonly InstanceFactory _InstanceFactory;

        public void AddInstance(Instance instance)
        {
            _InstanceFactory.AddInstance(instance);
        }

        public Instance AddType<T>()
        {
            return _InstanceFactory.AddType<T>();
        }

        public IList GetAllInstances(BuildSession session)
        {
            return _InstanceFactory.GetAllInstances(session);
        }

        public object Build(BuildSession session, Instance instance)
        {
            return _InstanceFactory.Build(session, instance);
        }

        public Instance FindInstance(string name)
        {
            return _InstanceFactory.FindInstance(name);
        }

        public void ForEachInstance(Action<Instance> action)
        {
            _InstanceFactory.ForEachInstance(action);
        }

        public void ImportFrom(PluginFamily family)
        {
            _InstanceFactory.ImportFrom(family);
        }

        public void EjectAllInstances()
        {
            _InstanceFactory.EjectAllInstances();
        }

        public Type PluginType
        {
            get { return _InstanceFactory.PluginType; }
        }

        public IEnumerable<IInstance> Instances
        {
            get { return _InstanceFactory.Instances; }
        }

        public IBuildPolicy Policy
        {
            get { return _InstanceFactory.Policy; }
        }

        public Instance MissingInstance
        {
            get { return _InstanceFactory.MissingInstance; }
            set { _InstanceFactory.MissingInstance = value; }
        }
    }
}