using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace LinqToXML
{
    public static class Extensions
    {
        public static double ReturnTotal(this XElement xelem)
        {
            double total = 0;
            foreach(XElement e in xelem.Descendants("total"))
                total += Convert.ToDouble(e.Value);
            return total;
        }
    }
}
