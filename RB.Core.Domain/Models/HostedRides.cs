using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Domain.Models
{
    public class HostedRides
    {
        public int Id { get; set; } = 0;
        public string StartLocation { get; set; } = string.Empty;
        public string EndLocation { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }

        public int SignupMemberId { get; set; }
        public Signup Signup { get; set; }

        public int VehicleVehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
