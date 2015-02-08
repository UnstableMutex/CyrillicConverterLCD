using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CyrillicConverterLCD.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

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
        private readonly IEnumerable<IOneAddin> _addins;

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
            _addins = GetAddins();
            DisplayList = _addins.Select(x => x.DisplayName);
            SelectedDisplay = DisplayList.FirstOrDefault();
            CopyCommand = new RelayCommand(Copy);
        }
        public ICommand CopyCommand { get; private set; }
        private void Copy()
        {
            Clipboard.SetText(Result);
        }
        private IEnumerable<IOneAddin> GetAddins()
        {
            const string addinsfolder = "Addins";
            var addinsdir = new DirectoryInfo(addinsfolder);
            var addindirs = addinsdir.GetDirectories();
            var addinscatalog = new AggregateCatalog();
            foreach (var di in addindirs)
            {
                var dc = new DirectoryCatalog(Path.Combine(addinsfolder, di.Name));
                addinscatalog.Catalogs.Add(dc);
            }
            var c = new CompositionContainer(addinscatalog);
            c.ComposeParts();
            var cas = c.GetExportedValues<ICompositeAddin>();
            var oneaddins = c.GetExportedValues<IOneAddin>();
            var addins = new List<IOneAddin>();
            foreach (var ca in cas)
            {
                addins.AddRange(ca.Addins);
            }
            addins.AddRange(oneaddins);
            return addins;
        }
        public IEnumerable<string> DisplayList { get; set; }
        public string SelectedDisplay { get; set; }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Calc(_text);
                RaisePropertyChanged("Result");
            }
        }
        private void Calc(string text)
        {
            var selAddin = _addins.SingleOrDefault(x => x.DisplayName == SelectedDisplay);
            if (selAddin != null)
            {
                Result = selAddin.Convert(text);
            }
        }
        public string Result { get; private set; }
    }
}