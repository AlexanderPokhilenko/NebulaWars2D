using Code.Scenes.BattleScene.Udp.Experimental;
using Libraries.NetworkLibrary.Udp.Common;
using NetworkLibrary.NetworkLibrary.Udp;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class RudpConfirmationReceiver:IMessageHandler
    {
        public void Handle(MessageWrapper messageWrapper)
        {
            var mes = ZeroFormatterSerializer.Deserialize<DeliveryConfirmationMessage>(messageWrapper.SerializedMessage);
            RudpStorage.Instance.RemoveMessage(mes.MessageNumberThatConfirms);
        }
    }
}