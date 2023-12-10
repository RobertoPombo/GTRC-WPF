using GTRC_Basics;

namespace GTRC_WPF.ViewModels
{
    public class MainVM : ObservableObject
    {
        public MainVM()
        {
            GlobalValues.NewLogText += NewLogText;
        }

        public string CurrentLogText { get { return GlobalValues.CurrentLogText; } set { } }

        public void NewLogText() { RaisePropertyChanged(nameof(CurrentLogText)); }
    }
}
