using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Model.DBCommunication
{
    public class EntityContext : DbContext
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RewardedUser> RewardedUsers { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureRelationships(modelBuilder);


            InsertDataInTable(modelBuilder);
        }

        private void InsertDataInTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User(1, "Nikola","nikola", "nikola",false,0, "nikolag857@gmail.com" ),
                                                new User(2,"Nenad","nenad","nenad", false,0, "nikolag857@gmail.com"));

        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<RewardedUser>()
                .HasKey(x => new { x.UserId, x.CostumerId, x.DateRewarded });

            modelBuilder.Entity<Campaign>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Campaign>()
                .HasOne(x => x.User)
                .WithOne(x => x.Campaign);



            modelBuilder.Entity<User>()
                .HasMany(x => x.RewardedUsers)
                .WithOne(x => x.User);

        }
    }
}
