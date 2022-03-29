namespace UCS.WebApi.Models.User
{
    public class AuthenticateResponse
    {
        public DbProvider.Models.User User { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(DbProvider.Models.User user, string token)
        {
            User = user;
            Token = token;
        }
    }
}
