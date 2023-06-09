﻿using LMSSolution.Application.Auths;
using LMSSolution.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultToken = await _authService.Authenticate(request);

            if (!resultToken.IsSuccess)
            {
                return BadRequest(resultToken.Message);
            }

            return Ok(resultToken);
        }
    }
}
