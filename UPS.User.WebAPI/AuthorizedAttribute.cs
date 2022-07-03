using Microsoft.AspNetCore.Mvc;

namespace UPS.User.WebAPI
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute()
            : base(typeof(AuthorizeActionFilter))
        {

        }
    }
}
