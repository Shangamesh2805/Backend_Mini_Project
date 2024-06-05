using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
<<<<<<< HEAD
    public class UserNotFoundException : Exception
    {
        private string msg;
        public UserNotFoundException()
=======
    internal class OrderNotFoundException : Exception
    {
        private string msg;
        public OrderNotFoundException()
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
        {
            msg = "No User Found with given UserID ";
        }
        public override string Message => msg;
    }
}