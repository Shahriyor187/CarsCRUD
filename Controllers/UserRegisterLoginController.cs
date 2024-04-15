using CarsCRUD.AuthDTOs;
using CarsCRUD.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarsCRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRegisterLoginController(IUserRegisterService userRegisterService) : ControllerBase
{
    private readonly IUserRegisterService _userRegisterService = userRegisterService;
    [HttpPost("Register-User")]
    public async Task<IActionResult> Register(UserRegisterRequest registerRequest)
    {
        try
        {
            var registrationResponse = await _userRegisterService.UserRegister(registerRequest);

            if (registrationResponse.Success)
            {
                return Ok("Registered");
            }
            else
            {
                return BadRequest(registrationResponse.Message);
            }
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
    {
        try
        {
            var login = await _userRegisterService.UserLogin(userLoginRequest);
            if (login.Success)
            {
                return Ok("Login successful");
            }
            else { return BadRequest(login.Message); }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}