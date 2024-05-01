namespace Warehouse;
using System.Text;

public class Util
{
    public readonly static string SESSION_USER_NAME = "UserName";
    public readonly static string SESSION_FULL_NAME = "FullName";
    public readonly static string SESSION_USER_ROLE = "Role";
    public readonly static string SESSION_USER_ROLE_NAME = "RoleName";

    public readonly static string ROLE_ADMIN = "ADM";
    public readonly static string ROLE_SUPER_ADMIN = "SA";
    public readonly static string ROLE_OPERATOR = "OPR";

    public static string GetBase64(string text){
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
    }

    public static string StringFromBase64(string text)
    {
        var data = Convert.FromBase64String(text);
        return Encoding.UTF8.GetString(data);
    }

    public static string RoleName(string code)
    {
        switch (code)
        {
            case "SA":
                return "Super Admin";
            case "ADM":
                return "Admin";
            case "OPR":
                return "Operator";
            default:
                return "Guest";
        }
    }
}
