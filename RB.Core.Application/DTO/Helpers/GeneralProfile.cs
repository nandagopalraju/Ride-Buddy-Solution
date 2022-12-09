﻿using AutoMapper;
using RB.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Application.DTO.Helpers
{
    public class GeneralProfile: Profile
    {
        public GeneralProfile()
        {
            CreateMap<Signup, SignupDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<JoinRide, JoinRideDTO>().ReverseMap();

        }
    }
}
