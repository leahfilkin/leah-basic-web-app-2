using System;

namespace BasicWebApp.Setup
{
    public class SecretFetcher
    {
        public static string GetSecret()
        {
            return Environment.GetEnvironmentVariable("AUTHENTICATION_TOKEN");
        }

    }
}