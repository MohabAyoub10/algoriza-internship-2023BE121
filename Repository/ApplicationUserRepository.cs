using Core.Domain;
using Core.Utilities;
using Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Repository
{
    public class ApplicationUserRepository :  IApplicationUserRepository, IBaseRepository<ApplicationUser>
    {

        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;





        public ApplicationUserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Add(ApplicationUser entity)
        {
            var result = await _userManager.CreateAsync(entity, entity.PasswordHash);

            var role = Enum.GetName(typeof(UserType), entity.UserType);

            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                var Role = new IdentityRole(role);
                await _roleManager.CreateAsync(Role);
            }

            var resultRole = await _userManager.AddToRoleAsync(entity,role);

            if (result.Succeeded && resultRole.Succeeded)
            {
                return new OkObjectResult(entity);
            }
            return new BadRequestObjectResult(result.Errors);
        }

        public void AddRange(IEnumerable<ApplicationUser> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> Find(string username, string password)
        {

            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> CheckPassword(ApplicationUser user , string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<string> GetRole(ApplicationUser user)
        {
            var role = await _userManager.GetRolesAsync(user);
            return role.First();
        }

        public void Delete(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<ApplicationUser> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllById(int Id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<ApplicationUser> entities)
        {
            throw new NotImplementedException();
        }
    }
}
