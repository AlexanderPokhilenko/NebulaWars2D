using NetworkLibrary.NetworkLibrary.Udp;

namespace Code.Common
{
    public class MessageRecord
    {
        public MessageType MessageType { get; set; }
        public int Length { get; set; }

        public override string ToString()
        {
            return $"{MessageType} {Length}";
        }
    }
}