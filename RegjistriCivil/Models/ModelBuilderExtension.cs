using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RegjistriCivil.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdCard>().HasData(
                new IdCard
                {
                    DocumentIssuingDate = DateTime.Now
                }
            );
        }
    }
}
