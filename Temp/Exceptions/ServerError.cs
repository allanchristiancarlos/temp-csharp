using System;

namespace Temp.Exceptions
{
    public class ServerError : Exception
    {
        public ServerError()
            : base("Server error")
        {
            
        }
    }
}