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
    public class HostRideService : GenericRepositoryOperations<HostedRidesDTO>,IHostRideService
    {
        
        private UserDbContext _userDbContext;
        private IGenericRepositoryOperation<HostedRidesDTO> _genericRepositoryOperation;
        public HostRideService(UserDbContext userDbContext, IGenericRepositoryOperation<HostedRidesDTO> genericRepositoryOperation):base (userDbContext)
        {
            _userDbContext = userDbContext;
            _genericRepositoryOperation = genericRepositoryOperation;
        }


        public void HostRide(HostedRidesDTO hostedRidesDTO)
        {

            _genericRepositoryOperation.Add(hostedRidesDTO);
            _genericRepositoryOperation.Save();
            //var hosted = new HostedRides()
            //{
            //    StartLocation = hostedRidesDTO.StartLocation,
            //    EndLocation = hostedRidesDTO.EndLocation,
            //    StartDate = hostedRidesDTO.StartDate,
            //    StartTime = hostedRidesDTO.StartTime,
            //    MemberId = hostedRidesDTO.MemberId

            //};
            //_userDbContext.Add(hosted);
            //_userDbContext.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
