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
    public class JoinRideService: IJoinRideService
    {
        private UserDbContext _userDbContext;

        public JoinRideService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public void JoinRide(JoinRideDTO JoinRideDTO, int id)
        {
            Signup user = new Signup();
            user.MemberId = id;

            var user1 = _userDbContext.Users.Where(x => x.MemberId == id).ToList();


            var join = new JoinRide()
            {
                StartLocation = JoinRideDTO.StartLocation,
                EndLocation = JoinRideDTO.EndLocation,
                StartDate = JoinRideDTO.StartDate,
                StartTime = JoinRideDTO.StartTime,
                SignupMemberId = user1[0].MemberId,
            };
            _userDbContext.Add(join);
            _userDbContext.SaveChangesAsync();
        }
    }
}
