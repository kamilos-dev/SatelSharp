using SatelSharp.Extensions;
using SatelSharp.Utils;

namespace SatelSharp.Responses.Builders;

public static class RtcAndBasicStatusResponseBuilder
{
    public static RtcAndBasicStatusResponse Build(byte[] bytes)
    {
        var dateTime = GetDateTime(bytes);
        var dayOfWeek = GetDayOfWeek(bytes);
        var isServiceMode = GetIsServiceMode(bytes);
        var isTroubleInSystem = GetIsTroubleInSystem(bytes);
        var isAcu100PresentInSystem = GetIsAcu100PresentInSystem(bytes);
        var isIntRxPresentInSystem = GetIsIntRxPresentInSystem(bytes);
        var isTroublesMemorySet = GetIsTroublesMemorySet(bytes);
        var isGrade2Or3OptionSet = GetIsGrade2Or3OptionSet(bytes);
        var integraType = GetIntegraType(bytes);

        return new RtcAndBasicStatusResponse(
            dateTime,
            dayOfWeek,
            isServiceMode,
            isTroubleInSystem,
            isAcu100PresentInSystem,
            isIntRxPresentInSystem,
            isTroublesMemorySet,
            isGrade2Or3OptionSet,
            integraType);
    }

    private static DateTime GetDateTime(byte[] bytes)
    {
        var year = $"{(bytes[0] << 8) | bytes[1]:X}";
        var month = $"{bytes[2]:X2}";
        var day = $"{bytes[3]:X2}";
        var hour = $"{bytes[4]:X2}";
        var minutes = $"{bytes[5]:X2}";
        var seconds = $"{bytes[6]:X2}";

        var date = $"{year}-{month}-{day} {hour}:{minutes}:{seconds}";
        var dateFormat = "yyyy-MM-dd HH:mm:ss";

        return DateTime.ParseExact(
            date,
            dateFormat,
            System.Globalization.CultureInfo.InvariantCulture);
    }

    private static DayOfWeek GetDayOfWeek(byte[] bytes)
    {
        var byteValue = bytes[7];
        var byteValueInRange = byteValue.GetByteOnIndexRange(0, 2);

        switch (byteValueInRange)
        {
            case 0:
                return DayOfWeek.Monday;
            case 1:
                return DayOfWeek.Tuesday;
            case 2:
                return DayOfWeek.Wednesday;
            case 3:
                return DayOfWeek.Thursday;
            case 4:
                return DayOfWeek.Friday;
            case 5:
                return DayOfWeek.Saturday;
            case 6:
                return DayOfWeek.Sunday;
            default:
                throw new InvalidOperationException("Unknown day");
        }
    }

    private static bool GetIsServiceMode(byte[] bytes)
    {
        var byteValue = bytes[7];
        return byteValue.GetBitOnIndex(7) == Bit.One;
    }

    private static bool GetIsTroubleInSystem(byte[] bytes)
    {
        var byteValue = bytes[7];
        return byteValue.GetBitOnIndex(6) == Bit.One;
    }

    private static bool GetIsAcu100PresentInSystem(byte[] bytes)
    {
        var byteValue = bytes[8];
        return byteValue.GetBitOnIndex(7) == Bit.One;
    }

    private static bool GetIsIntRxPresentInSystem(byte[] bytes)
    {
        var byteValue = bytes[8];
        return byteValue.GetBitOnIndex(6) == Bit.One;
    }

    private static bool GetIsTroublesMemorySet(byte[] bytes)
    {
        var byteValue = bytes[8];
        return byteValue.GetBitOnIndex(5) == Bit.One;
    }

    private static bool GetIsGrade2Or3OptionSet(byte[] bytes)
    {
        var byteValue = bytes[8];
        return byteValue.GetBitOnIndex(4) == Bit.One;
    }

    private static RtcIntegraType GetIntegraType(byte[] bytes)
    {
         var byteValue = bytes[8];
         var number = byteValue.GetByteOnIndexRange(0, 3);
         return (RtcIntegraType) number;
    }
}
