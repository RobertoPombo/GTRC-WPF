using System.Windows.Input;

namespace GTRC_WPF
{
    public class UICmd : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        readonly Action<object>? execute;

        public UICmd(Action<object> _execute)
        {
            execute = _execute;
        }

        public void Execute(object? parameter)
        {
            execute?.Invoke(parameter);
        }

        public bool CanExecute(object? parameter) { return true; }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
