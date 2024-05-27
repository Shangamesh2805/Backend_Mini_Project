using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class OrderNotFounDException : Exception
    {
        string msg;
        public OrderNotFounDException()
        {
            msg = "No orderdetail found with given OrderID";
        }
        public override string Message => msg;

    }
}