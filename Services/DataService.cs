using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogProject.Data;
using TheBlogProject.Enums;
using TheBlogProject.Models;

namespace TheBlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            await _dbContext.Database.MigrateAsync();
            //Task 1: Seed roles into the system
            await SeedRolesAsync();
            //Task 2: Seed users into the system
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //if there are already roles, do nothing
            if (_dbContext.Roles.Any())
            {
                return;
            }
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        public async Task SeedUsersAsync()
        {
            if (_dbContext.Users.Any())
            {
                return;
            }

            //create admin user
            var adminUser = new BlogUser()
            {
                Email = "luke_lasorsa@outlook.com",
                UserName = "luke_lasorsa@outlook.com",
                FirstName = "Luke",
                LastName = "Lasorsa",
                DisplayName = "Luke Lasorsa",
                EmailConfirmed = true
            };
            //create mod user
            var modUser = new BlogUser()
            {

                Email = "chloenhull@gmail.com",
                UserName = "chloenhull@gmail.com",
                FirstName = "Chloe",
                LastName = "Hull",
                DisplayName = "Chloe Hull",
                EmailConfirmed = true
            };

            //create a admin+mod user
            await _userManager.CreateAsync(adminUser, "Abc&123!");
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            await _userManager.CreateAsync(modUser, "Abc&122!");
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
           


        }

    }
}
