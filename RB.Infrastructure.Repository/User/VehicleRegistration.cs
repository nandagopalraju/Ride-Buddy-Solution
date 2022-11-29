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
    public class VehicleRegistration : GenericRepositoryOperations<Vehicle>, IVehicleRegistration
    {
        private readonly UserDbContext _userDbContext;
        private IGenericRepositoryOperation<Vehicle> _genericRepositoryOperation;
        public VehicleRegistration(UserDbContext userDbContext, IGenericRepositoryOperation<Vehicle> genericRepositoryOperation) : base(userDbContext)
        {
            _userDbContext = userDbContext;
            _genericRepositoryOperation = genericRepositoryOperation;
           
        }

        public void RegisterVehicle(VehicleDTO vehicleDTO)
        {
            Vehicle vehicle = new Vehicle()
            {
                VehicleId = vehicleDTO.VehicleId,
                VehicleName = vehicleDTO.VehicleName,
                VehicleType = vehicleDTO.VehicleType,
                VehicleNumber = vehicleDTO.VehicleNumber,
            };
            _genericRepositoryOperation.Add(vehicle);
            _genericRepositoryOperation.Save();



            //var vehicle = new Vehicle()
            //{
            //    MemberId = vehicleDTO.MemberId,                
            //    VehicleName = vehicleDTO.VehicleName,
            //    VehicleType = vehicleDTO.VehicleType,
            //    VehicleNumber = vehicleDTO.VehicleNumber,
            //};
            //_userDbContext.Add(vehicle);
            //_userDbContext.SaveChanges();
        }
    }
}
