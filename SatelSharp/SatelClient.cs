using SatelSharp.Responses;
using SatelSharp.Responses.Builders;
using SatelSharp.Utils;

namespace SatelSharp;

public class SatelClient
{
    private readonly ISatelDevice _satelDevice;

    private readonly bool? _isSupports32Bits;

    public SatelClient(ISatelDevice satelDevice)
    {
        _satelDevice = satelDevice;

        if(TryGetIsDeviceSupports32Bits(out var isSupports32Bits))
        {
            _isSupports32Bits = isSupports32Bits;
        }
    }

    /// <summary>
    /// Returns content bytes of response from Satel device.
    /// The result array does not contains a header, command, crc or footer section.
    /// </summary>
    /// <param name="requestByte">A byte that represents a request.</param>
    /// <returns>Byte array that represents a content from Satel device.</returns>
    public byte[] SendRequest(byte requestByte)
    {
        return ExecuteAndReturnBytes(requestByte);
    }

    /// <summary>
    /// Returns content bytes of response from Satel device.
    /// The result array does not contains a header, command, crc or footer section.
    /// </summary>
    /// <param name="requestBytes">A bytes that represents a request.</param>
    /// <returns>Byte array that represents a content from Satel device.</returns>
    public byte[] SendRequest(byte[] requestBytes)
    {
        return ExecuteAndReturnBytes(requestBytes);
    }

    /// <summary>
    /// Returns 'zones violation'
    /// </summary>
    /// <returns>A collection of violated zones.</returns>
    public IEnumerable<int> GetZonesViolationData()
    {
        const byte request = 0x00;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones tamper'
    /// </summary>
    /// <returns>A collection of tampered zones.</returns>
    public IEnumerable<int> GetZonesTamperData()
    {
        const byte request = 0x01;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones alarm'
    /// </summary>
    /// <returns>A collection of zones with alarm.</returns>
    public IEnumerable<int> GetZonesAlarmData()
    {
        const byte request = 0x02;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones tamper alarm'
    /// </summary>
    /// <returns>A collection of zones with tamper alarm.</returns>
    public IEnumerable<int> GetZonesTamperAlarmData()
    {
        const byte request = 0x03;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones alarm memory'
    /// </summary>
    /// <returns>A collection of zones alarm memory.</returns>
    public IEnumerable<int> GetZonesAlarmMemoryData()
    {
        const byte request = 0x04;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones tamper alarm memory'
    /// </summary>
    /// <returns>A collection of zones tamper alarm memory.</returns>
    public IEnumerable<int> GetZonesTamperAlarmMemoryData()
    {
        const byte request = 0x05;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones bypass'
    /// </summary>
    /// <returns>A collection of bypassed zones.</returns>
    public IEnumerable<int> GetZonesBypassData()
    {
        const byte request = 0x06;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones "no violation" trouble'
    /// </summary>
    /// <returns>A collection of zones with "no violation" trouble.</returns>
    public IEnumerable<int> GetZonesNoViolationTroubleData()
    {
        const byte request = 0x07;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones "long violation" trouble'
    /// </summary>
    /// <returns>A collection of zones with "long violation" trouble.</returns>
    public IEnumerable<int> GetZonesLongViolationTroubleData()
    {
        const byte request = 0x08;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'armed partitions (suppressed)'
    /// </summary>
    /// <returns>A collection of armed partitions (suppressed).</returns>
    public IEnumerable<int> GetArmedPartitionsSuppressedData()
    {
        const byte request = 0x09;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'armed partitions (really)'
    /// </summary>
    /// <returns>A collection of armed partitions (really).</returns>
    public IEnumerable<int> GetArmedPartitionsReallyData()
    {
        const byte request = 0x0A;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions armed in mode 2'
    /// </summary>
    /// <returns>A collection of partitions armed in mode 2.</returns>
    public IEnumerable<int> GetPartitionsArmedInMode2Data()
    {
        const byte request = 0x0B;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions armed in mode 3'
    /// </summary>
    /// <returns>A collection of partitions armed in mode 3.</returns>
    public IEnumerable<int> GetPartitionsArmedInMode3Data()
    {
        const byte request = 0x0C;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions with 1st code entered'
    /// </summary>
    /// <returns>A collection of partitions with 1st code entered.</returns>
    public IEnumerable<int> GetPartitionsWith1StCodeEnteredData()
    {
        const byte request = 0x0D;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    public IEnumerable<int> GetPartitionsEntryTimeData()
    {
        const byte request = 0x0E;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    public IEnumerable<int> GetPartitionsExitTimeGreaterThan10SecData()
    {
        const byte request = 0x0F;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    public IEnumerable<int> GetPartitionsExitTimeLessThan10SecData()
    {
        const byte request = 0x10;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions temporary blocked'
    /// </summary>
    /// <returns>A collection of temporary blocked partitions.</returns>
    public IEnumerable<int> GetPartitionsTemporaryBlockedData()
    {
        const byte request = 0x11;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions blocked for guard round'
    /// </summary>
    /// <returns>A collection of partitions blocked for guard round</returns>
    public IEnumerable<int> GetPartitionsBlockedForGuardRoundData()
    {
        const byte request = 0x12;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions alarm'
    /// </summary>
    /// <returns>A collection of alarmed partitions</returns>
    public IEnumerable<int> GetPartitionsAlarmData()
    {
        const byte request = 0x13;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions fire alarm'
    /// </summary>
    /// <returns>A collection of fire alarmed partitions</returns>
    public IEnumerable<int> GetPartitionsFireAlarmData()
    {
        const byte request = 0x14;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions alarm memory'
    /// </summary>
    /// <returns>A collection of alarm memory partitions</returns>
    public IEnumerable<int> GetPartitionsAlarmMemoryData()
    {
        const byte request = 0x15;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions fire alarm memory'
    /// </summary>
    /// <returns>A collection of fire alarm memory partitions</returns>
    public IEnumerable<int> GetPartitionsFireAlarmMemoryData()
    {
        const byte request = 0x16;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'outputs states'
    /// </summary>
    /// <returns>A collection of outputs stated</returns>
    public IEnumerable<int> GetOutputsStateData()
    {
        const byte request = 0x17;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'doors opened'
    /// </summary>
    /// <returns>A collection of opened doors</returns>
    public IEnumerable<int> GetDoorsOpenedData()
    {
        const byte request = 0x18;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'doors opened long'
    /// </summary>
    /// <returns>A collection of long opened doors</returns>
    public IEnumerable<int> GetDoorsOpenedLongData()
    {
        const byte request = 0x19;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns RTC and basic status about device.
    /// </summary>
    /// <returns>An <see cref="RtcAndBasicStatusResponse"/> object.</returns>
    public RtcAndBasicStatusResponse GetRtcAndBasicStatusBitsData()
    {
        const byte request = 0x1A;
        var bytes = ExecuteAndReturnBytes(request);

        return RtcAndBasicStatusResponseBuilder.Build(bytes);
    }

    /// <summary>
    /// Returns 'partitions with violated zones'
    /// </summary>
    /// <returns>A collection of partitions with violated zones</returns>
    public IEnumerable<int> GetPartitionsWithViolatedZonesData()
    {
        const byte request = 0x25;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones isolate'
    /// </summary>
    /// <returns>A collection of isolated zones</returns>
    public IEnumerable<int> GetZonesIsolateData()
    {
        const byte request = 0x26;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions with verified alarms'
    /// </summary>
    /// <returns>A collection of partitions with verified alarms</returns>
    public IEnumerable<int> GetPartitionsWithVerifiedAlarmData()
    {
        const byte request = 0x27;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones masked'
    /// </summary>
    /// <returns>A collection of masked zones</returns>
    public IEnumerable<int> GetZonesMaskedData()
    {
        const byte request = 0x28;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'zones masked memory'
    /// </summary>
    /// <returns>A collection of masked zones memory</returns>
    public IEnumerable<int> GetZonesMaskedMemoryData()
    {
        const byte request = 0x29;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions armed in mode 1'
    /// </summary>
    /// <returns>A collection of partitions armed in mode 1</returns>
    public IEnumerable<int> GetPartitionsArmedInMode1Data()
    {
        const byte request = 0x2A;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns 'partitions with warning alarms'
    /// </summary>
    /// <returns>A collection of partitions with warning alarms</returns>
    public IEnumerable<int> GetPartitionsWithWarningAlarmsData()
    {
        const byte request = 0x2B;
        return ExecuteAndReturnValuesInDecimalSystem(request);
    }

    /// <summary>
    /// Returns an INT-RS/ETHM-1 module version
    /// Modules earlier than 2013-11-08 do not know this command, so they will not reply.
    /// </summary>
    /// <returns>An <see cref="IntRsOrEthm1ModuleVersionResponse"/> object.</returns>
    public IntRsOrEthm1ModuleVersionResponse GetIntRsOrEthm1ModuleVersionData()
    {
        const byte request = 0x7C;
        var bytes = ExecuteAndReturnBytes(request);
        return IntRsOrEthm1ModuleVersionResponseBuilder.Build(bytes);
    }

    /// <summary>
    /// Returns an integra version response.
    /// </summary>
    /// <returns>An <see cref="IntegraVersionResponse"/> object.</returns>
    public IntegraVersionResponse GetIntegraVersionData()
    {
        const byte request = 0x7E;
        var bytes = ExecuteAndReturnBytes(request);
        return IntegraVersionResponseBuilder.Build(bytes);
    }

    private int[] ExecuteAndReturnValuesInDecimalSystem(byte requestByte)
    {
        const byte extraByte = 0x00;

        if (_isSupports32Bits.HasValue && _isSupports32Bits.Value)
        {
            return ExecuteAndReturnValuesInDecimalSystem([requestByte, extraByte]);
        }

        if (_isSupports32Bits == null)
        {
            try
            {
                return ExecuteAndReturnValuesInDecimalSystem([requestByte, extraByte]);
            }
            catch
            {
                // Empty for purpose.
            }
        }

        return ExecuteAndReturnValuesInDecimalSystem([requestByte]);
    }

    private int[] ExecuteAndReturnValuesInDecimalSystem(byte[] requestBytes)
    {
        var responseBytes = ExecuteAndReturnBytes(requestBytes);
        var result = ResponseHelper.GetHighBitPositions(responseBytes);

        return result.ToArray();
    }

    private byte[] ExecuteAndReturnBytes(byte requestByte)
    {
       return ExecuteAndReturnBytes([requestByte]);
    }

    private byte[] ExecuteAndReturnBytes(byte[] requestBytes)
    {
        var frame = FrameWrapper.WrapWithFrame(requestBytes);
        var rawResponse = _satelDevice.SendFrame(frame);
        var responseBody = FrameWrapper.UnwrapFromFrame(rawResponse, requestBytes);

        return responseBody;
    }

    private bool TryGetIsDeviceSupports32Bits(out bool? isSupports)
    {
        isSupports = null;

        try
        {
            isSupports = GetIntRsOrEthm1ModuleVersionData().IsSupporting32Bits;
            return true;
        }
        catch
        {
            // Some modules don't know this command.
        }

        return false;
    }
}
