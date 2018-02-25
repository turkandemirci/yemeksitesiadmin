using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSitesi
{
    public class NAutoComplete
    {
        public NAutoComplete()
        {

        }
        public NAutoComplete(string label)
        {
            this.label = label;
        }
        public NAutoComplete(string label, string value)
        {
            this.label = label;
            this.value = value;
        }
        public string label { get; set; }
        public string value { get; set; }
    }
}