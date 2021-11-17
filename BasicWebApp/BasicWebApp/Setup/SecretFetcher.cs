using System;
using System.Text;

namespace BasicWebApp.Setup
{
    public static class SecretFetcher
    {
        public static string GetSecret()
        {
            return Environment.GetEnvironmentVariable("AUTHENTICATION_TOKEN");
        }

    }
}