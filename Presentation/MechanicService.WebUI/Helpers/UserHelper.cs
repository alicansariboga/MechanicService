using System.IdentityModel.Tokens.Jwt;

namespace MechanicService.WebUI.Helpers
{
    public class UserHelper
    {
        public static string GetLoggedInUserName(HttpContext httpContext)
        {
            var headers = httpContext.Request.Headers;

            if (headers.ContainsKey("Authorization"))
            {
                var authorizationHeader = headers["Authorization"].FirstOrDefault();

                if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
                {
                    var token = authorizationHeader.Substring(7);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenS = tokenHandler.ReadToken(token) as JwtSecurityToken;

                    var username = tokenS?.Claims.FirstOrDefault(claim => claim.Type == "Username")?.Value;
                    return username;
                }
            }
            return null;

            // ON Controller
            //var username = UserHelper.GetLoggedInUserName(HttpContext);
            //ViewBag.Username = username;

        }
    }
}
