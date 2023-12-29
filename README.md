# SatelSharp

[![Build](https://img.shields.io/github/actions/workflow/status/kamilos-dev/satel-sharp/main.yml?branch=master)](https://github.com/kamilos-dev/satel-sharp/actions)
[![codecov](https://codecov.io/gh/kamilos-dev/SatelSharp/graph/badge.svg?token=7XFTNBRRJL)](https://codecov.io/gh/kamilos-dev/SatelSharp)
[![Version](https://img.shields.io/nuget/v/SatelSharp.svg)](https://nuget.org/packages/SatelSharp)
[![Downloads](https://img.shields.io/nuget/dt/SatelSharp.svg)](https://nuget.org/packages/SatelSharp)

SatelSharp is a library for conveniently getting information from Satel control panels equipped with ETHM-1 Plus or INT-RS Plus modules. It uses an integration protocol to do so.

<p align="center">
    <img src="favicon.png" alt="Icon" />
</p>

## Requirements

- ETHM-1 Plus or INT-RS Plus modules
- Integration enabled in the control panel

## Features

The library currently supports such requests as:
- 0x00 - Zones Violation
- 0x01 - Zones Tamper
- 0x02 - Zones Alarm
- 0x03 - Zones Tamper Alarm
- 0x04 - Zones Alarm Memory
- 0x05 - Zones Tamper Alarm Memory
- 0x06 - Zones Bypass
- 0x07 - Zones 'No Violation' Trouble
- 0x08 - Zones 'Long Violation' Trouble
- 0x09 - Armed Partitions (Suppressed)
- 0x0A - Armed Partitions (Really)
- 0x0B - Partitions Armed in Mode 2
- 0x0C - Partitions Armed in Mode 3
- 0x0D - Partitions with 1st Code Entered
- 0x0E - Partitions Entry Time
- 0x0F - Partitions Exit Time >10s
- 0x10 - Partitions Exit Time <10s
- 0x11 - Partitions Temporary Blocked
- 0x12 - Partitions Blocked for Guard Round
- 0x13 - Partitions Alarm
- 0x14 - Partitions Fire Alarm
- 0x15 - Partitions Alarm Memory
- 0x16 - Partitions Fire Alarm Memory
- 0x17 - Outputs State
- 0x18 - Doors Opened
- 0x19 - Doors Opened Long
- 0x1A - RTC and Basic Status Bits
- 0x25 - Partitions with Violated Zones
- 0x26 - Zones Isolate
- 0x27 - Partitions with Verified Alarms
- 0x28 - Zones Masked
- 0x29 - Zones Masked Memory
- 0x2A - Partitions Armed in Mode 1
- 0x2B - Partitions with Warning Alarms
- 0x7C - INT-RS/ETHM-1 module version
- 0x7E - INTEGRA version

Work is underway to add more functionality

## Usuage

1. Install NuGet package 📦
```
dotnet add package SatelSharp
```

2. Create a `SatelClient` instance with your own device data:
```
 var client = new SatelClient(new TcpSatelDevice("192.168.1.1", 7094));
```

3. Get data. For example to gets a violated zones and ETHM-1 version:
```
var zones = client.GetZonesViolationData();
var ethmVersion = client.GetIntRsOrEthm1ModuleVersionData();
```

If the library currently does not support the request you are looking for you can use the `SendRequest` method to make any request.

The method returns the body of the response, without the header, crc and footer from the response frame.

```
var data = client.SendRequest(0x00);
```

I encourage you to set up an issue and describe the function you lackke. It will certainly encourage me to develop the program more nimbly.


