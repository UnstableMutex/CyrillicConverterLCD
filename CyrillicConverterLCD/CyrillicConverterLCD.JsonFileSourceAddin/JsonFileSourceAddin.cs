using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyrillicConverterLCD.Common;

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
}
