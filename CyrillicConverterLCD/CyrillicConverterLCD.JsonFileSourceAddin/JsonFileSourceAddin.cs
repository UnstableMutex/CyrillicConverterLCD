using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
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
        private readonly string _folder;

        public JsonFileAddin(string folder)
        {
            _folder = folder;
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
          fdi=   JsonConvert.DeserializeObject<FileDisplayInfo>(s);
        }

        public string DisplayName { get; private set; }
        public string Convert(string target)
        {
            string result = string.Empty;
            foreach (var ch in target)
            {
                if (Regex.IsMatch(ch.ToString(), @"^[a-zA-Z0-9]$"))
                {
                    result += ch;
                }
                else
                {
                 var letter=   fdi.Letters.SingleOrDefault(x => x.Letter == ch);
                    //обработать нулреференс
                  result+=  letter.Value;
                }
            }
        }
    }
}
