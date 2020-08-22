using NetworkLibrary.NetworkLibrary.Udp;
using System.Collections.Generic;
using ZeroFormatter;

namespace Libraries.NetworkLibrary.Udp.ServerToPlayer
{
    [ZeroFormattable]
    public struct MaxHealthPointsMessage:ITypedMessage
    {
        [Index(0)] public readonly Dictionary<ushort, ushort> Value;
        
        public MaxHealthPointsMessage(Dictionary<ushort, ushort> value)
        {
            Value = value;
        }

        public MessageType GetMessageType()
        {
            return MessageType.MaxHealthPoints;
        }
    }
}