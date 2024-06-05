using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class VideoNotFoundException : Exception
    {
        string msg;
        public VideoNotFoundException()
        {
            msg = "Video Not found in Catalog";
        }
        public override string Message => msg;

    }
}