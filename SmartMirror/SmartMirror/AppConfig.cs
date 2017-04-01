using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMirror
{
    public class AppConfig
    {
        public string Text { get; set; }
        public List<WidgetConfig> Widgets { get; set; }
    }
}