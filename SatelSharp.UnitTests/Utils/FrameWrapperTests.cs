using FluentAssertions;
using SatelSharp.Utils;

namespace SatelSharp.UnitTests.Utils;

public class FrameWrapperTests
{
    [Test]
    public void GivenRequestWithOneByte_WhenWrapWithFrame_ThenValidFrameIsReturned()
    {
        // Given
        const byte requestByte = 0x00;
        
        // When
        var frame = FrameWrapper.WrapWithFrame(requestByte);
        
        // Then
        frame.Should().BeEquivalentTo(new byte[] { 0xFE, 0xFE, 0x00, 0xD7, 0xE2, 0xFE, 0x0D });
    }
    
    [Test]
    public void GivenRequestWithTwoByte_WhenWrapWithFrame_ThenValidFrameIsReturned()
    {
        // Given
        byte[] requestBytes = [0x2A, 0x00];
        
        // When
        var frame = FrameWrapper.WrapWithFrame(requestBytes);
        
        // Then
        frame.Should().BeEquivalentTo(new byte[] { 0xFE, 0xFE, 0x2A, 0x00, 0x50, 0x35, 0xFE, 0x0D });
    }
    
    [Test]
    public void GivenRequestWithMultipleBytes_WhenWrapWithFrame_ThenValidFrameIsReturned()
    {
        // Given
        var bytes = new byte[] { 0xE0, 0x12, 0x34, 0xFF, 0xFF };
        
        // When
        var frame = FrameWrapper.WrapWithFrame(bytes);
        
        // Then
        frame.Should().BeEquivalentTo(new byte[] { 0xFE, 0xFE, 0xE0, 0x12, 0x34, 0xFF, 0xFF, 0x8A, 0x9B, 0xFE, 0x0D });
    }
    
    [Test]
    public void GivenRequestWithMultipleBytes_ThatContainSpecialByte_WhenWrapWithFrame_ThenValidFrameIsReturned()
    {
        // Given
        var bytes = new byte[] { 0x00, 0xFE };
        
        // When
        var frame = FrameWrapper.WrapWithFrame(bytes);
        
        // Then
        frame.Should().BeEquivalentTo(new byte[] { 0xFE, 0xFE, 0x00, 0xFE, 0xF0, 0x51, 0x88, 0xFE, 0x0D });
    }
}