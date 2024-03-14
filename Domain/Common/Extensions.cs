using Microsoft.AspNetCore.Http;

namespace Domain.Common
{
    public static class Extensions
    {
        public static int GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            string result = httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
            return Convert.ToInt32(result);
        }
        public static string GetUserName(this IHttpContextAccessor httpContextAccessor)
        {
            string result = httpContextAccessor.HttpContext.User.FindFirst("Email").Value;
            return result;
        }

        public static string GetFileExtension(this string base64String)
        {
            var data = base64String.Substring(0, 17);


            if (data.Contains("IVBOR"))
                return "png";
            else if (data.Contains("IVBOR"))
                return "jpg";


            else
                return string.Empty;





        }
    }
}
