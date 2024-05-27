using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class OrderNotFoundException : Exception
    {
        private string msg;
        public OrderNotFoundException()
        {
            msg = "No User Found with given UserID ";
        }
        public override string Message => msg;
    }
}