using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.Common
{
    public static class DefaulRoles
    {
        public static async Task CreateDefaultRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userRoleExist = await roleManager.RoleExistsAsync("User");
            if (!userRoleExist)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

        }
    }
}
