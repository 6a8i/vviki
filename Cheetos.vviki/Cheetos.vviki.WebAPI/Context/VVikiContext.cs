using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheetos.vviki.WebAPI.Context
{
    public class VVikiContext : DbContext
    {
        public DbSet<Page> Page { get; set; }
        public DbSet<Tag> Tag { get; set; }

        public VVikiContext(DbContextOptions<VVikiContext> options) : base(options)
        {
        }
    }
}