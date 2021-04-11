using System;

namespace Business.Services.CustomException
{
    public class NotImplementedException : Exception
    {
        public NotImplementedException(string message) : base(message)
        {
        }
    }
}
