using System;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SmartMirror
{
    public sealed partial class DateWidget : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Date { get; set; }

        public DateWidget()
        {
            InitializeComponent();
            DataContext = this;

            Date = DateTime.Now.ToString();

            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Refresh;
            timer.Start();
        }

        private void Refresh(object sender, object e)
        {
            Date = DateTime.Now.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Date"));
        }
    }
}
