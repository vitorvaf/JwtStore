using System.Text;

namespace JwtStore.Core.Context.SharedCotext;

public static class StringExtension
{
    public static string ToBase64(this string value)
    {
        var plainTextBytes = Encoding.ASCII.GetBytes(value);
        return Convert.ToBase64String(plainTextBytes);
    }
}