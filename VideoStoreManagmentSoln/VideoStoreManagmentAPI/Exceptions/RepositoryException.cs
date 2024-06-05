using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class RepositoryException : Exception
    {
        private Exception ex;

        public RepositoryException(Exception ex)
        {
            this.ex = ex;
        }

        public RepositoryException(string v, Exception ex)
        {
            
        }
        


    }
}