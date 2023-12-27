using FluentAssertions;
using SatelSharp.Extensions;
using SatelSharp.Utils;

namespace SatelSharp.UnitTests.Extenstions;

public class ByteExtensionsTests
{
    [Test]
    [TestCase(1, 0)]
    [TestCase(2, 1)]
    [TestCase(4, 2)]
    [TestCase(8, 3)]
    [TestCase(16, 4)]
    [TestCase(32, 5)]
    [TestCase(64, 6)]
    [TestCase(128, 7)]
    public void GivenBytesWithOneHighBit_WhenGetBitValueOnPosition_ThenOnlyOneBitOnGivenPositionsIsOne_RestBitsAreZero(byte byteValue, short positionWithHighBit)
    {
        // Given
        var bitPositions = new short[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        
        // When
        var result = byteValue.GetBitOnIndex(positionWithHighBit);

        var otherBits = bitPositions
            .ToList()
            .Where(position => position != positionWithHighBit)
            .Select(position => byteValue.GetBitOnIndex(position))
            .ToList()
            .Distinct();
        
        // Then
        result.Should().Be(Bit.One);
        otherBits.Should().BeEquivalentTo(new List<Bit> { Bit.Zero }, options => options.ComparingRecordsByValue());
    }
    
    [Test]
    public void GivenByteWithAllHighBits_WhenGetBitValueOnPosition_ThenAllBitsAreOne()
    {
        // Given
        byte byteValue = 255;
        var bitPositions = new short[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        
        // When
        var bits = bitPositions
            .ToList()
            .Select(position => byteValue.GetBitOnIndex(position))
            .ToList()
            .Distinct();
        
        // Then
        bits.Should().BeEquivalentTo(new List<Bit> { Bit.One }, options => options.ComparingRecordsByValue());
    }
    
    [Test]
    public void GivenByteWithAllLowBits__WhenGetBitValueOnPosition_ThenAllBitsAreZero()
    {
        // Given
        byte byteValue = 0;
        var bitPositions = new short[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        
        // When
        var bits = bitPositions
            .ToList()
            .Select(position => byteValue.GetBitOnIndex(position))
            .ToList()
            .Distinct();
        
        // Then
        bits.Should().BeEquivalentTo(new List<Bit> { Bit.Zero }, options => options.ComparingRecordsByValue());
    }
}