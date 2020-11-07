using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Lib.Exceptions
{
    [Serializable]
    public class UserReadableException : Exception
    {
        public UserReadableException()
        {
        }

        public UserReadableException(string message) : base(message)
        {
        }

        public UserReadableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserReadableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
