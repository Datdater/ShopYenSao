using ShopYenSao.Application.Models.Identity;

namespace ShopYenSao.Application.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}