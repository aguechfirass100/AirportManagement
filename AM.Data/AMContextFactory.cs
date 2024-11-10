using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    public class AMContextFactory : IDesignTimeDbContextFactory<AMContext>
    {
        public AMContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AMContext>();
            optionsBuilder.UseSqlServer(@"Server=AGF-DESKTOP; 
                                          Database=Airport; 
                                          Integrated Security=True; 
                                          TrustServerCertificate=True");

            return new AMContext(optionsBuilder.Options);
        }
    }
}
