using ChatApp.Helpers;
using ChatApp.Models;
using ChatApp.Models.User;
using DbProvider;
using DbProvider.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ChatApp.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        bool RegisterUser(RegisterRequest model);
        User GetById(int id);
    }

    public class UserService : IUserService
    {

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            using MainContext context = new MainContext();

            var user = context.Users.Include(x => x.Messages).SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public bool RegisterUser(RegisterRequest model)
        {
            // TODO check user exist and validate email
            using MainContext context = new MainContext();

            User user = new User()
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username,
                RegistrationDate = DateTime.Now,
                Chats = new List<Chat>(context.Chats.Where(x => x.ChatType == ChatType.Global))
            };


            context.Users.Add(user);
            context.SaveChanges();

            return true;
        }

        public User GetById(int id)
        {
            using MainContext context = new MainContext();

            return context.Users.Include(x => x.Messages).FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
