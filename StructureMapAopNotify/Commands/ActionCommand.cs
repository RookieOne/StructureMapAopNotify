using System;
using System.Windows.Input;

namespace StructureMapAopNotify.Commands
{
    public class ActionCommand : ICommand
    {
        public ActionCommand(Action action)
        {
            _Action = action;
        }

        readonly Action _Action;

        public void Execute(object parameter)
        {
            _Action.Invoke();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}