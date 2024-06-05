using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class ServiceAccessException : Exception
    {
        public ServiceAccessException()
        {
        }

        public ServiceAccessException(string? message) : base(message)
        {
        }

        public ServiceAccessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ServiceAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}