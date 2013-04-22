using System;

namespace Nancy.CORS
{
    public class CORSRequestException : Exception
    {
        public CORSRequestException(string message) : base (message)
        {
        }
    }
}