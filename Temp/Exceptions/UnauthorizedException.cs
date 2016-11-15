using System;

namespace Temp.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("Invalid api request")
        {
            
        }
    }
}