using System.Text;
using WEBAPI.Interfaces;

namespace WEBAPI.Services;

public class CodesService : ICodesService
{
    private string _alphabet = "0123456789" +
                               "abcdefghijklmnopqrstuvwxyz" +
                               "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    public string GenerateNumericCode(int lenght = 6)
    {
        Random r = new Random();
        
        string code = "";
        for(int i = 0; i < lenght; ++i)
            code += r.Next(1, 10).ToString(); 
        
        return code;
    }

    public string GenerateToken(int length = 256)
    {
        var random = new Random();
        
        var sb = new StringBuilder(length - 1);
        for (var i = 0; i < length; ++i)
            sb.Append(_alphabet[random.Next(0, _alphabet.Length - 1)]);

        return sb.ToString();
    }
}