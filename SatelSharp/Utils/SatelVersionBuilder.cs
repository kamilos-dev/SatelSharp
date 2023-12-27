using System.Text;

namespace SatelSharp.Utils;

public static class SatelVersionBuilder
{
    public static string Build(byte[] bytes)
    {
        var version = Encoding.ASCII.GetString(bytes);

        version = version.Insert(1, ".");
        version = version.Insert(4, " ");
        version = version.Insert(9, "-");
        version = version.Insert(12, "-");
        
        return version;
    }
}