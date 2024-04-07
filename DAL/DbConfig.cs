namespace DAL;

public class DbConfig
{
    public string DatabaseName { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public string ConnectionString => $"mongodb://{Host}:{Port}";
}