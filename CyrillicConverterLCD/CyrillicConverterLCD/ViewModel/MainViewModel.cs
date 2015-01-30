using System.IO;
using System.Text;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace CyrillicConverterLCD.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string _text;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            Temp();
        }

        void Temp()
        {
            string s = "d";
            var bytearray = Encoding.UTF32.GetBytes(s);
        JsonSerializer ser=new JsonSerializer();
            TextWriter tw=new StreamWriter("sample.json");
            JsonWriter w =new JsonTextWriter(tw);
        }
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged();
            }
        }
    }
}