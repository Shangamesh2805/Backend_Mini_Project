// VideoRepository.cs

using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]

    public class NoPublisherWithGivenIDException : Exception
    {
        string msg;
        public NoPublisherWithGivenIDException()
        {
            msg = "No Publisher found with given ID";
        }

        public override string Message => msg;


    }
}