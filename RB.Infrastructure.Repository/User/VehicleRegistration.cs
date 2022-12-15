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
        //private IGenericRepositoryOperation<Vehicle> _genericRepositoryOperation;
        public VehicleRegistration(UserDbContext userDbContext/*, IGenericRepositoryOperation<Vehicle> genericRepositoryOperation) : base(userDbContext*/)
        {
            _userDbContext = userDbContext;
           // _genericRepositoryOperation = genericRepositoryOperation;
             
        }

        //public List<VehicleDTO> GetAllVehicles()
        //{
        //    return _userDbContext.Vehicles.Where(i=>true).ToList();
        //}

        public void RegisterVehicle(VehicleDTO vehicleDTO, int id)
        {

            //Signup user= new Signup();
            //user.MemberId = id;

            var user1 = _userDbContext.Users.Where(x => x.MemberId == id).ToList();
           


            Vehicle vehicle = new Vehicle()
            {
                //VehicleId = vehicleDTO.VehicleId,
                VehicleName = vehicleDTO.VehicleName,
                VehicleType = vehicleDTO.VehicleType,
                VehicleNumber = vehicleDTO.VehicleNumber,
                
                SignupMemberId = user1[0].MemberId,
                
            };
            //_genericRepositoryOperation.Add(vehicle);
            //_genericRepositoryOperation.Save();

            _userDbContext.Add(vehicle);
            _userDbContext.SaveChangesAsync();



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
