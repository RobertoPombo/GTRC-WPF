using System.Globalization;
using System.Windows;
using System.Windows.Media;

using GTRC_Basics;

namespace GTRC_WPF
{
    public static class GlobalWinValues
    {
        public static readonly double screenWidth = SystemParameters.PrimaryScreenWidth;
        public static readonly double screenHeight = SystemParameters.FullPrimaryScreenHeight + SystemParameters.WindowCaptionHeight;
        public static Dictionary<StateBackgroundWorker, Brush> ColorsStateBackgroundWorker = new()
        {
            { StateBackgroundWorker.Off, WpfColors.List[0] },
            { StateBackgroundWorker.On, WpfColors.List[3] },
            { StateBackgroundWorker.Wait, WpfColors.List[7] },
            { StateBackgroundWorker.Run, WpfColors.List[6] },
            { StateBackgroundWorker.RunWait, WpfColors.List[4] }
        };

        public static void SetCultureInfo()
        {
            var newCulture = new CultureInfo(Thread.CurrentThread.CurrentUICulture.Name);
            newCulture.DateTimeFormat.FullDateTimePattern = "dd MM yyyy HH mm ss";

            CultureInfo.DefaultThreadCurrentCulture = newCulture;
            CultureInfo.DefaultThreadCurrentUICulture = newCulture;

            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    System.Windows.Markup.XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        public static void UpdateWpfColors(Window _window)
        {
            for (int index = 0; index < WpfColors.List.Count; index++)
            {
                _window.Resources["color" + index.ToString()] = WpfColors.List[index];
            }
            ColorsStateBackgroundWorker = new()
            {
                { StateBackgroundWorker.Off, WpfColors.List[0] },
                { StateBackgroundWorker.On, WpfColors.List[3] },
                { StateBackgroundWorker.Wait, WpfColors.List[7] },
                { StateBackgroundWorker.Run, WpfColors.List[6] },
                { StateBackgroundWorker.RunWait, WpfColors.List[4] }
            };
            OnStateBackgroundWorkerColorsUpdated();
        }

        public static event Notify? StateBackgroundWorkerColorsUpdated;

        public static void OnStateBackgroundWorkerColorsUpdated() { StateBackgroundWorkerColorsUpdated?.Invoke(); }
    }
}
