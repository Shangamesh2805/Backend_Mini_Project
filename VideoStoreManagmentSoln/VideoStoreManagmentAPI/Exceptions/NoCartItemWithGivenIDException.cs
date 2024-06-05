using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    public class NoCartItemWithGivenIDException : Exception
    {
        string msg;
        public NoCartItemWithGivenIDException()
        {
            msg = "No CartItem found with Given ID";
        }
        public override string Message => msg;


    }
}