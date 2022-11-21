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
    public class VehicleRegistration : IVehicleRegistration
    {
        private readonly UserDbContext _userDbContext;
        public VehicleRegistration(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public void RegisterVehicle(VehicleDTO vehicleDTO, int memberId)
        {
            var vehicle = new Vehicle()
            {
                MemberId = memberId,
                VehicleName = vehicleDTO.VehicleName,
                VehicleType = vehicleDTO.VehicleType,
                VehicleNumber = vehicleDTO.VehicleNumber,
            };
            _userDbContext.Add(vehicle);
            _userDbContext.SaveChanges();
        }
    }
}
