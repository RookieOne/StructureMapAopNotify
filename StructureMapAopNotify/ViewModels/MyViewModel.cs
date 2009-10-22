using System.Windows.Input;
using StructureMapAopNotify.Commands;

namespace StructureMapAopNotify.ViewModels
{
    public class MyViewModel : BaseViewModel
    {
        public MyViewModel(IService service)
        {
            SaveCommand = new ActionCommand(OnSave);
        }

        string _Text2;

        public ICommand SaveCommand { get; set; }

        public virtual string Text { get; set; }

        public string Text2
        {
            get { return _Text2; }
            set
            {
                _Text2 = value;
                RaisePropertyChanged("Text2");
            }
        }

        void OnSave()
        {
        }
    }
}