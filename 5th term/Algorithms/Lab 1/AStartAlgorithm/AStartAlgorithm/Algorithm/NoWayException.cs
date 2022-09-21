using System;
using System.Runtime.Serialization;

namespace AStartAlgorithm.Algorithm
{
    [Serializable]
    internal class NoWayException : Exception
    {
        public NoWayException()
        {
        }

        public NoWayException(string message) : base(message)
        {
        }

        public NoWayException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoWayException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}