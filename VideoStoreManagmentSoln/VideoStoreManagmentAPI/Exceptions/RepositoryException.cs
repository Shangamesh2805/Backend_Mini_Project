using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class RepositoryException : Exception
    {
       
        public RepositoryException(string v, Exception ex)
        {
            
        }
        


    }
}