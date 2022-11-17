using Microsoft.EntityFrameworkCore;
using RB.Core.Application.DTO;
using RB.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.Repository
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext>options) : base(options)
        {

        }
        public DbSet<Signup> Users { get; set; }

       
    }
}
