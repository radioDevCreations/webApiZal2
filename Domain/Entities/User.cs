using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
