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
    public class HostRideService : IHostRideService
    {
        
        private UserDbContext _userDbContext;
        public HostRideService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public void HostRide(HostedRidesDTO hostedRidesDTO)
        {
            var hosted = new HostedRides()
            {
                StartLocation = hostedRidesDTO.StartLocation,
                EndLocation = hostedRidesDTO.EndLocation,
                StartDate = hostedRidesDTO.StartDate,
                StartTime = hostedRidesDTO.StartTime,

            };
            _userDbContext.Add(hosted);
            _userDbContext.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
