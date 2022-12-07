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
    public class HostRideService :IHostRideService
    {

        private UserDbContext _userDbContext;

        public HostRideService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }


        public void HostRide(HostedRidesDTO hostedRidesDTO, int id)
        {
            Signup user = new Signup();
            user.MemberId = id;

            var user1 = _userDbContext.Users.Where(x => x.MemberId == id).ToList();
            var vehicles = _userDbContext.Vehicles.Where(x => x.VehicleId == hostedRidesDTO.VehicleId).ToList();

   
            var hosted = new HostedRides()
            {
                StartLocation = hostedRidesDTO.StartLocation,
                EndLocation = hostedRidesDTO.EndLocation,
                StartDate = hostedRidesDTO.StartDate,
                StartTime = hostedRidesDTO.StartTime,
                SignupMemberId = user1[0].MemberId,
                //VehicleVehicleId = user2[0].VehicleId,
                VehicleVehicleId = vehicles[0].VehicleId
            };
            _userDbContext.Add(hosted);
            _userDbContext.SaveChangesAsync();

        }
            
    }
        
}
