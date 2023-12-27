using System.Text;
using SatelSharp.Extensions;
using SatelSharp.Responses;
using SatelSharp.Utils;

namespace SatelSharp.UnitTests.FakeDevice.ResponseBuilders;

internal static class TestIntRsOrEthm1ModuleVersionResponseBuilder
{
    internal static byte[] GetResponse(IntRsOrEthm1ModuleVersionResponse response)
    {
        var versionBytes = GetVersionBytes(response.Version);

        var twelfthByte = (byte) 0;
        
        twelfthByte = GetIsSupporting32BitsByte(twelfthByte, response.IsSupporting32Bits);
        twelfthByte = GetIsServingTroublePart8Byte(twelfthByte, response.IsServingTroublePart8);
        twelfthByte = GetIsServingArmingWithNoBypassByte(twelfthByte, response.IsServingArmingWithNoBypass);
        
        return Array.Empty<byte>()
            .Concat(versionBytes)
            .Concat([twelfthByte])
            .ToArray();
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
    
    private static byte GetIsSupporting32BitsByte(byte byteValue, bool isSupporting32Bits)
    {
        if (isSupporting32Bits)
        {
            return byteValue.GetByteWithGivenBitOnIndex(0, Bit.One);
        }

        return byteValue;
    }
    
    private static byte GetIsServingTroublePart8Byte(byte byteValue, bool isServingTroublePart8)
    {
        if (isServingTroublePart8)
        {
            return byteValue.GetByteWithGivenBitOnIndex(1, Bit.One);
        }

        return byteValue;
    }
    
    private static byte GetIsServingArmingWithNoBypassByte(byte byteValue, bool isServingTroublePart8)
    {
        if (isServingTroublePart8)
        {
            return byteValue.GetByteWithGivenBitOnIndex(2, Bit.One);
        }

        return byteValue;
    }
}