using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Documents;
using CyrillicConverterLCD.Common;
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

        private void Temp()
        {
            string s = "d";
            var bytearray = Encoding.UTF32.GetBytes(s);
            JsonSerializer ser = new JsonSerializer();
            //using (TextWriter tw = new StreamWriter("test.json", false, Encoding.Unicode))
            //{

            //    FileDisplayInfo file = new FileDisplayInfo();
            //    file.DisplayName = "LCD";
            //    List<Lett> l = new List<Lett>();
            //    l.Add(new Lett() { Letter = "À", Value = @"\x41" });
            //    l.Add(new Lett() { Letter = "Á", Value = @"\xA0" });
            //    file.Letters = l.ToArray();
            //    var f = JsonConvert.SerializeObject(file, Formatting.Indented);
            //    tw.Write(f);
            //}  
            FileDisplayInfo fdi;
            using (TextReader tr=new StreamReader("test.json", Encoding.Unicode))
            {
              
                var str = tr.ReadToEnd();
              fdi=  JsonConvert.DeserializeObject<FileDisplayInfo>(str);
            }

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