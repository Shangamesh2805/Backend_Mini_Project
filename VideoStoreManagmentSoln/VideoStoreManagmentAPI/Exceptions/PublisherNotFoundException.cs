using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class PublisherNotFoundException : Exception
    {
        string msg;
        public PublisherNotFoundException()
        {
            msg = "No Publisher found with given PublisherID";
        }

        public override string Message => msg;


    }
}