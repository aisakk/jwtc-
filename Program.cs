// See https://aka.ms/new-console-template for more information

using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

string key = "abcdefghijklmnopqrstuvxyz0123456789";
var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
var claims = new List<Claim>();
claims.Add(new Claim(ClaimTypes.Name, "Isaac"));
claims.Add(new Claim(ClaimTypes.Email, "santaellaisaac1@gmail.com"));
var Sectoken = new JwtSecurityToken(
              claims: claims,
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: credentials);

var token =  new JwtSecurityTokenHandler().WriteToken(Sectoken);
Console.WriteLine($"Este es el token: ${token}");
