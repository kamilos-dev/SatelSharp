using SatelSharp.Responses;
using SatelSharp.UnitTests.FakeDevice.ResponseBuilders;
using SatelSharp.Utils;

namespace SatelSharp.UnitTests.FakeDevice;

public class FakeTcpSatelDevice : ISatelDevice
{
    private byte[] _zonesViolation = Array.Empty<byte>();
    private byte[] _zonesTamper = Array.Empty<byte>();
    private byte[] _zonesAlarm = Array.Empty<byte>();
    private byte[] _zonesTamperAlarm = Array.Empty<byte>();
    private byte[] _zonesAlarmMemory = Array.Empty<byte>();
    private byte[] _zonesTamperAlarmMemory = Array.Empty<byte>();
    private byte[] _zonesBypass = Array.Empty<byte>();
    private byte[] _zonesNoViolationTrouble = Array.Empty<byte>();
    private byte[] _zonesLongViolationTrouble = Array.Empty<byte>();
    private byte[] _armedPartitionsSuppressed = Array.Empty<byte>();
    private byte[] _armedPartitionsReally = Array.Empty<byte>();
    private byte[] _partitionsArmedInMode2 = Array.Empty<byte>();
    private byte[] _partitionsArmedInMode3 = Array.Empty<byte>();
    private byte[] _partitionsWith1StCodeEntered = Array.Empty<byte>();
    private byte[] _partitionsEntryTime = Array.Empty<byte>();
    private byte[] _partitionsExitTimeGreaterThan10Sec = Array.Empty<byte>();
    private byte[] _partitionsExitTimeLessThan10Sec = Array.Empty<byte>();
    private byte[] _partitionsTemporaryBlocked = Array.Empty<byte>();
    private byte[] _partitionsBlockedForGuardRound = Array.Empty<byte>();
    private byte[] _partitionsAlarm = Array.Empty<byte>();
    private byte[] _partitionsFireAlarm = Array.Empty<byte>();
    private byte[] _partitionsAlarmMemory = Array.Empty<byte>();
    private byte[] _partitionsFireAlarmMemory = Array.Empty<byte>();
    private byte[] _outputsState = Array.Empty<byte>();
    private byte[] _doorsOpened = Array.Empty<byte>();
    private byte[] _doorsOpenedLong = Array.Empty<byte>();
    private byte[] _partitionsWithViolatedZones = Array.Empty<byte>();
    private byte[] _zonesIsolate = Array.Empty<byte>();
    private byte[] _partitionsWithVerifiedAlarm = Array.Empty<byte>();
    private byte[] _zonesMasked = Array.Empty<byte>();
    private byte[] _zonesMaskedMemory = Array.Empty<byte>();
    private byte[] _partitionsArmedInMode1 = Array.Empty<byte>();
    private byte[] _partitionsWithWarningAlarms = Array.Empty<byte>();
    private RtcAndBasicStatusResponse? _rtcAndBasicStatusResponse;
    private IntRsOrEthm1ModuleVersionResponse? _intRsOrEthm1ModuleVersionResponse;
    private IntegraVersionResponse? _integraVersionResponse;

    public void SetZonesViolation(params byte[] zones)
    {
        _zonesViolation = zones;
    }
    
    public void ResetZonesViolation()
    {
        _zonesViolation = Array.Empty<byte>();
    }
    
    public void SetZonesTamper(params byte[] zones)
    {
        _zonesTamper = zones;
    }
    
    public void ResetZonesTamper()
    {
        _zonesTamper = Array.Empty<byte>();
    }
    
    public void SetZonesAlarm(params byte[] zones)
    {
        _zonesAlarm = zones;
    }
    
    public void ResetZonesAlarm()
    {
        _zonesAlarm = Array.Empty<byte>();
    }
    
    public void SetZonesTamperAlarm(params byte[] zones)
    {
        _zonesTamperAlarm = zones;
    }
    
    public void ResetZonesTamperAlarm()
    {
        _zonesTamperAlarm = Array.Empty<byte>();
    }
    
    public void SetZonesAlarmMemory(params byte[] zones)
    {
        _zonesAlarmMemory = zones;
    }
    
    public void ResetZonesAlarmMemory()
    {
        _zonesAlarmMemory = Array.Empty<byte>();
    }
    
    public void SetZonesTamperAlarmMemory(params byte[] zones)
    {
        _zonesTamperAlarmMemory = zones;
    }
    
    public void ResetZonesTamperAlarmMemory()
    {
        _zonesTamperAlarmMemory = Array.Empty<byte>();
    }
    
    public void SetZonesBypass(params byte[] zones)
    {
        _zonesBypass = zones;
    }
    
    public void ResetZonesBypass()
    {
        _zonesBypass = Array.Empty<byte>();
    }
    
    public void SetZonesNoViolationTrouble(params byte[] zones)
    {
        _zonesNoViolationTrouble = zones;
    }
    
    public void ResetZonesNoViolationTrouble()
    {
        _zonesNoViolationTrouble = Array.Empty<byte>();
    }
    
    public void SetZonesLongViolationTrouble(params byte[] zones)
    {
        _zonesLongViolationTrouble = zones;
    }
    
    public void SetArmedPartitionsSuppressed(params byte[] partitions)
    {
        _armedPartitionsSuppressed = partitions;
    }
    
    public void SetArmedPartitionsReally(params byte[] partitions)
    {
        _armedPartitionsReally = partitions;
    }
    
    public void SetPartitionsArmedInMode2(params byte[] partitions)
    {
        _partitionsArmedInMode2 = partitions;
    }
    
    public void SetPartitionsArmedInMode3(params byte[] partitions)
    {
        _partitionsArmedInMode3 = partitions;
    }
    
    public void SetPartitionsWith1StCodeEntered(params byte[] partitions)
    {
        _partitionsWith1StCodeEntered = partitions;
    }
    
    public void SetPartitionsEntryTime(params byte[] partitions)
    {
        _partitionsEntryTime = partitions;
    }
    
    public void SetPartitionsExitTimeGreaterThan10Sec(params byte[] partitions)
    {
        _partitionsExitTimeGreaterThan10Sec = partitions;
    }
    
    public void SetPartitionsExitTimeLessThan10Sec(params byte[] partitions)
    {
        _partitionsExitTimeLessThan10Sec = partitions;
    }
    
    public void SetPartitionsTemporaryBlocked(params byte[] partitions)
    {
        _partitionsTemporaryBlocked = partitions;
    }
    
    public void SetPartitionsBlockedForGuardRound(params byte[] partitions)
    {
        _partitionsBlockedForGuardRound = partitions;
    }
    
    public void SetPartitionsAlarm(params byte[] partitions)
    {
        _partitionsAlarm = partitions;
    }
    
    public void SetPartitionsFireAlarm(params byte[] partitions)
    {
        _partitionsFireAlarm = partitions;
    }
    
    public void SetPartitionsAlarmMemory(params byte[] partitions)
    {
        _partitionsAlarmMemory = partitions;
    }
    
    public void SetPartitionsFireAlarmMemory(params byte[] partitions)
    {
        _partitionsFireAlarmMemory = partitions;
    }
    
    public void SetOutputsState(params byte[] outputs)
    {
        _outputsState = outputs;
    }
    
    public void SetDoorsOpened(params byte[] doors)
    {
        _doorsOpened = doors;
    }
    
    public void SetDoorsOpenedLong(params byte[] doors)
    {
        _doorsOpenedLong = doors;
    }
    
    public void SetPartitionsWithViolatedZones(params byte[] partitions)
    {
        _partitionsWithViolatedZones = partitions;
    }
    
    public void SetZonesIsolate(params byte[] zones)
    {
        _zonesIsolate = zones;
    }
    
    public void SetPartitionsWithVerifiedAlarm(params byte[] partitions)
    {
        _partitionsWithVerifiedAlarm = partitions;
    }
    
    public void SetZonesMasked(params byte[] zones)
    {
        _zonesMasked = zones;
    }
    
    public void SetZonesMaskedMemory(params byte[] zones)
    {
        _zonesMaskedMemory = zones;
    }
    
    public void SetPartitionsArmedInMode1(params byte[] zones)
    {
        _partitionsArmedInMode1 = zones;
    }
    
    public void SetPartitionsWithWarningAlarms(params byte[] zones)
    {
        _partitionsWithWarningAlarms = zones;
    }

    public void SetRtcAndBasicStatusBits(
        DateTime dateTime,
        DayOfWeek dayOfWeek,
        bool isServiceMode,
        bool isTroubleInSystem,
        bool isAcu100InSystem,
        bool isIntRxInSystem,
        bool isTroublesMemorySet,
        bool isGrade2Or3OptionSet,
        RtcIntegraType integraType)
    {
        _rtcAndBasicStatusResponse = new RtcAndBasicStatusResponse(
            dateTime,
            dayOfWeek,
            isServiceMode,
            isTroubleInSystem,
            isAcu100InSystem,
            isIntRxInSystem,
            isTroublesMemorySet,
            isGrade2Or3OptionSet,
            integraType);
    }
    
    public void SetGetIntRsOrEthm1ModuleVersion(
        string version,
        bool isSupporting32Bits,
        bool isServingTroublePart8,
        bool isServingArmingWithNoBypass)
    {
        _intRsOrEthm1ModuleVersionResponse = new IntRsOrEthm1ModuleVersionResponse(
            version,
            isSupporting32Bits,
            isServingTroublePart8,
            isServingArmingWithNoBypass);
    }
    
    public void SetIntegraVersion(
        IntegraVersionIntegraType integraType,
        string version,
        Language language,
        bool isSettingsStoredInFlash)
    {
        _integraVersionResponse = new IntegraVersionResponse(
            integraType,
            version,
            language,
            isSettingsStoredInFlash);
    }
    
    public byte[] SendFrame(byte[] request)
    {
        if (request.Length < 7)
        {
            return Array.Empty<byte>();
        }

        var header = request[0..2];
        var requestByte = request[2];
        var crcBytes = request[^4..^2];
        var footer = request[^2..^0];
        
        if (request.Length > 7)
        {
            var content = request[3..^4];
        }

        if (!header.SequenceEqual(new byte[] { 0xFE, 0xFE }))
        {
            return Array.Empty<byte>();
        }
        
        if (!footer.SequenceEqual(new byte[] { 0xFE, 0x0D }))
        {
            return Array.Empty<byte>();
        }

        return ExecuteRequest(requestByte);
    }

    private byte[] ExecuteRequest(byte requestByte)
    {
        byte[] requestBody;
        
        switch (requestByte)
        {
            case 0x00:
                requestBody = GetZonesViolation();
                break;
            case 0x01:
                requestBody = GetZonesTamper();
                break;
            case 0x02:
                requestBody = GetZonesAlarm();
                break;
            case 0x03:
                requestBody = GetZonesTamperAlarm();
                break;
            case 0x04:
                requestBody = GetZonesAlarmMemory();
                break;
            case 0x05:
                requestBody = GetZonesTamperAlarmMemory();
                break;
            case 0x06:
                requestBody = GetZonesBypass();
                break;
            case 0x07:
                requestBody = GetZonesNoViolationTrouble();
                break;
            case 0x08:
                requestBody = GetZonesLongViolationTrouble();
                break;
            case 0x09:
                requestBody = GetArmedPartitionsSuppressed();
                break;
            case 0x0A:
                requestBody = GetArmedPartitionsReally();
                break;
            case 0x0B:
                requestBody = GetPartitionsArmedInMode2();
                break;
            case 0x0C:
                requestBody = GetPartitionsArmedInMode3();
                break;
            case 0x0D:
                requestBody = GetPartitionsWith1StCodeEntered();
                break;
            case 0x0E:
                requestBody = GetPartitionsEntryTime();
                break;
            case 0x0F:
                requestBody = GetPartitionsExitTimeGreaterThan10Sec();
                break;
            case 0x10:
                requestBody = GetPartitionsExitTimeLessThan10Sec();
                break;
            case 0x11:
                requestBody = GetPartitionsTemporaryBlocked();
                break;
            case 0x12:
                requestBody = GetPartitionsBlockedForGuardRound();
                break;
            case 0x13:
                requestBody = GetPartitionsAlarm();
                break;
            case 0x14:
                requestBody = GetPartitionsFireAlarm();
                break;
            case 0x15:
                requestBody = GetPartitionsAlarmMemory();
                break;
            case 0x16:
                requestBody = GetPartitionsFireAlarmMemory();
                break;
            case 0x17:
                requestBody = GetOutputsState();
                break;
            case 0x18:
                requestBody = GetDoorsOpened();
                break;
            case 0x19:
                requestBody = GetDoorsOpenedLong();
                break;
            case 0x1A:
                requestBody = GetRtcAndBasicStatusBits();
                break;
            case 0x25:
                requestBody = GetPartitionsWithViolatedZones();
                break;
            case 0x26:
                requestBody = GetZonesIsolate();
                break;
            case 0x27:
                requestBody = GetPartitionsWithVerifiedAlarm();
                break;
            case 0x28:
                requestBody = GetZonesMasked();
                break;
            case 0x29:
                requestBody = GetZonesMaskedMemory();
                break;
            case 0x2A:
                requestBody = GetPartitionsArmedInMode1();
                break;
            case 0x2B:
                requestBody = GetPartitionsWithWarningAlarms();
                break;
            case 0x7C:
                requestBody = GetIntRsOrEthm1ModuleVersion();
                break;
            case 0x7E:
                requestBody = GetIntegraVersion();
                break;
                  
            default:
                return Array.Empty<byte>();
        }

        var frame = FrameWrapper.WrapWithFrame(requestByte, requestBody);
        return frame;
    }
    
    private byte[] GetZonesViolation()
        => ConvertIntsToBytes(_zonesViolation);

    private byte[] GetZonesTamper()
        =>  ConvertIntsToBytes(_zonesTamper);
    
    private byte[] GetZonesAlarm() 
        => ConvertIntsToBytes(_zonesAlarm);
    
    private byte[] GetZonesTamperAlarm()
        => ConvertIntsToBytes(_zonesTamperAlarm);
    
    private byte[] GetZonesAlarmMemory()
        => ConvertIntsToBytes(_zonesAlarmMemory);
    
    private byte[] GetZonesTamperAlarmMemory()
        => ConvertIntsToBytes(_zonesTamperAlarmMemory);
    
    private byte[] GetZonesBypass()
        => ConvertIntsToBytes(_zonesBypass);
    
    private byte[] GetZonesNoViolationTrouble()
        => ConvertIntsToBytes(_zonesNoViolationTrouble);
    
    private byte[] GetZonesLongViolationTrouble()
        => ConvertIntsToBytes(_zonesLongViolationTrouble);
    
    private byte[] GetArmedPartitionsSuppressed()
        => ConvertIntsToBytes(_armedPartitionsSuppressed);
    
    private byte[] GetArmedPartitionsReally()
        => ConvertIntsToBytes(_armedPartitionsReally);
    
    private byte[] GetPartitionsArmedInMode2()
        => ConvertIntsToBytes(_partitionsArmedInMode2);
    
    private byte[] GetPartitionsArmedInMode3()
        => ConvertIntsToBytes(_partitionsArmedInMode3);
    
    private byte[] GetPartitionsWith1StCodeEntered()
        => ConvertIntsToBytes(_partitionsWith1StCodeEntered);
        
    private byte[] GetPartitionsEntryTime()
        => ConvertIntsToBytes(_partitionsEntryTime);
    
    private byte[] GetPartitionsExitTimeGreaterThan10Sec()
        => ConvertIntsToBytes(_partitionsExitTimeGreaterThan10Sec);
    
    private byte[] GetPartitionsExitTimeLessThan10Sec()
        => ConvertIntsToBytes(_partitionsExitTimeLessThan10Sec);
    
    private byte[] GetPartitionsTemporaryBlocked()
        => ConvertIntsToBytes(_partitionsTemporaryBlocked);
    
    private byte[] GetPartitionsBlockedForGuardRound()
        => ConvertIntsToBytes(_partitionsBlockedForGuardRound);
    
    private byte[] GetPartitionsAlarm()
        => ConvertIntsToBytes(_partitionsAlarm);
    
    private byte[] GetPartitionsFireAlarm()
        => ConvertIntsToBytes(_partitionsFireAlarm);
    
    private byte[] GetPartitionsAlarmMemory()
        => ConvertIntsToBytes(_partitionsAlarmMemory);
    
    private byte[] GetPartitionsFireAlarmMemory()
        => ConvertIntsToBytes(_partitionsFireAlarmMemory);
    
    private byte[] GetOutputsState()
        => ConvertIntsToBytes(_outputsState);
    
    private byte[] GetDoorsOpened()
        => ConvertIntsToBytes(_doorsOpened);
    
    private byte[] GetDoorsOpenedLong()
        => ConvertIntsToBytes(_doorsOpenedLong);
    
    private byte[] GetPartitionsWithViolatedZones()
        => ConvertIntsToBytes(_partitionsWithViolatedZones);
    
    private byte[] GetZonesIsolate()
        => ConvertIntsToBytes(_zonesIsolate);
    
    private byte[] GetPartitionsWithVerifiedAlarm()
        => ConvertIntsToBytes(_partitionsWithVerifiedAlarm);
    
    private byte[] GetZonesMasked()
        => ConvertIntsToBytes(_zonesMasked);
    
    private byte[] GetZonesMaskedMemory()
        => ConvertIntsToBytes(_zonesMaskedMemory);
    
    private byte[] GetPartitionsArmedInMode1()
        => ConvertIntsToBytes(_partitionsArmedInMode1);
    
    private byte[] GetPartitionsWithWarningAlarms()
        => ConvertIntsToBytes(_partitionsWithWarningAlarms);

    private byte[] GetRtcAndBasicStatusBits()
        => TestRtcAndBasicStatusResponseBuilder.GetResponse(_rtcAndBasicStatusResponse!);
    
    private byte[] GetIntRsOrEthm1ModuleVersion()
        => TestIntRsOrEthm1ModuleVersionResponseBuilder.GetResponse(_intRsOrEthm1ModuleVersionResponse!);
    
    private byte[] GetIntegraVersion()
        => TestIntegraVersionResponseBuilder.GetResponse(_integraVersionResponse!);
    
    private static byte[] ConvertIntsToBytes(IEnumerable<byte> numbers)
    {
        var byteList = new List<byte>();

        foreach (var number in numbers)
        {
            var bytePosition = (number - 1) / 8;
            var bitPosition = (number - 1) % 8;

            if (byteList.Count <= bytePosition)
            {
                byteList.AddRange(new byte[bytePosition + 1 - byteList.Count]);
            }
            
            byteList[bytePosition] |= (byte)(1 << bitPosition);
        }

        return byteList.ToArray();
    }
}