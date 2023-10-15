using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Netpobre.Models;

    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Rents>().HasKey(e => new { e.Show, e.Price });
        builder.Entity<Stars>().HasKey(e => new { e.IdShow, e.IdClient });
    }

    public DbSet<Netpobre.Models.Series> Series { get; set; }
        public DbSet<Client> Clients { get; set; } 
        public DbSet<Rents> Rents { get; set; }
        public DbSet<Stars> Stars { get; set; }
    }
