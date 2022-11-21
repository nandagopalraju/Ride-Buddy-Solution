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

        [ForeignKey("Signup")]
        public int MemberId { get; set; }
        public Signup Signup { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
