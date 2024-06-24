using Domain.Entities;

namespace Application.Abstractions.Services
{
    public interface IJWTService
    {
        string GenerateToken(User user);
    }
}
