using NetworkLibrary.NetworkLibrary.Udp;
using System.Collections.Generic;
using ZeroFormatter;

namespace Libraries.NetworkLibrary.Udp.ServerToPlayer
{
    [ZeroFormattable]
    public struct HealthPointsMessage:ITypedMessage
    {
        [Index(0)] public readonly Dictionary<ushort, ushort> Value;
        
        public HealthPointsMessage(Dictionary<ushort, ushort> value)
        {
            Value = value;
        }

        public MessageType GetMessageType()
        {
            return MessageType.HealthPoints;
        }
    }
}