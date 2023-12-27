using FluentAssertions;
using SatelSharp.Responses;
using SatelSharp.UnitTests.FakeDevice;

namespace SatelSharp.UnitTests;

public class SatelClientTests
{
    [Test]
    public void GivenDeviceWithZonesViolation_WhenSendRequest_WithOneByte_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);
        
        device.SetZonesViolation(3, 14, 128);
        
        // When
        var result = client.SendRequest(0x00);

        // Then
        result.Should().BeEquivalentTo([4, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 128]);
    }
    
    [Test]
    public void GivenDeviceWithZonesViolation_WhenSendRequest_WithTwoBytes_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);
        
        device.SetZonesViolation(3, 14, 128);
        
        // When
        var result = client.SendRequest([0x00, 0x00]);

        // Then
        result.Should().BeEquivalentTo([4, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 128]);
    }
    
    [Test]
    public void GivenDeviceWithZonesViolation_WhenGetZonesViolationData_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);
        
        device.SetZonesViolation(3, 14, 128);
        
        // When
        var result = client.GetZonesViolationData();

        // Then
        result.Should().BeEquivalentTo(new[] { 3, 14, 128 });
    }
    
    [Test]
    public void GivenDeviceWithZonesTamper_WhenGetZonesTamperData_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);
        
        device.SetZonesTamper(1, 2, 167);
        
        // When
        var result = client.GetZonesTamperData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 2, 167 });
    }
    
    [Test]
    public void GivenDeviceWithZonesAlarm_WhenGetZonesAlarmData_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);
        
        device.SetZonesAlarm(1, 6, 255);
        
        // When
        var result = client.GetZonesAlarmData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 6, 255 });
    }
    
    [Test]
    public void GivenDeviceWithZonesTamperAlarm_WhenGetZonesTamperAlarmData_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);
        
        device.SetZonesTamperAlarm(1, 6, 255);
        
        // When
        var result = client.GetZonesTamperAlarmData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 6, 255 });
    }
    
    [Test]
    public void GivenDeviceWithZonesAlarmMemory_WhenGetZonesAlarmMemoryData_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);
        
        device.SetZonesAlarmMemory(1, 6, 255);
        
        // When
        var result = client.GetZonesAlarmMemoryData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 6, 255 });
    }
    
    [Test]
    public void GivenDeviceWithZonesTamperAlarmMemory_WhenGetZonesTamperAlarmMemoryData_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetZonesTamperAlarmMemory(1, 6, 255);

        // When
        var result = client.GetZonesTamperAlarmMemoryData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 6, 255 });
    }

    [Test]
    public void GivenDeviceWithZonesBypass_WhenGetZonesBypassData_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetZonesBypass(1, 6, 255);

        // When
        var result = client.GetZonesBypassData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 6, 255 });
    }

    [Test]
    public void GivenDeviceWithZonesNoViolationTrouble_WhenGetZonesNoViolationTroubleData_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetZonesNoViolationTrouble(2, 7, 128);

        // When
        var result = client.GetZonesNoViolationTroubleData();

        // Then
        result.Should().BeEquivalentTo(new[] { 2, 7, 128 });
    }

    [Test]
    public void GivenDeviceWithZonesLongViolationTrouble_WhenGetZonesLongViolationTroubleData_ThenCorrectZonesAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetZonesLongViolationTrouble(3, 8, 64);

        // When
        var result = client.GetZonesLongViolationTroubleData();

        // Then
        result.Should().BeEquivalentTo(new[] { 3, 8, 64 });
    }

    [Test]
    public void GivenDeviceWithArmedPartitionsSuppressed_WhenGetArmedPartitionsSuppressedData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetArmedPartitionsSuppressed(4, 9, 32);

        // When
        var result = client.GetArmedPartitionsSuppressedData();

        // Then
        result.Should().BeEquivalentTo(new[] { 4, 9, 32 });
    }

    [Test]
    public void GivenDeviceWithArmedPartitionsReally_WhenGetArmedPartitionsReallyData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetArmedPartitionsReally(5, 10, 16);

        // When
        var result = client.GetArmedPartitionsReallyData();

        // Then
        result.Should().BeEquivalentTo(new[] { 5, 10, 16 });
    }

    [Test]
    public void GivenDeviceWithPartitionsArmedInMode2_WhenGetPartitionsArmedInMode2Data_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsArmedInMode2(6, 11, 8);

        // When
        var result = client.GetPartitionsArmedInMode2Data();

        // Then
        result.Should().BeEquivalentTo(new[] { 6, 11, 8 });
    }

    [Test]
    public void GivenDeviceWithPartitionsArmedInMode3_WhenGetPartitionsArmedInMode3Data_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsArmedInMode3(7, 12, 4);

        // When
        var result = client.GetPartitionsArmedInMode3Data();

        // Then
        result.Should().BeEquivalentTo(new[] { 7, 12, 4 });
    }

    [Test]
    public void GivenDeviceWithPartitionsWith1StCodeEntered_WhenGetPartitionsWith1StCodeEnteredData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsWith1StCodeEntered(8, 13, 2);

        // When
        var result = client.GetPartitionsWith1StCodeEnteredData();

        // Then
        result.Should().BeEquivalentTo(new[] { 8, 13, 2 });
    }

    [Test]
    public void GivenDeviceWithPartitionsEntryTime_WhenGetPartitionsEntryTimeData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsEntryTime(9, 14, 1);

        // When
        var result = client.GetPartitionsEntryTimeData();

        // Then
        result.Should().BeEquivalentTo(new[] { 9, 14, 1 });
    }

    [Test]
    public void GivenDeviceWithPartitionsExitTimeGreaterThan10Sec_WhenGetPartitionsExitTimeGreaterThan10SecData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsExitTimeGreaterThan10Sec(10, 15, 255);

        // When
        var result = client.GetPartitionsExitTimeGreaterThan10SecData();

        // Then
        result.Should().BeEquivalentTo(new[] { 10, 15, 255 });
    }

    [Test]
    public void GivenDeviceWithPartitionsExitTimeLessThan10Sec_WhenGetPartitionsExitTimeLessThan10SecData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);
        
        device.SetPartitionsExitTimeLessThan10Sec(11, 16, 255);

        // When
        var result = client.GetPartitionsExitTimeLessThan10SecData();

        // Then
        result.Should().BeEquivalentTo(new[] { 11, 16, 255 });
    }

    [Test]
    public void GivenDeviceWithPartitionsTemporaryBlocked_WhenGetPartitionsTemporaryBlockedData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsTemporaryBlocked(12, 17, 128);

        // When
        var result = client.GetPartitionsTemporaryBlockedData();

        // Then
        result.Should().BeEquivalentTo(new[] { 12, 17, 128 });
    }

    [Test]
    public void GivenDeviceWithPartitionsBlockedForGuardRound_WhenGetPartitionsBlockedForGuardRoundData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsBlockedForGuardRound(13, 18, 64);

        // When
        var result = client.GetPartitionsBlockedForGuardRoundData();

        // Then
        result.Should().BeEquivalentTo(new[] { 13, 18, 64 });
    }

    [Test]
    public void GivenDeviceWithPartitionsAlarm_WhenGetPartitionsAlarmData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsAlarm(14, 19, 32);

        // When
        var result = client.GetPartitionsAlarmData();

        // Then
        result.Should().BeEquivalentTo(new[] { 14, 19, 32 });
    }

    [Test]
    public void GivenDeviceWithPartitionsFireAlarm_WhenGetPartitionsFireAlarmData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsFireAlarm(15, 20, 16);

        // When
        var result = client.GetPartitionsFireAlarmData();

        // Then
        result.Should().BeEquivalentTo(new[] { 15, 20, 16 });
    }

    [Test]
    public void GivenDeviceWithPartitionsAlarmMemory_WhenGetPartitionsAlarmMemoryData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsAlarmMemory(16, 21, 8);

        // When
        var result = client.GetPartitionsAlarmMemoryData();

        // Then
        result.Should().BeEquivalentTo(new[] { 16, 21, 8 });
    }

    [Test]
    public void GivenDeviceWithPartitionsFireAlarmMemory_WhenGetPartitionsFireAlarmMemoryData_ThenCorrectPartitionsAreReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsFireAlarmMemory(17, 22, 4);

        // When
        var result = client.GetPartitionsFireAlarmMemoryData();

        // Then
        result.Should().BeEquivalentTo(new[] { 17, 22, 4 });
    }

    [Test]
    public void GivenDeviceWithOutputsState_WhenGetOutputsStateData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetOutputsState(18, 23, 2);

        // When
        var result = client.GetOutputsStateData();

        // Then
        result.Should().BeEquivalentTo(new[] { 18, 23, 2 });
    }

    [Test]
    public void GivenDeviceWithDoorsOpened_WhenGetDoorsOpenedData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetDoorsOpened(19, 24, 1);

        // When
        var result = client.GetDoorsOpenedData();

        // Then
        result.Should().BeEquivalentTo(new[] { 19, 24, 1 });
    }

    [Test]
    public void GivenDeviceWithDoorsOpenedLong_WhenGetDoorsOpenedLongData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetDoorsOpenedLong(20, 25, 255);

        // When
        var result = client.GetDoorsOpenedLongData();

        // Then
        result.Should().BeEquivalentTo(new[] { 20, 25, 255 });
    }
    
    [Test]
    public void GivenDeviceWithPartitionsWithViolatedZones_WhenGetPartitionsWithViolatedZonesData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsWithViolatedZones(1);

        // When
        var result = client.GetPartitionsWithViolatedZonesData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1 });
    }
    
    [Test]
    public void GivenDeviceWithZonesIsolate_WhenGetZonesIsolateData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetZonesIsolate(1, 255);

        // When
        var result = client.GetZonesIsolateData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 255 });
    }
    
    [Test]
    public void GivenDeviceWithPartitionsWithVerifiedAlarm_WhenGetPartitionsWithVerifiedAlarmData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsWithVerifiedAlarm(1, 255);

        // When
        var result = client.GetPartitionsWithVerifiedAlarmData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 255 });
    }
    
    [Test]
    public void GivenDeviceWithZonesMasked_WhenGetZonesMaskedData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetZonesMasked(1, 255);

        // When
        var result = client.GetZonesMaskedData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 255 });
    }
    
    [Test]
    public void GivenDeviceWithZonesMaskedMemory_WhenGetZonesMaskedMemoryData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetZonesMaskedMemory(1, 255);

        // When
        var result = client.GetZonesMaskedMemoryData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 255 });
    }
    
    [Test]
    public void GivenDeviceWithPartitionsArmedInMode1_WhenGetPartitionsArmedInMode1Data_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsArmedInMode1(1, 255);

        // When
        var result = client.GetPartitionsArmedInMode1Data();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 255 });
    }
    
    [Test]
    public void GivenDeviceWithPartitionsWithWarningAlarms_WhenGetPartitionsWithWarningAlarmsData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        device.SetPartitionsWithWarningAlarms(1, 255);

        // When
        var result = client.GetPartitionsWithWarningAlarmsData();

        // Then
        result.Should().BeEquivalentTo(new[] { 1, 255 });
    }
    
    [Test]
    public void GivenDeviceWithRtcAndBasicStatusBits_WhenGetRtcAndBasicStatusBitsData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        var dateTime = new DateTime(2099, 12, 31, 23, 59, 29);
        const DayOfWeek dayOfWeek = DayOfWeek.Saturday;
        const bool isServiceMode = true;
        const bool isTroubleInSystem = true;
        const bool isAcu100InSystem = true;
        const bool isIntRxInSystem = true;
        const bool isTroublesMemorySet = true;
        const bool isGrade2Or3OptionSet = true;
        const RtcIntegraType integraType = RtcIntegraType.Integra256Plus;
        
        device.SetRtcAndBasicStatusBits(
            dateTime,
            dayOfWeek,
            isServiceMode,
            isTroubleInSystem,
            isAcu100InSystem,
            isIntRxInSystem,
            isTroublesMemorySet,
            isGrade2Or3OptionSet,
            integraType);

        // When
        var result = client.GetRtcAndBasicStatusBitsData();

        // Then
        result.Should().BeEquivalentTo(new RtcAndBasicStatusResponse(
            dateTime,
            dayOfWeek,
            isServiceMode,
            isTroubleInSystem,
            isAcu100InSystem,
            isIntRxInSystem,
            isTroublesMemorySet,
            isGrade2Or3OptionSet,
            integraType));
    }
    
    [Test]
    public void GivenDeviceWithIntRsOrEthm1ModuleVersion_WhenGetIntRsOrEthm1ModuleVersionData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        const string version = "12320120527";
        const bool isSupporting32Bits = true;
        const bool isServingTroublePart8 = true;
        const bool isServingArmingWithNoBypass = true;
        
        device.SetGetIntRsOrEthm1ModuleVersion(
            version,
            isSupporting32Bits,
            isServingTroublePart8,
            isServingArmingWithNoBypass);

        // When
        var result = client.GetIntRsOrEthm1ModuleVersionData();

        // Then
        result.Should().BeEquivalentTo(new IntRsOrEthm1ModuleVersionResponse(
            "1.23 2012-05-27",
            isSupporting32Bits,
            isServingTroublePart8,
            isServingArmingWithNoBypass));
    }
    
    [Test]
    public void GivenDeviceWithIntegraVersion_WhenGetIntegraVersionData_ThenCorrectDataIsReturned()
    {
        // Given
        var device = new FakeTcpSatelDevice();
        var client = new SatelClient(device);

        const IntegraVersionIntegraType integraType = IntegraVersionIntegraType.Integra128WrlLeon;
        const string version = "12320120527";
        const Language language = Language.English;
        const bool isSettingsStoredInFlash = true;
        
        device.SetIntegraVersion(
            integraType,
            version,
            language,
            isSettingsStoredInFlash);

        // When
        var result = client.GetIntegraVersionData();

        // Then
        result.Should().BeEquivalentTo(new IntegraVersionResponse(
            integraType,
            "1.23 2012-05-27",
            language,
            isSettingsStoredInFlash));
    }
}