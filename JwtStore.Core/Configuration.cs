namespace JwtStore.Core;

public static class Configuration
{
    public static SecretsConfiguration Secrets { get; set; } = new();
    public static EmailConfiguration Email { get; set; } = new();
    public static SendGridConfiguration SendGrid { get; set; } = new();
    public static DatabaseConfiguration Database { get; set; } = new();
    public static string PrivateString { get; set; } = "V+b|zUk{p8Q2OH2k&=+{zT-E25}XCc5!Z7Y0N&]!Yov5.YGKPi3K-Ro{$`']IR1";

    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
    }

    public class EmailConfiguration
    {
        public string DefaultFromEmail { get; set; } = "test@balta.io";
        public string DefaultFromName { get; set; } = "balta.io";
    }

    public class SendGridConfiguration
    {
        public string ApiKey { get; set; } = string.Empty;
    }

    public class SecretsConfiguration
    {
        public string ApiKey { get; set; } = string.Empty;
        public string JwtPrivateKey { get; set; } = string.Empty;
        public string PasswordSaltKey { get; set; } = string.Empty;
    }
}