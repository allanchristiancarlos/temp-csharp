using System;

namespace Temp.Exceptions
{
    public class DataUnavailableException : Exception
    {
        public DataUnavailableException()
            : base("Data unavailable")
        {
            
        }
    }
}