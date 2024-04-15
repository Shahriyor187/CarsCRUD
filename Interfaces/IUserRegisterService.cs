using CarsCRUD.AuthDTOs;

namespace CarsCRUD.Interfaces;
public interface IUserRegisterService
{
    Task<UserRegisterResponse> UserRegister(UserRegisterRequest register);
    Task<UserLoginResponse> UserLogin(UserLoginRequest login);
}