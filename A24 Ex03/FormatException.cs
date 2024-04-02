using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex03
{
    public class FormatException : Exception
    {
        public FormatException(string message)
            : base(message)
        {
        }
    }
}
