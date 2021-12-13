using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BasicWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasicWebApp.Setup
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("x-apiKey"))
                return Task.FromResult(AuthenticateResult.NoResult());
            try
            {
                var bytes = Convert.FromBase64String(Request.Headers["x-apiKey"]);
                var credentials = Encoding.UTF8.GetString(bytes);

                if (!String.Equals(credentials, SecretFetcher.GetSecret()))
                {
                    return Task.FromResult(AuthenticateResult.Fail("Authentication invalid."));
                }
                var claims = new[] {new Claim(ClaimTypes.Name, credentials)};
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return Task.FromResult(AuthenticateResult.Success(ticket));
                
            }
            catch
            {
                return Task.FromResult(AuthenticateResult.Fail("Authentication Failed"));
            }
        }
    }
}