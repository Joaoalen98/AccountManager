using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AccountManager.Application.DTOs.Jwt;
using AccountManager.Application.Interfaces;
using AccountManager.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AccountManager.Application.Services;

public class JwtService(IOptions<JwtConfigDTO> options) : IJwtService
{
    public (string token, DateTime expiresAt) GenerateToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(options.Value.Key);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim("AccountNumber", user.AccountNumber),
        };

        var expires = DateTime.UtcNow.AddHours(options.Value.ExpiresInHours);

        var token = new JwtSecurityToken(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256));

        return (new JwtSecurityTokenHandler().WriteToken(token), expires);
    }
}
