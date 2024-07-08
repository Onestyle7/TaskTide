using Microsoft.AspNetCore.Identity;
using ProjectManagement.backend.Models;

namespace ProjectManagement.backend.Services
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach(var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if(!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            //Creation of super user who is allowed to maintain the web app
            var poweruser = new ApplicationUser
            {
                UserName = "admin",
                Email = "klusbartek8@gmail.com"
            };
            string userPassword = "Admin123!@#";
            var user = await userManager.FindByEmailAsync("klusbartek8@gmail.com");

            if(user == null)
            {
                var createPowerUser = await userManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}
