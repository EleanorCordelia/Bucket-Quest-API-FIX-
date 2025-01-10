using System.Security.Claims;

namespace BucketQuestAPI.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst("email")?.Value;
        }

        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst("id")?.Value ?? string.Empty);
        }
    }
}