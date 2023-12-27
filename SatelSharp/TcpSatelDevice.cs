using System.Net.Sockets;
using SatelSharp.Exceptions;

namespace SatelSharp;

public class TcpSatelDevice : ISatelDevice
{
    private readonly string _ipAddress;
    private readonly int _port;
    private readonly int _timeoutInSeconds;

    private byte[] _busyResponse = [0x10, 0x42, 0x75, 0x73, 0x79];

    public TcpSatelDevice(
        string ipAddress,
        int port = 7094,
        int timeoutInSeconds = 60)
    {
        _ipAddress = ipAddress;
        _port = port;
        _timeoutInSeconds = timeoutInSeconds;
    }

    public byte[] SendFrame(byte[] request)
    {
        //todo: add timeout
        using var client = new TcpClient();

        if (!client.ConnectAsync(_ipAddress, _port).Wait(TimeSpan.FromSeconds(_timeoutInSeconds)))
        {
            throw new TimeoutException("Connection timeout");
        }

        using var stream = client.GetStream();
        stream.Write(request, 0, request.Length);

        var buffer = new byte[64];
        var read = stream.Read(buffer, 0, buffer.Length);

        if (buffer.Length >= _busyResponse.Length)
        {
            if (buffer[0.._busyResponse.Length].SequenceEqual(_busyResponse))
            {
                throw new TcpDeviceBusyException();
            }
        }

        return buffer;
    }
}
