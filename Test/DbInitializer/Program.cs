using Infrastructure.Identity.Contexts;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;

namespace DbInitializer
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<IdentityContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
            dbContextOptionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CleanArchitectureIdentityDb;Integrated Security=True;MultipleActiveResultSets=True");

            IdentityContext identityContext = new IdentityContext(dbContextOptionsBuilder.Options);
            Console.WriteLine($"count:{identityContext.Users.Count()}");
            ApplicationUser user = new ApplicationUser();
            user.FirstName = "Wagner";
            user.LastName = "Xu";
            user.Email = "wagner.xu@meehealth.com";
            user.UserName = "wagner.xu";
            var password = "Pas$worD01";
            var hasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = hasher.HashPassword(user, password);
            identityContext.Users.Add(user);
            identityContext.SaveChanges();
        }
    }
}
