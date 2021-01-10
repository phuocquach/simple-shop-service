using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace MineCommerceApplication.Tests.Helper
{
    public static class MockJwtTokens
    {
        public static string Issuer { get; } = Guid.NewGuid().ToString();
        public static SecurityKey SecurityKey { get; }
        public static SigningCredentials SigningCredentials { get; }

        private static readonly JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
        private static readonly RandomNumberGenerator securityRandomNumber = RandomNumberGenerator.Create();
        private static readonly byte[] securityKey = new byte[32];

        static MockJwtTokens()
        {
            securityRandomNumber.GetBytes(securityKey);
            SecurityKey = new SymmetricSecurityKey(securityKey) { KeyId = Guid.NewGuid().ToString() };
            SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
        }

        public static string GenerateJwtToken(IEnumerable<Claim> claims)
        {
            return securityTokenHandler.WriteToken(new JwtSecurityToken(Issuer, "client", claims, null, DateTime.UtcNow.AddMinutes(20), SigningCredentials));
        }

        public static void AppendJwtToken(this HttpClient httpClient, List<Claim> claims = null)
        {
            /*if (claims != null && !claims.Any(x => x.Type.Equals(DummyValue.ClaimType_Sub)))
            {
                claims.Add(new Claim(DummyValue.ClaimType_Sub, DummyValue.ClaimValue_Sub_Value));
            }*/

            var token = GenerateJwtToken(claims);

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Test", token);
        }
    }

}
