namespace SatelSharp.Utils;

public record Bit
{
    private readonly bool _value;

    private Bit(bool value)
    {
        _value = value;
    }

    public static Bit One => new(true);

    public static Bit Zero => new(false);
}
