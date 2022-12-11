using System;
using Microsoft.EntityFrameworkCore;

namespace at_infnet_mvc.Models
{
    public class ModelContext : DbContext
    {
        public DbSet<Pessoa> pessoas { get; set; }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

      
    }
    
    
}
