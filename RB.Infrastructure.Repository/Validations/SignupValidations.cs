using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.Repository.Validations
{
    //public class SignupValidations : IEntityTypeConfiguration<SignupDTO>
    //{
    //    public void Configure(EntityTypeBuilder<SignupDTO> builder)
    //    {
    //        builder.HasKey(x => x.Id);
    //        builder.Property(x => x.Name).HasMaxLength(30)
    //            .HasColumnName("Name")
    //            .HasColumnType("VARCHAR(30)")
    //            .IsRequired(true);
    //        builder.Property(x => x.Email).HasMaxLength(50)
    //            .HasColumnName("Name")
    //            .HasColumnType("VARCHAR(50)")
    //            .IsRequired(true);
    //        builder.Property(x => x.Department).HasMaxLength(20)
    //            .HasColumnName("Name")
    //            .HasColumnType("VARCHAR(20)")
    //            .IsRequired(true);
    //        builder.Property(x => x.EmployeeId).HasMaxLength(10)
    //            .HasColumnName("Name")
    //            .HasColumnType("VARCHAR(10)")
    //            .IsRequired(true);
    //        builder.Property(x => x.Gender).HasMaxLength(10)
    //            .HasColumnName("Name")
    //            .HasColumnType("VARCHAR(10)")
    //            .IsRequired(true);

    //    }
   // }
}
