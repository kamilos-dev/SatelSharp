namespace SatelSharp;

public interface ISatelDevice
{
    public byte[] SendFrame(byte[] request);
}
