namespace ShopYenSao.Application.Models.Identity;

/// <summary>
/// Represents the settings for configuring JWT (JSON Web Token) authentication.
/// </summary>
public class JWTSettings
{
    /// <summary>
    /// The secret key used to sign and validate the JWT.
    /// This should be a strong, secure, and private key.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// The issuer of the JWT.
    /// Typically, this represents the entity generating the token, such as your application.
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// The audience for which the JWT is intended.
    /// This could represent the intended recipients of the token, such as client applications.
    /// </summary>
    public string Audience { get; set; }

    /// <summary>
    /// The duration (in minutes) for which the JWT is valid.
    /// After this duration, the token will expire and become invalid.
    /// </summary>
    public double DurationInMinutes { get; set; }
}
