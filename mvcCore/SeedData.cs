using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcCore
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager) {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static async Task SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result==null)//null OBJECT
            {
                var user = new IdentityUser { UserName="admin", Email="admin@localhost.com"  };
                var result = await userManager.CreateAsync(user, "P@ssword1");
                if (result.Succeeded) {
                    //add this user to admin role
                    //assign user to a role
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }

        private static async  Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)//if the role does not exist create it
            {
                var role = new IdentityRole { Name = "Administrator" };
                await roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)//if the role does not exist create it
            {
                var role = new IdentityRole { Name = "Employee" };
              await   roleManager.CreateAsync(role);
            }
        }
    }
}
