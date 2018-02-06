using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftFramework.Web.Models.Base
{
    public class Paginacao
    {
        public bool _search { get; set; }
        public bool search { get; set; }
        public string nd { get; set; }
        public string rows { get; set; }
        public string page { get; set; }
        public string sidx { get; set; }
        public string sord { get; set; }
    }
}