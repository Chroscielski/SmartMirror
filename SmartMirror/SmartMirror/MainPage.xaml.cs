using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.UI.Animations;

namespace SmartMirror
{
    public sealed partial class MainPage : Page
    {
        private SpeechManager _speechManager = null;
        public MainPage()
        {
            this.InitializeComponent();

            //Init SpeechManager
            _speechManager = new SpeechManager();
            _speechManager.Init();

            //Set our delegates
            _speechManager.Login += FadeIn;
            _speechManager.Logout += FadeOut;

            //Create widgets
            foreach (var widgetConfig in App.Config.Widgets)
            {
                var widget = WidgetsFactory.Create(widgetConfig);
                canvas.Children.Add(widget);
            }
        }

        public async void FadeIn()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(async () =>
            {
                await this.Fade(value: 1.0f, duration: 1000, delay: 0).StartAsync();
            });
        }

        public async void FadeOut()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(async () =>
            {
                await this.Fade(value: 0.0f, duration: 1000, delay: 0).StartAsync();
            });
        }
    }
}