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
    }
}
