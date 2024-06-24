using Application.Models.User;

namespace Application.Abstractions.Services
{
    public interface IUserService
    {
        Task RegisterUser(RegisterUser registerUser, CancellationToken cancellationToken);
        Task<string> LoginUser(LoginUser loginUser, CancellationToken cancellationToken);
        Task<Guid> UpdateUser(Domain.Entities.User user, CancellationToken cancellationToken);
        Task RemoveUser(string email, CancellationToken cancellationToken);
        Task<IEnumerable<Domain.Entities.User>> GetAll(CancellationToken cancellationToken);
        Task<Domain.Entities.User> GetUserByEmail(string email, CancellationToken cancellationToken);
    }
}
