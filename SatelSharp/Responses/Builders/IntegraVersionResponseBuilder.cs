using SatelSharp.Utils;

namespace SatelSharp.Responses.Builders;

public static class IntegraVersionResponseBuilder
{
    public static IntegraVersionResponse Build(byte[] bytes)
    {
        var integraType = GetIntegraType(bytes);
        var version = GetVersion(bytes);
        var language = GetLanguage(bytes);
        var isSettingsStoredInFlash = GetIsSettingStoredInFlash(bytes);

        return new IntegraVersionResponse(
            integraType,
            version,
            language,
            isSettingsStoredInFlash);
    }

    private static IntegraVersionIntegraType GetIntegraType(byte[] bytes)
    {
        var byteValue = bytes[0];

        switch (byteValue)
        {
            case 0:
                return IntegraVersionIntegraType.Integra24;
            case 1:
                return IntegraVersionIntegraType.Integra32;
            case 2:
                return IntegraVersionIntegraType.Integra64;
            case 3:
                return IntegraVersionIntegraType.Integra128;
            case 4:
                return IntegraVersionIntegraType.Integra128WrlSim300;
            case 66:
                return IntegraVersionIntegraType.Integra64Plus;
            case 67:
                return IntegraVersionIntegraType.Integra128Plus;
            case 72:
                return IntegraVersionIntegraType.Integra256Plus;
            case 132:
                return IntegraVersionIntegraType.Integra128WrlLeon;
            default:
                throw new InvalidOperationException("Unknown IntegraType");
        }
    }

    private static string GetVersion(byte[] bytes)
    {
        var versionBytes = bytes[1..12];
        return SatelVersionBuilder.Build(versionBytes);
    }

    private static Language GetLanguage(byte[] bytes)
    {
        var byteValue = bytes[12];
        return (Language) byteValue;
    }

    private static bool GetIsSettingStoredInFlash(byte[] bytes)
    {
        var byteValue = bytes[13];
        return byteValue == 255;
    }
}
