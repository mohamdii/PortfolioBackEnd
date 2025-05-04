using Microsoft.Identity.Client;

namespace Portfolio.API.Services
{
    public interface IJwtService
    {
        public string GenerateToken(string userId, string userName, List<string> roles);
    }
}
