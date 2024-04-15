using CarsCRUD.AuthDTOs;
using CarsCRUD.Commens.Helpers;
using CarsCRUD.Entity;
using CarsCRUD.Interfaces;
using CarsCRUD.Roles;
using Microsoft.AspNetCore.Identity;

namespace CarsCRUD.Service;
public class UserRegisterService(UserManager<ApplicationUser> userManager, IConfiguration configuration) : IUserRegisterService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<UserLoginResponse> UserLogin(UserLoginRequest login)
    {
        if (!login.Email.Contains("@gmail.com"))
        {
            return new UserLoginResponse { Success = false, Message = "Email should contain @gmail.com" };
        }

        var user = await _userManager.FindByEmailAsync(login.Email);

        if (user == null)
        {
            return new UserLoginResponse { Success = false, Message = "User not found. Check your email." };
        }

        var result = await _userManager.CheckPasswordAsync(user, login.Password);

        if (!result)
        {
            return new UserLoginResponse { Success = false, Message = "Invalid password." };
        }
        var roles = await _userManager.GetRolesAsync(user);
        var token = JwtHelper.GenerateJwtToken(user, roles, _configuration);
        return new UserLoginResponse { Success = true, Token = token, Message = "Login successful." };
    }

    public async Task<UserRegisterResponse> UserRegister(UserRegisterRequest register)
    {
        if (!register.Email.Contains("@gmail.com"))
        {
            return new UserRegisterResponse { Success = false, Message = "Registration using Gmail is not allowed" };
        }

        var existingUser = await _userManager.FindByEmailAsync(register.Email);
        if (existingUser != null)
        {
            return new UserRegisterResponse { Success = false, Message = "User with this email already exists." };
        }

        if (register.Password.Length <= 8)
        {
            return new UserRegisterResponse { Success = false, Message = "Password should be at least 8 characters long" };
        }

        var newUser = new ApplicationUser
        {
            UserName = register.Username,
            Email = register.Email,
            PasswordHash = register.Password
        };
        var result = await _userManager.CreateAsync(newUser, register.Password);
        if (result.Succeeded)
        {
            return new UserRegisterResponse { Success = true, Message = "User registered successfully." };
        }
        else
        {
            var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
            return new UserRegisterResponse { Success = false, Message = $"User registration failed: {errorMessage}" };
        }
    }
}