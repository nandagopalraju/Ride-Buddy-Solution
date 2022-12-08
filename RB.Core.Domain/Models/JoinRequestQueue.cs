using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Domain.Models
{
    public class JoinRequestQueue
    {
        public int Id { get; set; }
        
        public bool status { get; set; }
        public int HostedRidesId { get; set; }
        public HostedRides HostedRides { get; set; }
        public int JoinRideId { get; set; }
        public JoinRide JoinRide { get; set; }

    }
}
