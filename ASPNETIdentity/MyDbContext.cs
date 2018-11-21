using ASPNETIdentity.Identity;
using ASPNETIdentity.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPNETIdentity
{
    public class MyDbContext:DbContext
    {
        public MyDbContext():base("Name=ConStr")
        {

        }
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityUserClaim> UserClaims { get; set; }
        public DbSet<IdentityUserLogin> UserLogins { get; set; }
        public DbSet<IdentityRoleClaim> RoleClaims { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureIdentity(modelBuilder);
        }
        private void ConfigureIdentity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(x => x.CreatedBy).Ignore(x => x.CreatedById).Ignore(x => x.CreatedAt);
            modelBuilder.Entity<User>().Ignore(x => x.UpdatedBy).Ignore(x => x.UpdatedById).Ignore(x => x.UpdatedAt);
            modelBuilder.Entity<IdentityUserClaim>()
                .HasKey(uc => uc.Id)
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityRoleClaim>()
                .HasKey(rc => rc.Id)
                .ToTable("RoleClaims");

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey })
                .ToTable("UserLogins");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");
                //.Property(r => r.ConcurrencyStamp)
                //.IsRowVersion();

            modelBuilder.Entity<IdentityRole>().Property(u => u.Name).HasMaxLength(256);
            modelBuilder.Entity<IdentityRole>().HasMany(r => r.Claims).WithRequired().HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users")
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(x =>
                {
                    x.MapLeftKey("UserID");
                    x.MapRightKey("RoleID");
                    x.ToTable("UsersRoles");
                });

            //modelBuilder.Entity<IdentityUser>().Property(u => u.ConcurrencyStamp).IsRowVersion();
            modelBuilder.Entity<IdentityUser>().Property(u => u.UserName).HasMaxLength(256);
            modelBuilder.Entity<IdentityUser>().Property(u => u.Email).HasMaxLength(256);
            modelBuilder.Entity<IdentityUser>().HasMany(u => u.IdentityUserClaims).WithRequired().HasForeignKey(uc => uc.UserId);
            modelBuilder.Entity<IdentityUser>().HasMany(u => u.IdentityUserLogins).WithRequired().HasForeignKey(ul => ul.UserId);
        }
    }

}