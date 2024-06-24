namespace Infrastructure.Authentication
{
    public class JWT
    {
        public string JwtKey { get; set; }
        public int JwtExpireDay { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
    }
}
