namespace Warehouse;
using System.Text;

public class Util
{
    public static string GetBase64(string text){
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
    }
}
