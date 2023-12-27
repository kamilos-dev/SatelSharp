using SatelSharp.Extensions;
using SatelSharp.Utils;

namespace SatelSharp.Responses.Builders;

public static class IntRsOrEthm1ModuleVersionResponseBuilder
{
    public static IntRsOrEthm1ModuleVersionResponse Build(byte[] bytes)
    {
        var version = SatelVersionBuilder.Build(bytes[0..11]);
        var isSupporting32Bits = bytes[11].GetBitOnIndex(0) == Bit.One;
        var isServingTroublePart8 = bytes[11].GetBitOnIndex(1) == Bit.One;
        var isServingArmingWithNoBypass = bytes[11].GetBitOnIndex(2) == Bit.One;

        return new IntRsOrEthm1ModuleVersionResponse(
            version, isSupporting32Bits, isServingTroublePart8, isServingArmingWithNoBypass);
    }
}
