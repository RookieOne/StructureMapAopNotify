using System.Windows;
using StructureMapAopNotify.ViewModels;

namespace StructureMapAopNotify
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            content.Content = App.Container.GetInstance<MyViewModel>();

            var vm = content.Content as MyViewModel;

            vm.PropertyChanged += (sender, e) =>
                                      {
                                          string s = e.PropertyName;
                                      };
        }
    }
}