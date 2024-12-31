using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Exception;
using ShopYenSao.Application.Identity;
using ShopYenSao.Application.Models.Identity;
using ShopYenSao.Domain;
using ShopYenSao.Identity.Models;


public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JWTSettings _jwtSettings;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(UserManager<ApplicationUser> userManager, IOptions<JWTSettings> jwtSettings,
        SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.username);
        if (user == null)
        {
            throw new NotFoundException($"Username {request.username} not found", request.username);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.password, false);
        if (!result.Succeeded)
        {
            throw new BadRequestException("Invalid username or password");
        }

        JwtSecurityToken jwtSecurityToken = await GenerationToken(user);
        AuthResponse response = new AuthResponse
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            UserName = user.UserName
        };

        return response;
    }

    public async Task<JwtSecurityToken> GenerationToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roleClaims = await _userManager.GetClaimsAsync(user);
        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id)
            }
            .Union(roleClaims)
            .Union(userClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwrSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
        );

        return jwrSecurityToken;
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        var existingUser = await _userManager.FindByNameAsync(request.UserName);

        if (existingUser != null)
        {
            throw new Exception($"User {request.UserName} already exists");
        }


        var existingEmail = await _userManager.FindByEmailAsync(request.Email);
        if (existingEmail == null)
        {
            var account = await _unitOfWork.AccountRepository.InsertAsync(new Account()
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            });
            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.UserName,
                EmailConfirmed = true,
                AccountId = account.Id
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, "Employee");
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                throw new Exception($"{result.Errors}");
            }
        }
        else
        {
            throw new Exception($"Email {request.Email} already exists.");
        }
    }
}