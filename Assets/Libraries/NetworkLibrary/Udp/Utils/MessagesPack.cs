using ZeroFormatter;

namespace NetworkLibrary.NetworkLibrary.Udp
{
    [ZeroFormattable]
    public class MessagesPack
    {
        [Index(0)] public virtual byte[][] Messages { get; set; }
        [Index(1)] public virtual int Id { get; set; }
        [IgnoreFormat] public const int IndexLength = 16+4;
    }
}