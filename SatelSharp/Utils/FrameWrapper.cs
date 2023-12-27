namespace SatelSharp.Utils;

public static class FrameWrapper
{
    private static readonly byte[] HeaderBytes = [0xFE, 0xFE];
    private static readonly byte[] FooterBytes = [0xFE, 0x0D];

    private const byte EndOfFrameByte = 0xFE;
    private const byte EndOfFramePostfixByte = 0xF0;

    private const short CrcLength = 2;

    public static byte[] WrapWithFrame(byte requestByte, byte[] requestBody)
    {
        var bytes = Array.Empty<byte>()
            .Concat([requestByte])
            .Concat(requestBody).ToArray();

        return WrapWithFrame(bytes);
    }

    public static byte[] WrapWithFrame(byte requestByte)
    {
        return WrapWithFrame([requestByte]);
    }

    public static byte[] WrapWithFrame(params byte[] bytes)
    {
        var crcBytes = CrcCalculator.Calculate(bytes);

        if (ContainsEndOfFrameByte(bytes))
        {
            bytes = AppendSpecialByte(bytes);
        }

        var frame = Array.Empty<byte>()
            .Concat(HeaderBytes)
            .Concat(bytes)
            .Concat(crcBytes)
            .Concat(FooterBytes)
            .ToArray();

        return frame;
    }

    public static byte[] UnwrapFromFrame(byte[] bytes, byte[] requestBytes)
    {
        var trimmedResponse = TrimResponse(bytes);

        var firstBytes = trimmedResponse
            .Take(HeaderBytes.Length)
            .ToArray();

        if (!firstBytes.SequenceEqual(HeaderBytes))
        {
            throw new Exception("Invalid response. No header bytes in response.");
        }

        var requestByteFromResponse = trimmedResponse[HeaderBytes.Length];

        if (requestByteFromResponse != requestBytes[0])
        {
            throw new Exception("Invalid response. Invalid request byte.");
        }

        var lastBytes = trimmedResponse
            .Skip(bytes.Length - FooterBytes.Length)
            .ToArray();

        if (!lastBytes.SequenceEqual(FooterBytes))
        {
            throw new Exception("Invalid response. No footer bytes in response.");
        }

        var contentBytes = trimmedResponse
            .Skip(HeaderBytes.Length)
            .Take(bytes.Length - HeaderBytes.Length - FooterBytes.Length - CrcLength)
            .ToArray();

        var crcBytes = CrcCalculator.Calculate(contentBytes);

        var crcBytesFromResponse = trimmedResponse
            .Skip(bytes.Length - FooterBytes.Length - CrcLength)
            .Take(CrcLength)
            .ToArray();

        if (!crcBytes.SequenceEqual(crcBytesFromResponse))
        {
            throw new Exception("Invalid response. Invalid CRC.");
        }

        var contentBytesWithoutCrc = trimmedResponse
            // +/- 1 - request byte
            .Skip(HeaderBytes.Length + 1)
            .Take(trimmedResponse.Length - 1 - HeaderBytes.Length - FooterBytes.Length - CrcLength)
            .ToArray();

        return contentBytesWithoutCrc;
    }

    private static bool ContainsEndOfFrameByte(byte[] bytes)
    {
        return bytes.Contains(EndOfFrameByte);
    }

    private static byte[] AppendSpecialByte(byte[] bytes)
    {
        var result = new List<byte>();

        foreach (var b in bytes)
        {
            result.Add(b);

            if (b == EndOfFrameByte)
            {
                result.Add(EndOfFramePostfixByte);
            }
        }

        return result.ToArray();
    }

    private static byte[] TrimResponse(byte[] responseBytes)
    {
        var contentIndex = FindSequence(responseBytes, 0xFE, 0x0D);

        if (contentIndex == -1)
        {
            throw new Exception("Invalid response");
        }

        return responseBytes[0..(contentIndex + 1)];
    }

    private static int FindSequence(byte[] array, byte byte1, byte byte2)
    {
        for (var i = array.Length - 1; i > 1; i--)
        {
            if (array[i] == byte2 && array[i - 1] == byte1)
            {
                return i;
            }
        }
        return -1;
    }
}
