using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex03
{
    public class ArgumentException : Exception
    {
        public ArgumentException(string message)
            : base(message)
        {
        }
    }
}
