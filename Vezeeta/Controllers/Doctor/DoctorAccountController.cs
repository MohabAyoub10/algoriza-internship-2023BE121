using Core.Repository;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Vezeeta.Controllers.Doctor
{
    [Route("api/doctor/account")]
    [ApiController]
    public class DoctorAccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationUserService _applicationUserService;


        public DoctorAccountController(IUnitOfWork unitOfWork, IApplicationUserService applicationUserService)
        {
            _unitOfWork = unitOfWork;
            _applicationUserService = applicationUserService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username,string password)
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
