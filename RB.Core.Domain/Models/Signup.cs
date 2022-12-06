using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Domain.Models
{
    public class Signup
    {
        //public Signup()
        //{
        //   // HashSet<Signup> signups = new HashSet<Signup>();
        //  HashSet<Vehicle> vehicles = new HashSet<Vehicle>();

        //}
        [Key]
        public int MemberId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }= string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public double Number { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;

        //public IFormFile? LicenseImage { get; set; } 
        public string? LicenceImageName { get; set; }
        public string Role { get; set; } = string.Empty;

        //Relationships
        
       // public List<HostedRides> HostedRides { get; set; } 
        public ICollection<Vehicle> Vehicles { get; set; }


    }
}
