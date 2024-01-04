using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.EF
{
    public class LMSSolutionContextFactory : IDesignTimeDbContextFactory<LMSDbContext>
    {
        public LMSDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("LMSDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<LMSDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new LMSDbContext(optionsBuilder.Options);
        }
    }
}
