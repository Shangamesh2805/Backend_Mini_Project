using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
<<<<<<< HEAD
    public class NoCartItemWithGivenIDException : Exception
=======
    internal class NoCartItemWithGivenIDException : Exception
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
    {
        string msg;
        public NoCartItemWithGivenIDException()
        {
            msg = "No CartItem found with Given ID";
        }
        public override string Message => msg;


    }
}