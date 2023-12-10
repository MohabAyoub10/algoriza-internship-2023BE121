using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;
using Core.DTO;
using Core.Repository;
using Core.Domain;
using Core.Services;

namespace Vezeeta.Controllers.Patient
{
    [Route("api/Account")]
    [ApiController]
    public class PatientAccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationUserService _applicationUserService;


        public PatientAccountController(IUnitOfWork unitOfWork, IApplicationUserService applicationUserService)
        {
            _unitOfWork = unitOfWork;
            _applicationUserService = applicationUserService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] UserRegistrationDTO register)
        {
            try
            {
                return await _applicationUserService.AddUser(register);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                return await _applicationUserService.LogIn(username, password);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
