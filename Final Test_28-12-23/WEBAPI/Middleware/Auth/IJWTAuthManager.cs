using Domain.Models;

namespace WEBAPI.Middleware.Auth
{
    public interface IJWTAuthManager
    {
        string GenerateJWT(Employee user);
    }
}
