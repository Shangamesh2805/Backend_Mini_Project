using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class OrderDetailFoundException : Exception
    {
        string msg;
        public OrderDetailFoundException()
        {
            msg = "No orderdetail found with given OrderID";
        }
        public override string Message => msg;


    }
}