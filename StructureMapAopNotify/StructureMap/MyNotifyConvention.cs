using System;
using System.Linq;
using StructureMap.Graph;

namespace StructureMapAopNotify.StructureMap
{
    public class MyNotifyConvention : ITypeScanner
    {
        public void Process(Type type, PluginGraph graph)
        {

            if (type.GetInterface("IViewModel") == null)
                return;

            var interfaceType = type.GetInterfaces().FirstOrDefault(i => i.Name.Contains("ViewModel")
                                                                && i.Name != "IViewModel");

            if (interfaceType == null)
                return;

            graph.Configure(r =>
                            r.ForRequestedType(interfaceType)
                            .InterceptConstructionWith(new MyBuildInterceptor(type))
                            .TheDefaultIsConcreteType(type));
                        
            //family.AddInterceptor();
            //family.AddType(concreteType);
            //family.SetScopeTo(InstanceScope.Singleton);
        }
    }
}