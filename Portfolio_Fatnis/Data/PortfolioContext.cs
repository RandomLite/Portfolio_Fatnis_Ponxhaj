using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
           : base(options)
        {
        }

        public DbSet<Models.Project> ProjectCX { get; set; }

        public DbSet<Models.OperationSystem> OperationSystemCX { get; set; }
    }
}
