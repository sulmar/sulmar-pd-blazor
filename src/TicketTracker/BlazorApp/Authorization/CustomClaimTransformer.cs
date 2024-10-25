using System.Security.Claims;
using System.Security.Principal;
using Domain.Abstractions;
using Microsoft.AspNetCore.Authentication;

namespace Authorization;


public class CustomClaimsTransformation(IUserRepository repository) : IClaimsTransformation
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        Console.WriteLine("CustomClaimTransformer");

        var newIdentity = new ClaimsIdentity();

        // TODO: Pobierz z repository
        newIdentity.AddClaim(new Claim(ClaimTypes.Role, "foo"));
        newIdentity.AddClaim(new Claim(ClaimTypes.Role, "boo"));
        newIdentity.AddClaim(new Claim(ClaimTypes.Role, "dev"));

        newIdentity.AddClaim(new Claim("Group", "A"));
        newIdentity.AddClaim(new Claim("Group", "B"));

        newIdentity.AddClaim(new Claim("scope", "ticket-tracker"));

        principal.AddIdentity(newIdentity);

        return Task.FromResult(principal);
    }
}
