using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ANK13Areas.Areas.Muhasebe.Data;
using ANK13Areas.Areas.Yonetim.Data;

    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext (DbContextOptions<UygulamaDbContext> options)
            : base(options)
        {
        }

        public DbSet<ANK13Areas.Areas.Muhasebe.Data.Fatura> Fatura { get; set; } = default!;

        public DbSet<ANK13Areas.Areas.Yonetim.Data.Yonetici>? Yonetici { get; set; }
    }
