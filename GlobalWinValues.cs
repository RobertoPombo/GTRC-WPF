using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace GTRC_WPF
{
    public static class GlobalWinValues
    {
        public static readonly double screenWidth = SystemParameters.PrimaryScreenWidth;
        public static readonly double screenHeight = SystemParameters.FullPrimaryScreenHeight + SystemParameters.WindowCaptionHeight;
        public static Brush StateOff { get { return WpfColors.List[0]; } }
        public static Brush StateOn { get { return WpfColors.List[3]; } }
        public static Brush StateWait { get { return WpfColors.List[7]; } }
        public static Brush StateRun { get { return WpfColors.List[6]; } }
        public static Brush StateRunWait { get { return WpfColors.List[4]; } }

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
        }
    }
}
