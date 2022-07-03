using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UPS.User.WebAPI
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {

        private readonly string _authorizationToken;
        public AuthorizeActionFilter(IConfiguration configuration)
        {
            _authorizationToken = configuration.GetValue<string>("Access:AuthToken");
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var auth = context.HttpContext.Request.Headers["Authorization"];
            var token = auth.FirstOrDefault(x => x.StartsWith("Bearer"));
            if (token == null)
            {
                context.Result = new UnauthorizedResult();
            }
            if (token?.Replace("Bearer ", string.Empty) != _authorizationToken)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
