using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
<<<<<<< HEAD
    public class NoOrderDetailFoundException : Exception
    {
        string msg;
        public NoOrderDetailFoundException()
=======
    internal class OrderDetailFoundException : Exception
    {
        string msg;
        public OrderDetailFoundException()
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
        {
            msg = "No orderdetail found with given OrderID";
        }
        public override string Message => msg;


    }
}