using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class ServiceException : Exception
    {
        public ServiceException(string v, Exception ex)
        {
        }

       
    }
}