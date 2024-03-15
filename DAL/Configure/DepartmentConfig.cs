using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configure
{
    internal class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x=>x.Code).IsRequired();
            builder.Property(x=>x.CreateAt).IsRequired();
            //--------------relation------------------------
            builder.HasMany(e => e.Employees)
                   .WithOne(d => d.Department)
                   .HasForeignKey(d => d.DepartmentId)
                   .IsRequired(false);
        }
    }
}
