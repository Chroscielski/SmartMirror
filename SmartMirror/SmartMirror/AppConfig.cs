using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMirror
{
    public class AppConfig
    {
        public string Text { get; set; }
        public ReadOnlyCollection<WidgetConfig> Widgets { get; set; }
    }
}