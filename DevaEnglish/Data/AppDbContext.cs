using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DevaEnglish.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //base.OnModelCreating(builder);
        }

        
        public DbSet<Feedback> FeedbackScores { get; set; }
        
        //public DbSet<CalanderEvent> FamilyAvailabilities { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Families> Families { get; set; }
        public DbSet<FamilyAvailabilities> FamilyAvailabilities { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<MeetingPoints> MeetingPoints { get; set; }
        public DbSet<FamilyAllergen> FamilyAllergen { get; set; }
        public DbSet<FamilyMembers> FamilyMembers { get; set; }
        public DbSet<FamilyPet> FamilyPets { get; set; }
        public DbSet<FamilyRooms> FamilyRooms { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
