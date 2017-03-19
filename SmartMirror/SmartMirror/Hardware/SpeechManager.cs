using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Media.SpeechRecognition;

namespace SmartMirror
{
    class SpeechManager
    {
        //Delegates to inject methods
        public delegate void LoginDel();
        public LoginDel Login;

        public delegate void LogoutDel();
        public LogoutDel Logout;

        //Our keyword to invoke voice commands
        private const string KeyWord = "mirror ";
            
        //Windows.Media.SpeechRecognition namespace
        private SpeechRecognizer _speechRecognizer = null;

        private void AddConstraint(IEnumerable<string> words, string tag)
        {
            //Adding a new phrase activating specified method
            _speechRecognizer.Constraints.Add(
            //Two parameters:
            //first - a list of phrases activating defined constraint
            //second - a tag which unifies all the commands that can be used into one string
            new SpeechRecognitionListConstraint(
                //Iterate through all words and add a keyword prefix
                words.Select(word => KeyWord + word),
                tag));
        }

        public async void Init()
        {
            //Just in case
            if (_speechRecognizer == null)
            {
                _speechRecognizer = new SpeechRecognizer();
            }

            //Invoke AddConstraint method with a list of activation words and a tag
            AddConstraint(new[] { "hello", "login", "show" }, "login");
            AddConstraint(new[] { "logout", "quit", "hide", "exit" }, "logout");

            //Injecting constraints into speechRecognizer
            var compilationResult = await _speechRecognizer.CompileConstraintsAsync();

            //speechRecognizer.ContinuousRecognitionSession.AutoStopSilenceTimeout = TimeSpan.MaxValue;
            
            //Setting the method invoked on every result from microphone listener
            _speechRecognizer.ContinuousRecognitionSession.ResultGenerated +=
                ContinuousRecognitionSession_ResultGenerated;

            //Starting recognizer
            await _speechRecognizer.ContinuousRecognitionSession.StartAsync();
        }

        private void ContinuousRecognitionSession_ResultGenerated(SpeechContinuousRecognitionSession sender,
            SpeechContinuousRecognitionResultGeneratedEventArgs args)
        {
            //Just in case
            if (args.Result.Text == "")
            {
                return;
            }

            //Invoking delegates in case of specified tags
            if (args.Result.Constraint.Tag == "login")
            {
                //Check if method exists and invoke it
                Login?.Invoke();
            }
            else if (args.Result.Constraint.Tag == "logout")
            {
                Logout?.Invoke();
            }
        }
    }
}