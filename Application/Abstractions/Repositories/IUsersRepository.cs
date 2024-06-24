namespace Application.Abstractions.Repositories
{
    public interface IUsersRepository
    {
        Task CreateUser(Domain.Entities.User user, CancellationToken cancellationToken);
        Task<Domain.Entities.User> GetUser(string email, CancellationToken cancellationToken);
        Task<IEnumerable<Domain.Entities.User>> GetUsers(CancellationToken cancellationToken);
        Task RemoveUser(Domain.Entities.User user, CancellationToken cancellationToken);
        Task UpdateUser(Domain.Entities.User user, CancellationToken cancellationToken);
    }
}
