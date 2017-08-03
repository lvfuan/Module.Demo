using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.Demo
{
    public static class StringExt
    {
        public static bool IsInt(this string str)
        {
            int i;
            return int.TryParse(str, out i); 
        }
    }
}
