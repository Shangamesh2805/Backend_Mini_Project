using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    public class NoOrderFounDException : Exception
    {
        string msg;
        public NoOrderFounDException()
        {
            msg = "No orderdetail found with given OrderID";
        }
        public override string Message => msg;

    }
}