using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class CartItemEmptyException : Exception
    {
        string msg;
        public CartItemEmptyException()
        {
            msg = "No Cartitems Found";

        }
        public override string Message => msg;


    }
}