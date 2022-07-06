using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data;

public class UsuariosApiContext
    : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
{
    private readonly IConfiguration _config;
    public UsuariosApiContext(DbContextOptions<UsuariosApiContext> options,
                              IConfiguration config) : base(options)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        CustomIdentityUser admin = new()
        {
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@email.com",
            NormalizedEmail = "ADMIN@EMAIL.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            Id = 99999
        };
        PasswordHasher<CustomIdentityUser> hasher = new();
        admin.PasswordHash = hasher.HashPassword(admin, _config.GetValue<string>("admininfo:password"));
        builder.Entity<CustomIdentityUser>().HasData(admin);

        IdentityRole<int> roleAdmin =
            new() { Id = 99999, Name = "admin", NormalizedName = "ADMIN" };
        builder.Entity<IdentityRole<int>>().HasData(roleAdmin);

        builder.Entity<IdentityUserRole<int>>()
            .HasData(new IdentityUserRole<int> { RoleId = 99999, UserId = 99999 });

        IdentityRole<int> roleRegular =
            new() { Id = 99998, Name = "regular", NormalizedName = "REGULAR" };
        builder.Entity<IdentityRole<int>>().HasData(roleRegular);
    }
}
