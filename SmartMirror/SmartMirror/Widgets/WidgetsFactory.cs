using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SmartMirror
{
    class WidgetsFactory
    {
        public static UserControl Create(WidgetConfig widgetConfig)
        {
            UserControl result = null;
            switch (widgetConfig.Type)
            {
                case "Date":
                    result = new DateWidget();
                    break;
                case "OutlookEvents":
                    return null;
                default:
                    return null;
            }

            //Set width, height and position of our widget
            result.SetValue(Canvas.LeftProperty, widgetConfig.X);
            result.SetValue(Canvas.TopProperty, widgetConfig.Y);
            result.SetValue(FrameworkElement.WidthProperty, widgetConfig.Width);
            result.SetValue(FrameworkElement.HeightProperty, widgetConfig.Height);

            return result;
        }
    }
}