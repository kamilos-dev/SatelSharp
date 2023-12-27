namespace SatelSharp.Responses;

public record IntRsOrEthm1ModuleVersionResponse(
    string Version, bool IsSupporting32Bits, bool IsServingTroublePart8, bool IsServingArmingWithNoBypass)
{
    public string Version { get; set; } = Version;
    public bool IsSupporting32Bits { get; set; } = IsSupporting32Bits;
    public bool IsServingTroublePart8 { get; set; } = IsServingTroublePart8;
    public bool IsServingArmingWithNoBypass { get; set; } = IsServingArmingWithNoBypass;
}
