using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class FeedBackNotFoundException : Exception
    {
        string msg;
        public FeedBackNotFoundException()
        {
            msg = "No Feedback found with given feedbackId";
        }
        public override string Message => msg;

    }
}