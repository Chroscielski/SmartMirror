using Windows.UI.Xaml.Controls;
using System.Diagnostics;

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
            _speechManager.Login += HelloFunc;
            _speechManager.Logout += GoodbyeFunc;

            Debug.WriteLine(App.Config.Text);
        }

        public void HelloFunc()
        {
            Debug.WriteLine("Hello");
        }
        public void GoodbyeFunc()
        {
            Debug.WriteLine("Goodbye");
        }
    }
}