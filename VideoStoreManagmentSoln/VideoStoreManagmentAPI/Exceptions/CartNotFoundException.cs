using System.Runtime.Serialization;

namespace VideoStoreManagmentAPI.Exceptions
{
    [Serializable]
   

        public class CartNotFoundException : Exception
        {
            public CartNotFoundException(int cartId)
                : base($"Cart with ID {cartId} was not found.")
            {
            }
        }


    }
