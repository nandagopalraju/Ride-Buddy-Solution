using RB.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Application.DTO
{
    public class JoinRideDTO
    {

        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public string StartLocation { get; set; } = string.Empty;
        public string EndLocation { get; set; } = string.Empty;
        public int HostId { get; set; }


    }
}
