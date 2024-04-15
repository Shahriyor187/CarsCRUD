namespace CarsCRUD.AuthDTOs;
public class UserLoginResponse
{
    public string Token { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; }
}
