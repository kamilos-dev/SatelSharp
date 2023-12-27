namespace SatelSharp.Responses;

public record IntegraVersionResponse(
    IntegraVersionIntegraType IntegraType,
    string Version,
    Language Language,
    bool IsSettingsStoredInFlash)
{
    public IntegraVersionIntegraType IntegraType { get; set; } = IntegraType;

    public string Version { get; set; } = Version;

    public Language Language { get; set; } = Language;

    public bool IsSettingsStoredInFlash { get; set; } = IsSettingsStoredInFlash;
}

public enum IntegraVersionIntegraType
{
    Integra24 = 0,
    Integra32 = 1,
    Integra64 = 2,
    Integra128= 3,
    Integra128WrlSim300 = 4,
    Integra128WrlLeon = 132,
    Integra64Plus = 66,
    Integra128Plus = 67,
    Integra256Plus = 72,
}

/// <summary>
/// TODO - dodać opis czemu nie Country
/// </summary>
public enum Language
{
    Poland = 0,
    English = 1,
    Ukraine = 2,
    Russia = 3,
    Germany = 4,
    Slovakia = 5,
    Italy = 6,
    Czech = 7,
    Hungary = 8,
    Netherlands = 9,
    Ireland = 10,
    Norway = 11,
    Denmark = 12,
    Iceland = 13,
    Greece = 14,
    France = 15,
    Spain = 16,
    Portugal = 17,
    Finland = 18,
    Slovenia = 19,
    Sweden = 20,
    Turkey = 21,
    Romania = 22,
    Estonia = 23,
    Bulgaria = 24,
    Latvia = 25,
    Macedonia = 26,
    Serbia = 27,
    Albania = 28,
    Australia = 29,
    Lithuania = 30,
    Unspecified = 255
}