using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class APIDbContext : DbContext
    {

        public DbSet<Album> Album { get; set; }
        public DbSet<Musician> Musician { get; set; }
        public DbSet<MusicianTrack> MusicianTrack { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }
        public DbSet<Track> Track { get; set; }

        public APIDbContext() { }

        public APIDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>((builder) =>
            {
                builder.HasData(
                    new Musician { IdMusician = 1, FirstName = "Andrzej", LastName = "Kowalski", NickName = "AK" }
                    );
            });

    

    }
    }
}
