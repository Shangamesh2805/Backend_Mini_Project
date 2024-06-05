using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class RepositoryException : Exception
    {
<<<<<<< HEAD
        private Exception ex;

        public RepositoryException(Exception ex)
        {
            this.ex = ex;
        }

=======
       
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
        public RepositoryException(string v, Exception ex)
        {
            
        }
        


    }
}