using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Models.User;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _accountRepository;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
        private readonly IJWTService _jwtTokenService;

        public UserService(
            IMapper mapper,
            IUsersRepository accountRepository,
            IPasswordHasher<Domain.Entities.User> passwordHasher,
            IJWTService jwtTokenService)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }

        public async Task RegisterUser(RegisterUser registerUser, CancellationToken cancellationToken) 
        {
            var User = _mapper.Map<RegisterUser, Domain.Entities.User>(registerUser);

            var existedUser = await _accountRepository.GetUser(registerUser.Email, cancellationToken);

            if (existedUser != null) 
            {
                return;
            }

            var hashedPassword = _passwordHasher.HashPassword(User, registerUser.Password);
            User.Id = Guid.NewGuid();
            User.Role = UserRole.Admin;
            User.PasswordHash = hashedPassword;

           await _accountRepository.CreateUser(User, cancellationToken);
        }

        public async Task<string> LoginUser(LoginUser loginUser, CancellationToken cancellationToken) 
        {
            var user = await _accountRepository.GetUser(loginUser.Email, cancellationToken);

            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUser.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid email or password");
            }

            var token = _jwtTokenService.GenerateToken(user);
            
            return token;
        }
        
        public async Task<IEnumerable<Domain.Entities.User>> GetAll(CancellationToken cancellationToken)
        {
            return await _accountRepository.GetUsers(cancellationToken);
        }

        public async Task<Domain.Entities.User> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetUser(email, cancellationToken);
        }

        public async Task<Guid> UpdateUser(Domain.Entities.User user, CancellationToken cancellationToken) 
        {
            var userToUpdate = await _accountRepository.GetUser(user.Email, cancellationToken);

            userToUpdate.Role = user.Role;

            await _accountRepository.UpdateUser(userToUpdate, cancellationToken);

            return userToUpdate.Id;
        }

        public async Task RemoveUser(string email, CancellationToken cancellationToken)
        {
            var userToRemove = await _accountRepository.GetUser(email, cancellationToken);

            await _accountRepository.RemoveUser(userToRemove, cancellationToken);
        }
    }
}
