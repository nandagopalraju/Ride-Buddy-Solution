using RB.Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Application.Interface
{
    public interface IHostRideService
    {
        Task<UserResponseDTO> HostRide(HostedRidesDTO hostedRidesDTO, int id);
    }
}
