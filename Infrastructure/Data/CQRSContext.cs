using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace CQRS.Data
{
    public class CQRSContext : DbContext
    {
        public CQRSContext (DbContextOptions<CQRSContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Book> Book { get; set; } = default!;
    }
}
