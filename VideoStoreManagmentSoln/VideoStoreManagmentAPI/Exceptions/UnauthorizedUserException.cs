using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class UnauthorizedUserException : Exception
    {
        string msg;
        public UnauthorizedUserException()
        {
            msg = "Invalid username or password";
        }
        public override string Message =>msg;


    }
}