using CarsCRUD.AuthDTOs;
using CarsCRUD.Commens.Exceptions;
using CarsCRUD.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CarsCRUD.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Admin")]
[Authorize(Roles = "SuperAdmin")]
public class AdminsController(IAdminService adminService): ControllerBase
{
    private readonly IAdminService _adminService = adminService;
    [HttpPost("Register-Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterAdmin(RegistrationRequest registration)
    {
        try
        {
            var response = await _adminService.RegisterAdminAsync(registration);
            return response.Success ? Ok(response) : Conflict(response);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("Register-SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterSuperAdmin(RegistrationRequest registration)
    {
        try
        {
            var response = await _adminService.RegisterSuperAdminAsync(registration);
            return response.Success ? Ok(response) : Conflict(response);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("Login-Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginAdmin(LoginRequest login)
    {
        try
        {
            var result = await _adminService.LoginAdminAsync(login);
            if (result.Success)
            {
                return Ok(new { Token = result.AccessToken});
            }
            else
            {
                return BadRequest(new { Message = result.Message });
            }

        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("Login-SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginSuperAdmin(LoginRequest login)
    {
        try
        {
            var result = await _adminService.LoginSuperAdminAsync(login);
            if (result.Success)
            {
                return Ok(new { Token = result.AccessToken });
            }
            else
            {
                return BadRequest(new { Message = result.Message });
            }
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete-admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAdminAsync(LoginRequest loginRequest)
    {
        try
        {
            await _adminService.DeleteAccountAsync(loginRequest);
            return Ok("Succesfully deleted");
        }

        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("Delete-SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteSuperAdminAsync(LoginRequest loginRequest)
    {
        try
        {
            await _adminService.DeleteAccountAsync(loginRequest);
            return Ok("Succesfully deleted");
        }

        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}