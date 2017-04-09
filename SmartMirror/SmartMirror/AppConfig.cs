using System.Collections.ObjectModel;

namespace SmartMirror
{
    public class AppConfig
    {
        public string Text { get; set; }
        public ReadOnlyCollection<WidgetConfig> Widgets { get; set; }
    }
}