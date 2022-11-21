using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Domain.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; } = 0;

        [ForeignKey("Signup")]
        public int MemberId { get; set; }
        public Signup Signup { get; set; }
        
        public string VehicleName { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;

    }
}
