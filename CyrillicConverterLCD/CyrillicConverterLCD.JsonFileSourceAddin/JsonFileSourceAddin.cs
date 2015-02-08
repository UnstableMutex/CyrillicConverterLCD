using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CyrillicConverterLCD.Common;
using Newtonsoft.Json;
namespace CyrillicConverterLCD.JsonFileSourceAddin
{
    [Export(typeof(ICompositeAddin))]
    public class JsonFileAddin : ICompositeAddin
    {
      
        public JsonFileAddin()
        {
          
            FindFiles();
        }
        private void FindFiles()
        {
            var assdir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var files = Directory.GetFiles(assdir, "*.json");
            var addins = new List<IOneAddin>();
            foreach (var file in files)
            {
                try
                {
                    OneJsonFileSource s = new OneJsonFileSource(file);
                    addins.Add(s);
                }
                catch (Exception)
                {
                }
            }
            Addins = addins;
        }
        public IEnumerable<IOneAddin> Addins { get; private set; }
    }
    class OneJsonFileSource : IOneAddin
    {
        private readonly string _jsonfilename;
        private FileDisplayInfo fdi;
        public OneJsonFileSource(string jsonfilename)
        {
            _jsonfilename = jsonfilename;
            Read(_jsonfilename);
        }
        private void Read(string jsonfilename)
        {
            var s = File.ReadAllText(jsonfilename, Encoding.Unicode);
            fdi = JsonConvert.DeserializeObject<FileDisplayInfo>(s);
        }
        public string DisplayName { get { return fdi.DisplayName; } }
        public string Convert(string target)
        {
            string result = string.Empty;
            foreach (var ch in target)
            {
                if (Regex.IsMatch(ch.ToString(), @"^[a-zA-Z0-9\s]$"))
                {
                    result += ch;
                }
                else
                {
                    var letter = fdi.Letters.SingleOrDefault(x => x.Letter == ch);
                    if (letter != null)
                    {
                        result += letter.Value;
                    }
                    else
                    {
                        result +=fdi.ErrorSymbol;
                    }
                }
            }
            return result;
        }
    }
}
