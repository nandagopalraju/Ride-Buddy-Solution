using RB.Core.Application.DTO;
using RB.Core.Application.Interface;
using RB.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.Repository.User
{
    public class SignupConfirmationService : ISignupConfirmation
    {
        private readonly UserDbContext _userDbContext;
        public SignupConfirmationService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public void Register(string email)
        {
            var user1 = _userDbContext.TempUsers.Where(x => x.Email == email).ToList();
            Signup user = new Signup()
            {
                Email = user1[0].Email,
                Department = user1[0].Department,
                Name = user1[0].Name,
                EmployeeId = user1[0].EmployeeId,
                PasswordHash = user1[0].PasswordHash,
                PasswordSalt = user1[0].PasswordSalt,
                Gender = user1[0].Gender,
                LicenceImageName = user1[0].LicenceImageName,
                Number = user1[0].Number,
                Role = user1[0].Role

            };
            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();

        }
    }
}
