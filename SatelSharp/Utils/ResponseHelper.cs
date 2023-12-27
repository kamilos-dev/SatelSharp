namespace SatelSharp.Utils;

public static class ResponseHelper
{
    public static IEnumerable<int> GetHighBitPositions(byte[] raw)
    {
        IEnumerable<int> ints = Array.Empty<int>();

        for (var i = 0; i < raw.Length; i++)
        {
            for (var b = 0; b < 8; b++)
            {
                var shiftedByte = 1 << b;
                var decValue = Convert.ToInt32(raw[i]);
                var result = shiftedByte & decValue;

                if (result != 0)
                {
                    var number = (8 * i) + b + 1;

                    ints = ints.Append(number);
                }
            }
        }

        return ints;
    }
}
