namespace EL.FredericoRibeiro.Infrastructure
{
    using EL.FredericoRibeiro.Domain.Interfaces;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.Security.Claims;

    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public User(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
