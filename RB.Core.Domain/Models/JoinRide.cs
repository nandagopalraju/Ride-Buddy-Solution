using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Domain.Models
{
    public class JoinRide
    {
        [Key]
        public int Id { get; set; } = 0;
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public string StartLocation { get; set; } = string.Empty;
        public string EndLocation { get; set; } = string.Empty;
        public bool Status { get; set; }

        public int SignupMemberId { get; set; }
        public Signup Signup { get; set; }

        public int HostedRidesId { get; set; }
        public HostedRides HostedRides { get; set; }

       // public ICollection<JoinRequestQueue> joinRequestQueues { get; set; }
    }
}
