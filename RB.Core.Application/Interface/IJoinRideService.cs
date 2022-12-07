using RB.Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Application.Interface
{
    public interface IJoinRideService
    {
        void JoinRide(JoinRideDTO JoinRideDTO, int id);
    }
}
