using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TodoListClient;

public class AddRolesClaimsTransformation : IClaimsTransformation
{
    private IConfiguration _configuration;

    public AddRolesClaimsTransformation(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        try
        {
            var clone = principal.Clone();
            var newIdentity = clone.Identity as ClaimsIdentity;
            var nameId = principal.Claims.FirstOrDefault(c => c.Type is ClaimTypes.NameIdentifier or ClaimTypes.Name);
            if (nameId == null)
            {
                return principal;
            }

            //trying to get token to call the TodoListService
            var token = await GetApplicationTokenAsync();

            // call TodoListService
            return clone;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            throw;
        }
    }

    private async Task<string> GetApplicationTokenAsync()
    {
        var clientId = _configuration["AzureAdB2C:ClientId"];
        var clientSecret = _configuration["AzureAdB2C:ClientSecret"];
        var scopes = new[] { _configuration["TodoList:TodoListScope"] };
        var baseUri = new Uri(_configuration["AzureAdB2C:Instance"]);
        var authority = new Uri(baseUri, _configuration["AzureAdB2C:Domain"]);
        var app = ConfidentialClientApplicationBuilder.Create(clientId)
            .WithClientSecret(clientSecret)
            .WithAuthority(authority)
            .WithLegacyCacheCompatibility(false)
            .Build();

        var authResult = await app.AcquireTokenForClient(scopes).ExecuteAsync();
        return authResult.AccessToken;
    }
}
