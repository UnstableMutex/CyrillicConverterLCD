﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicConverterLCD.Common
{
    public interface IOneAddin
    {
        string DisplayName { get; }
        string Convert(string target);
    }

    public interface ICompositeAddin
    {
        IEnumerable<IOneAddin> Addins { get; }
    }

    public class JsonFileAddin : ICompositeAddin
    {
        private readonly string _folder;

        public JsonFileAddin(string folder)
        {
            _folder = folder;
        }

        public IEnumerable<IOneAddin> Addins { get; private set; }
    }

    public class FileDisplayInfo
    {
        public string DisplayName { get; set; }
        public Lett[] Letters { get; set; }
    }

    public class Lett
    {
        public string Letter { get; set; }
        public string Value { get; set; }
    }






     
     
     
}