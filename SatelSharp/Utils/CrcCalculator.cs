namespace SatelSharp.Utils;

public static class CrcCalculator
{
    public static byte[] Calculate(byte[] bytes)
    {
        ushort crc = 0x147A;

        foreach (var b in bytes)
        {
            crc = CircularShiftLeft(crc, 1);
            crc ^= 0xFFFF;

            crc += (ushort)((byte)(crc >> 8) + b);
        }

        var crcBytes = BitConverter.GetBytes(crc).Reverse().ToArray();
        return crcBytes;
    }

    private static ushort CircularShiftLeft(ushort value, int shift)
    {
        const int max = 16;
        var shiftAmount = shift % max;

        var shiftedValue = (ushort)((value << shiftAmount) | (value >> (max - shiftAmount)));

        return shiftedValue;
    }
}
