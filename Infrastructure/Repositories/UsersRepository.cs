using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsersRepository(AppDbContext context) : IUsersRepository
    {
        private readonly AppDbContext _context = context;
 
        public async Task CreateUser(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<User> GetUser(string email, CancellationToken cancellationToken)
        {
            var User = await _context.Users
               .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            return User;
        }

        public async Task UpdateUser(User user, CancellationToken cancellationToken)
        {
             _context.Users.Update(user);       
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveUser(User user, CancellationToken cancellationToken)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken)
        {
            var User = await _context.Users
               .ToListAsync(cancellationToken);

            return User;
        }
    }
}
