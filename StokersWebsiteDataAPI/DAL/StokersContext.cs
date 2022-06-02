using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DTOLayer;

namespace Datalayer
{
    public class StokersContext : DbContext
    {
        public StokersContext(DbContextOptions<StokersContext> options) : base(options)
        {

        }
        public DbSet<ActivityDTO> Activity { get; set; }
    }

}
