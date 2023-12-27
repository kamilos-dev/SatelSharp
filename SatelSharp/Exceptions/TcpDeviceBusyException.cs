namespace SatelSharp.Exceptions;

public class TcpDeviceBusyException() : Exception(BusyMessage)
{
    private const string BusyMessage = """
                                       Device is busy.
                                       This usually means that another integration is running on the port in question.
                                       Make sure all connections to the device on the port are complete and try again.
                                       """;
}
