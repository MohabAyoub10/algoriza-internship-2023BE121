using Core.DTO;
using Core.Utilities;
using Core.Repository;
using Core.Domain;
using Core.Services;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Services
{
public class ApplicationUserService : IApplicationUserService
{
    protected  IUnitOfWork _unitOfWork;
    protected  IConfiguration _configuration;

    public ApplicationUserService(IUnitOfWork UnitOfWork, IConfiguration configuration)
    {
        _unitOfWork = UnitOfWork;
        _configuration = configuration;

    }

    public async Task<IActionResult> AddUser(UserRegistrationDTO user)
    {
        var User = new ApplicationUser()
        {
            Email = user.Email,
            UserName = user.UserName,
            FullName = user.FirstName + " " + user.LastName,
            PasswordHash = user.Password,
            Gender = user.Gender,
            BirthDate = user.DateOfBirth,
            PhoneNumber = user.Phone,
            UserType = (UserType)Enum.Parse(typeof(UserType), user.Role),

        };
        try
        {
            await _unitOfWork.ApplicationUsers.Add(User);

            _unitOfWork.Save();
            return new OkObjectResult(User);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    public async Task<IActionResult> LogIn(string username, string password)
    {
        var user = await _unitOfWork.ApplicationUsers.Find(username, password);
        var result =
            await _unitOfWork.ApplicationUsers.CheckPassword(user, password);
        if (user != null && result)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, await _unitOfWork.ApplicationUsers.GetRole(user)),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: Claims, 
                expires: DateTime.Now.AddDays(5),
                signingCredentials: credentials
                );
                

                return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
        else
        {
            return new BadRequestObjectResult("Invalid username or password");
        }
    }
}
}
