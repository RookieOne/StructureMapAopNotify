using System.Windows;
using StructureMap;
using StructureMapAopNotify.StructureMap;
using StructureMapAopNotify.ViewModels;

namespace StructureMapAopNotify
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Container = new Container();
            Container.Configure(x =>
                                    {
                                        x.ForRequestedType<IService>()
                                            .TheDefaultIsConcreteType<MyService>();

                                        x.RegisterInterceptor(new MyInterceptor());
                                    });
        }
    }
}