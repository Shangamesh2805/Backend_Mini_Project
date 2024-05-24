using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    public class CartEmpytyException : Exception
    {
        private string msg;
        public CartEmpytyException()
        {
            msg = "No Video Added to Cart";
        }
        public override string Message => msg;

    }
}