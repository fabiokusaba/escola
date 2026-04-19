using System.Security.Claims;

namespace Escola.Infra.Ioc;

public static class ClaimsPrincipalExtension
{
    public static int GetUserId(this ClaimsPrincipal principal)
    {
        var userIdClaim = principal.FindFirst("id");

        if (userIdClaim is not null && int.TryParse(userIdClaim.Value, out int userId))
            return userId;

        throw new Exception("User ID Claim não encontrado ou inválido");
    }
}