using System.Text;

namespace WebApp.Helpers
{
    public static class EncoderHelper
    {
        public static string ToBase64(this string value) =>
        Convert.ToBase64String(
                Encoding.ASCII.GetBytes(value));
    }
}
