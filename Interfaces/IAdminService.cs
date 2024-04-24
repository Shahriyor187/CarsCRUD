using CarsCRUD.AuthDTOs;
using CarsCRUD.Entity;

namespace CarsCRUD.Interfaces;
public interface IAdminService
{
    Task DeleteAccountAsync(LoginRequest request);
    Task<RegisterResponse> RegisterAdminAsync(RegistrationRequest request);
    Task<RegisterResponse> RegisterSuperAdminAsync(RegistrationRequest request);
    Task<LoginResponse> LoginAdminAsync(LoginRequest request);
    Task<LoginResponse> LoginSuperAdminAsync(LoginRequest request);
}