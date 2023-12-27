using System.Text;
using SatelSharp.Responses;

namespace SatelSharp.UnitTests.FakeDevice.ResponseBuilders;

internal static class TestIntegraVersionResponseBuilder
{
    internal static byte[] GetResponse(IntegraVersionResponse response)
    {
       var integraTypeByte = GetIntegraTypeByte(response.IntegraType);
       var versionBytes = GetVersionBytes(response.Version);
       var languageByte = GetLanguageByte(response.Language);
       var isSettingsStoredInFlashByte = GetIsSettingsStoredInFlashByte(response.IsSettingsStoredInFlash);
       
       return Array.Empty<byte>()
           .Concat([integraTypeByte])
           .Concat(versionBytes)
           .Concat([languageByte, isSettingsStoredInFlashByte])
           .ToArray();
    }
    
    private static byte GetIntegraTypeByte(IntegraVersionIntegraType integraType)
    {
        switch (integraType)
        {
            case IntegraVersionIntegraType.Integra24:
                return 0;
            case IntegraVersionIntegraType.Integra32:
                return 1;
            case IntegraVersionIntegraType.Integra64:
                return 2;
            case IntegraVersionIntegraType.Integra128:
                return 3;
            case IntegraVersionIntegraType.Integra128WrlSim300:
                return 4;
            case IntegraVersionIntegraType.Integra64Plus:
                return 66;
            case IntegraVersionIntegraType.Integra128Plus:
                return 67;
            case IntegraVersionIntegraType.Integra256Plus:
                return 72;
            case IntegraVersionIntegraType.Integra128WrlLeon:
                return 132;
            default:
                throw new InvalidOperationException("Unknown IntegraType");
        }
    }
    
    private static byte[] GetVersionBytes(string version)
    {
        var versionWithoutSpecialCharacters = version
            .Replace(".", "")
            .Replace(" ", "")
            .Replace("-", "");
        
        var versionBytes = Encoding.ASCII.GetBytes(versionWithoutSpecialCharacters);

        if (versionBytes.Length > 11)
        {
            throw new ArgumentException("Version is too long.");
        }

        return versionBytes;
    }
    
    private static byte GetLanguageByte(Language language)
    {
        return (byte) language;
    }
    
    private static byte GetIsSettingsStoredInFlashByte(bool isSettingsStoredInFlash)
    {
        return isSettingsStoredInFlash ? (byte) 255 : (byte) 0;
    }
}