using Azure_AD_TEST.Models.ViewModels;
using System.Security.Claims;

namespace Azure_AD_TEST.HelpingClasses
{
    public class AuthenticationHandler
    {

        /// <summary>
        /// Get the user name, user domain and email of the user from the authentication claims
        /// </summary>
        /// <param name="user">Auth Claims</param>
        /// <returns>Azure AD</returns>
        public static UserAzureAD GetUserOnAzureAd(ClaimsPrincipal user)
        {
            var preferredUsernameClaim = user.Claims.FirstOrDefault(c => c.Type.Equals("preferred_username"));
            if (preferredUsernameClaim != null)
            {
                return new UserAzureAD
                {
                    user_name = user.Claims.FirstOrDefault(p => p.Type.Equals("name")).Value,
                    user_email = preferredUsernameClaim.Value,
                    user_domain = string.Format(@"{0}", preferredUsernameClaim.Value.Split('@')[0])
                };
            }
            return null; // Or throw an exception if preferred_username claim is required
        }
    }
}
