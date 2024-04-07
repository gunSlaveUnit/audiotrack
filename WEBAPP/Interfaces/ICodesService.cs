namespace WEBAPI.Interfaces;

public interface ICodesService
{
    public string GenerateNumericCode(int lenght = 6);
    public string GenerateToken(int length = 256);
}