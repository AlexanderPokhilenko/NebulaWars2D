using Code.Common;
using ZeroFormatter;

// ReSharper disable once CheckNamespace
namespace NetworkLibrary.NetworkLibrary.Udp
{
    public static class MessageFactory
    {
        public static MessageWrapper GetMessage<T>(T mes, bool rudpEnabled,  out uint messageId) 
            where T : ITypedMessage
        {
            var serializedMessage = ZeroFormatterSerializer.Serialize(mes);
            var messageType = mes.GetMessageType();
            messageId = MessageIdFactory.GetMessageId();
            var message = new MessageWrapper(messageType, serializedMessage, messageId, rudpEnabled);
            return message;
        }

        public static byte[] GetSerializedMessage<T>(T message, bool rudpEnabled, out uint messageId)
            where T : ITypedMessage
        {
            return ZeroFormatterSerializer.Serialize(GetMessage(message, rudpEnabled, out messageId));
        }

        public static byte[] GetSerializedMessage(MessageWrapper messageWrapper)
        {
            return ZeroFormatterSerializer.Serialize(messageWrapper);
        }
    }
}