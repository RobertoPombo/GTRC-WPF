using System.Globalization;
using System.Windows;

namespace GTRC_WPF
{
    public static class GlobalWinValues
    {
        public static readonly double screenWidth = SystemParameters.PrimaryScreenWidth;
        public static readonly double screenHeight = SystemParameters.FullPrimaryScreenHeight + SystemParameters.WindowCaptionHeight;

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
    }
}
