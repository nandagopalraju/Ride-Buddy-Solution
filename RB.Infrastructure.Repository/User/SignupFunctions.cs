using AutoMapper;
using RB.Core.Application.DTO;
using RB.Core.Application.Interface;
using RB.Core.Domain.Models;
using RB.Infrastructure.Repository.Services.User.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.Repository.User
{
    public class SignupFunctions : ISignupFunctions
    {
        private readonly UserDbContext _userDbContext;
        private readonly ISignupValidations _signupValidations;
        private readonly IMapper _mapper;
        public SignupFunctions(UserDbContext userDbContext, ISignupValidations signupValidations, IMapper mapper)
        {
            _userDbContext = userDbContext;
            _signupValidations = signupValidations;
            _mapper = mapper;
        }

        public void SignUp(SignupDTO signupDTO)
        {
            _signupValidations.CreatePasswordHash(signupDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new TempSignup
            {
                Name = signupDTO.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = signupDTO.Email,
                Gender = signupDTO.Gender,
                Number = signupDTO.Number,
                Department = signupDTO.Department,
                EmployeeId = signupDTO.EmployeeId,
                Role = signupDTO.Role,
            };
            _userDbContext.TempUsers.Add(user);
            _userDbContext.SaveChanges();
        }
        public List<SignupDTO> UserDetails()
        {

            var data = _mapper.Map<List<Signup>, List<SignupDTO>>(_userDbContext.Users.ToList());
            return data;
            
        }
    }
}
