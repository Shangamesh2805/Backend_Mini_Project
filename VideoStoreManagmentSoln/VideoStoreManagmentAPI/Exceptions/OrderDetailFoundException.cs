using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    public class NoOrderDetailFoundException : Exception
    {
        string msg;
        public NoOrderDetailFoundException()
        {
            msg = "No orderdetail found with given OrderID";
        }
        public override string Message => msg;


    }
}