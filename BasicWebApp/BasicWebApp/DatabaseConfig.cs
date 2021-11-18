using System.Collections;

namespace BasicWebApp
{
    public class DatabaseConfig
    {
        public string Host { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConnectionString => $"Host={Host};Database={Name};Username={Username};Password={Password};";
    }
}