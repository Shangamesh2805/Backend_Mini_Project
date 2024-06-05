using Microsoft.VisualBasic;
using System.Runtime.Serialization;

[Serializable]
public  class CartException : Exception
{

    string msg;
    public CartException()
    {
        msg = "An exception occured while getting the cart ";

    }
    public  override string Message => msg;


}