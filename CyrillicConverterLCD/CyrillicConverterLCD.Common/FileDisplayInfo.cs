using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicConverterLCD.Common
{
    public class FileDisplayInfo
    {
        public string DisplayName { get; set; }
        public Lett[] Letters { get; set; }
    }
}
