using System;

namespace A24_Ex03
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(string message)
            : base(message)
        {
        }

        public ValueOutOfRangeException(string message, double min, double max)
        : base(message + " Min: " + min + ", Max: " + max)
        {
        }

        public ValueOutOfRangeException(string message, double min)
       : base(message + " Min: " + min)
        {
        }
    }
}
