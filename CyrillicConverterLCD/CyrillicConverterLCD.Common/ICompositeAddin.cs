using System.Collections.Generic;

namespace CyrillicConverterLCD.Common
{
    public interface ICompositeAddin
    {
        IEnumerable<IOneAddin> Addins { get; }
    }
}