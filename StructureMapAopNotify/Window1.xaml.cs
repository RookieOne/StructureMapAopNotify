using System;
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
            try
            {
                InitializeComponent();

                content.Content = App.Container.GetInstance<IMyViewModel>();

                var vm = content.Content as MyViewModel;

                vm.PropertyChanged += (sender, e) =>
                {
                    string s = e.PropertyName;
                };
            }
            catch (Exception ex)
            {               
                throw ex;
            }

        }
    }
}