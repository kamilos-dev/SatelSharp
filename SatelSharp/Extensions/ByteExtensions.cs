using SatelSharp.Utils;

namespace SatelSharp.Extensions;

public static class ByteExtensions
{
    public static Bit GetBitOnIndex(this byte byteValue, short index)
    {
        var decValue = Convert.ToInt32(byteValue);

        for (var b = 0; b < 8; b++)
        {
            if (b != index)
            {
                continue;
            }

            var shiftedByte = 1 << b;
            var result = shiftedByte & decValue;

            if (result == 0)
            {
                return Bit.Zero;
            }

            return Bit.One;
        }

        throw new ArgumentException("Invalid index");
    }

    public static byte GetByteOnIndexRange(this byte byteValue, short startIndex, short endIndex)
    {
        var decValue = Convert.ToInt32(byteValue);
        var result = 0;

        for (var b = 0; b < 8; b++)
        {
            if (b < startIndex || b > endIndex)
            {
                continue;
            }

            var shiftedByte = 1 << b;
            var bitValue = shiftedByte & decValue;

            if (bitValue == 0)
            {
                continue;
            }

            result += shiftedByte;
        }

        return Convert.ToByte(result);
    }

    public static byte GetByteWithGivenBitOnIndex(this byte byteValue, int index, Bit bit)
    {
        if (bit == Bit.One)
        {
            return (byte)(byteValue | (1 << index));
        }

        return (byte)(byteValue & ~(1 << index));
    }

    public static byte InsertDecimalNumberOnIndexes(this byte byteValue, int value, int startIndex, int endIndex)
    {
        if (startIndex < 0 || startIndex > 7 || endIndex < 0 || endIndex > 7 || startIndex > endIndex)
        {
            throw new ArgumentException("Invalid start or end position");
        }

        var mask = (1 << (endIndex - startIndex + 1)) - 1;

        var clearedBits = (byte)(byteValue & ~(mask << startIndex));
        var insertedValue = (byte)((value & mask) << startIndex);
        var result = (byte)(clearedBits | insertedValue);

        return result;
    }
}
