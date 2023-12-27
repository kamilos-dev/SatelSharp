using FluentAssertions;
using SatelSharp.Utils;

namespace SatelSharp.UnitTests.Utils;

public class CrcCalculatorTests
{
    [Test]
    public void GivenBytes_WhenCalculateCrc_ThenValidValueIsReturned()
    {
        // Given
        var bytes = new byte[] { 0xE0, 0x12, 0x34, 0xFF, 0xFF };
        
        // When
        var crc = CrcCalculator.Calculate(bytes);
        
        // Then
        crc.Should().BeEquivalentTo(new byte[] { 0x8A, 0x9B });
    }
}