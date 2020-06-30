using CMSproject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSproject.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services, string adminPW)
        {
            var options = services.GetRequiredService<DbContextOptions<ApplicationDbContext>>();

            using (var _context = new ApplicationDbContext(options))
            {
                var userManager = services.GetRequiredService<UserManager<User>>();

                if (adminPW is null) adminPW = "BygMig123!";
                var adminEmail = "admin@domain.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    var user = new User
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                    };

                    var addAdminResult = await userManager.CreateAsync(user, adminPW);
                    if (!addAdminResult.Succeeded) throw new Exception(string.Join("\n", addAdminResult.Errors));
                }
            }
        }
    }
}
