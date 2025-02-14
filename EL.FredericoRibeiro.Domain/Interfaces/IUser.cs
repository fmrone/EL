﻿namespace EL.FredericoRibeiro.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Security.Claims;

    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
