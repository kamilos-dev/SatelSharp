using SatelSharp.Extensions;
using SatelSharp.Responses;
using SatelSharp.Utils;

namespace SatelSharp.UnitTests.FakeDevice.ResponseBuilders;

internal static class TestRtcAndBasicStatusResponseBuilder
{
    internal static byte[] GetResponse(RtcAndBasicStatusResponse response)
    {
        var dateTimeBits = GetDateTimeBytes(response.DateTime);
        
        var seventhBit = GetDayOfWeekByte(response.DayOfWeek);
        seventhBit = GetIsServiceModeByte(seventhBit, response.IsServiceMode);
        seventhBit = GetIsTroubleInSystemByte(seventhBit, response.IsTroubleInSystem);

        var eightBit = GetIsAcu100PresentInSystemByte(response.IsAcu100PresentInSystem);
        eightBit = GetIsIntRxPresentInSystemByte(eightBit, response.IsIntRxPresentInSystem);
        eightBit = GetIsTroublesMemorySetByte(eightBit, response.IsTroublesMemorySet);
        eightBit = GetIsGrade2Or3OptionSetByte(eightBit, response.IsGrade2Or3OptionSet);
        eightBit = GetIntegraTypeByte(eightBit, response.IntegraType);
        
        return Array.Empty<byte>()
            .Concat(dateTimeBits)
            .Concat([seventhBit, eightBit])
            .ToArray();
    }

    private static byte[] GetDateTimeBytes(DateTime dateTime)
    {
        var valueBytes = new byte[7];
        
        var formattedDateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        var dateFormat = "yyyy-MM-dd HH:mm:ss";

        var parsedDateTime = DateTime.ParseExact(
            formattedDateTime,
            dateFormat,
            System.Globalization.CultureInfo.InvariantCulture);
        
        var year = Convert.ToInt32(parsedDateTime.Year.ToString(), 16);
        var month = (byte)Convert.ToInt32(parsedDateTime.Month.ToString(), 16);
        var day = (byte)Convert.ToInt32(parsedDateTime.Day.ToString(), 16);
        var hour = (byte)Convert.ToInt32(parsedDateTime.Hour.ToString(), 16);
        var minutes = (byte)Convert.ToInt32(parsedDateTime.Minute.ToString(), 16);
        var seconds = (byte)Convert.ToInt32(parsedDateTime.Second.ToString(), 16);
        
        valueBytes[0] = (byte)((year >> 8) & 0xFF);
        valueBytes[1] = (byte)(year & 0xFF);
        valueBytes[2] = month;
        valueBytes[3] = day;
        valueBytes[4] = hour;
        valueBytes[5] = minutes;
        valueBytes[6] = seconds;

        return valueBytes;
    }
    
    private static byte GetDayOfWeekByte(DayOfWeek dayOfWeek)
    {
        byte byteValue = dayOfWeek switch
        {
            DayOfWeek.Monday => 0,
            DayOfWeek.Tuesday => 1,
            DayOfWeek.Wednesday => 2,
            DayOfWeek.Thursday => 3,
            DayOfWeek.Friday => 4,
            DayOfWeek.Saturday => 5,
            DayOfWeek.Sunday => 6,
            _ => throw new InvalidOperationException("Unknown day")
        };

        return byteValue;
    }
    
    private static byte GetIsServiceModeByte(byte byteValue, bool isServiceMode)
    {
        if (isServiceMode)
        {
            return byteValue.GetByteWithGivenBitOnIndex(7, Bit.One);
        }

        return byteValue;
    }
    
    private static byte GetIsTroubleInSystemByte(byte byteValue, bool isTroubleInSystem)
    {
        if (isTroubleInSystem)
        {
            byteValue = byteValue.GetByteWithGivenBitOnIndex(6, Bit.One);
        }

        return byteValue;
    }

    private static byte GetIsAcu100PresentInSystemByte(bool isAcu100PresentInSystem)
    {
        byte byteValue = 0;
        
        if (isAcu100PresentInSystem)
        {
            byteValue = byteValue.GetByteWithGivenBitOnIndex(7, Bit.One);
        }

        return byteValue;
    }

    private static byte GetIsIntRxPresentInSystemByte(byte byteValue, bool isIntRxPresentInSystem)
    {
        if (isIntRxPresentInSystem)
        {
            byteValue = byteValue.GetByteWithGivenBitOnIndex(6, Bit.One);
        }

        return byteValue;
    }

    private static byte GetIsTroublesMemorySetByte(byte byteValue, bool isTroublesMemorySet)
    {
        if (isTroublesMemorySet)
        {
            byteValue = byteValue.GetByteWithGivenBitOnIndex(5, Bit.One);
        }

        return byteValue;
    }

    private static byte GetIsGrade2Or3OptionSetByte(byte byteValue, bool isGrade2Or3OptionSet)
    {
        if (isGrade2Or3OptionSet)
        {
            byteValue = byteValue.GetByteWithGivenBitOnIndex(4, Bit.One);
        }

        return byteValue;
    }

    private static byte GetIntegraTypeByte(byte byteValue, RtcIntegraType integraType)
    {
        return byteValue.InsertDecimalNumberOnIndexes((int) integraType, 0, 3);
    }
}