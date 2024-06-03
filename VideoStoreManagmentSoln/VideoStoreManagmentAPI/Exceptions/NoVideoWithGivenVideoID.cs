using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    public class NoVideoWithGivenVideoIDException : Exception
    {
        private string msg;
        public NoVideoWithGivenVideoIDException()
        {
            msg = "No Video Found with given VideoID is in CART";
        }
        public override string Message => msg;
    }
}