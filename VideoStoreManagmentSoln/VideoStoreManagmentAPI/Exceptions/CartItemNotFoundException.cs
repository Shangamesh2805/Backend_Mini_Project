using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class CartItemNotFoundException : Exception
    {
        string msg;
        public CartItemNotFoundException()
        {
            msg = "CartItem not found";
        }
        public override string Message => msg;


    }
}