using RB.Core.Application.DTO;
using RB.Core.Application.Interface;
using RB.Infrastructure.Repository.Services.User.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.Repository.User
{
    public class LoginService : ILoginService
    {
        private readonly ISignupValidations _signupValidations;
        private readonly UserDbContext _userDbContext;
        public LoginService(ISignupValidations signupValidations, UserDbContext userDbContext)
        {
            _signupValidations = signupValidations;
            _userDbContext = userDbContext;
        }
        public string Login(LoginDTO loginDTO)
        {
            var user = _userDbContext.Users.FirstOrDefault(u => u.Email == loginDTO.Email);
            if (user == null)
            {
                return "user not found";
            }
            if (! _signupValidations. VerifyPasswordHash(loginDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return "wrong password";
            }

            string token = _signupValidations.CreateToken(user);

            return token;

        }
    }
}
