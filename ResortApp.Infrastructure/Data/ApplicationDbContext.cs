using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResortApp.Domain.Entities;

namespace ResortApp.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions < ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>().HasData(
                  new Villa
                  {
                      ID = 1,
                      Name = "Royal Villa",
                      Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                      ImageUrl = "https://placehold.co/600x400",
                      Occupancy = 4,
                      Price = 200,
                      Sqft = 550,
                  },
                new Villa
                {
                    ID = 2,
                    Name = "Premium Pool Villa",
                    Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://placehold.co/600x401",
                    Occupancy = 4,
                    Price = 300,
                    Sqft = 550,
                },
                new Villa
                {
                    ID = 3,
                    Name = "Luxury Pool Villa",
                    Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://placehold.co/600x402",
                    Occupancy = 4,
                    Price = 400,
                    Sqft = 750,
                }
            );
            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber
                {
                    Villa_Number = 101,
                    VillaID = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 102,
                    VillaID = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 103,
                    VillaID = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 104,
                    VillaID = 1,
                }, 
                new VillaNumber
                {
                    Villa_Number = 201,
                    VillaID = 2,
                }, 
                new VillaNumber
                {
                    Villa_Number = 202,
                    VillaID = 2,
                }, 
                new VillaNumber
                {
                    Villa_Number = 203,
                    VillaID = 2,
                }, 
                new VillaNumber
                {
                    Villa_Number = 301,
                    VillaID = 3,
                },
                new VillaNumber
                {
                    Villa_Number = 302,
                    VillaID = 3,
                }
            );
        }
    }
}
