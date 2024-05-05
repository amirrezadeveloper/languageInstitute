﻿using languageInstitute.Application.Contracts;
using languageInstitute.Application.Dtos;
using languageInstitute.Application.Enums;
using languageInstitute.Domain.Settings;
using languageInstitute.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace languageInstitute.Infrastructure.Identity.Repositories;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JWTSettings _jwtSettings;

    public AuthenticationService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<ApplicationUser> signInManager,
        IOptions<JWTSettings> jwtSettings)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager; 
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthenticationResponseDto> Login(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Username);
        if (user == null)
        {
            return null;
        }
        var result = await _signInManager.PasswordSignInAsync(user.UserName, dto.Password, false, lockoutOnFailure: false);
        if (!result.Succeeded)
        {
            return null;
        }

        JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
        AuthenticationResponseDto response = new AuthenticationResponseDto();
        response.Id = user.Id;
        response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        response.Email = user.Email;
        response.UserName = user.UserName;
        var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
        response.Roles = rolesList.ToList();
        response.IsVerified = user.EmailConfirmed;
        return response;
    }

    public async Task<AuthenticationResponseDto> Register(RegisterDto dto)
    {
        var userWithSameUserName = await _userManager.FindByNameAsync(dto.Username);
        if (userWithSameUserName != null)
        {
            return null;
        }
        var user = new ApplicationUser
        {
            Email = dto.Username,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            UserName = dto.Username
        };
        var userWithSameEmail = await _userManager.FindByEmailAsync(dto.Username);
        if (userWithSameEmail == null)
        {
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.USER.ToString());
                //var verificationUri = await SendVerificationEmail(user, origin);
                //TODO: Attach Email Service here and configure it via appsettings
                //await _emailService.SendAsync(new Application.DTOs.Email.EmailRequest() { From = "mail@codewithmukesh.com", To = user.Email, Body = $"Please confirm your account by visiting this URL {verificationUri}", Subject = "Confirm Registration" });
                //return new Response<string>(user.Id, message: $"User Registered. Please confirm your account by visiting this URL {verificationUri}");
                return null;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        for (int i = 0; i < roles.Count; i++)
        {
            roleClaims.Add(new Claim("roles", roles[i]));
        }

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
        .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }
}
