using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class GestionTareasContext : DbContext
    {
        public GestionTareasContext(DbContextOptions<GestionTareasContext> options) : base(options) { }

        public DbSet<Data.Models.Task> Tasks { get; set; }
    }

}
