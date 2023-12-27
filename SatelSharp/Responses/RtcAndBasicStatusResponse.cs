namespace SatelSharp.Responses;

public record RtcAndBasicStatusResponse(
    DateTime DateTime,
    DayOfWeek DayOfWeek,
    bool IsServiceMode,
    bool IsTroubleInSystem,
    bool IsAcu100PresentInSystem,
    bool IsIntRxPresentInSystem,
    bool IsTroublesMemorySet,
    bool IsGrade2Or3OptionSet,
    RtcIntegraType IntegraType)
{
    public DateTime DateTime { get; set; } = DateTime;

    public DayOfWeek DayOfWeek { get; set; } = DayOfWeek;

    public bool IsServiceMode { get; set; } = IsServiceMode;

    public bool IsTroubleInSystem { get; set; } = IsTroubleInSystem;

    public bool IsAcu100PresentInSystem { get; set; } = IsAcu100PresentInSystem;

    public bool IsIntRxPresentInSystem { get; set; } = IsIntRxPresentInSystem;

    public bool IsTroublesMemorySet { get; set; } = IsTroublesMemorySet;

    public bool IsGrade2Or3OptionSet { get; set; } = IsGrade2Or3OptionSet;

    public RtcIntegraType IntegraType { get; set; } = IntegraType;
}

public enum RtcIntegraType
{
    Integra24 = 0,
    Integra32 = 1,
    Integra64OrPlus = 2,
    Integra128OrPlus = 3,
    Integra128Wrl = 4,
    Integra256Plus = 8
}
