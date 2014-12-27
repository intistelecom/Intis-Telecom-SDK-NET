﻿using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class IncomingMessageException : SDKSerializationException
    {
        public IncomingMessageException(NameValueCollection parameters)
            : base(parameters){}

        public IncomingMessageException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}