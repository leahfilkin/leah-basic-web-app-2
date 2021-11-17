using System;
using System.Text;

namespace BasicWebApp.Setup
{
    public static class SecretFetcher
    {
        public static string GetSecret()
        {
            var env = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("AUTHENTICATION_TOKEN"));
            return Convert.ToBase64String(env);
        }

    }
}