using Microsoft.AspNetCore.Identity;
using Sapphire17.Areas.Identity.Data;
using Sapphire17.Constants;

namespace Sapphire17.Data
{
    public class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var adminEmail = configuration["AdminUser:Email"];
            var adminPassword = configuration["AdminUser:Password"];
            var adminName = configuration["AdminUser:Name"];

            await CreateUserWithRole(userManager, adminEmail, adminPassword, adminName, Roles.Admin);
        }

        public static async Task CreateUserWithRole(UserManager<User> userManager, string email, string password,
            string name, string role)
        {
            if(await userManager.FindByEmailAsync(email) == null)
            {
                var user = new User
                {
                    UserName = email,
                    Email = email,
                    Name = name,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    throw new Exception($"Проблем при създаването на потребител с email {user.Email}. Грешки: {string.Join(",", result.Errors)}");
                }
            }
        }
    }
}
