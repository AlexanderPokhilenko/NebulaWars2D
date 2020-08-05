using Code.Scenes.BattleScene.Udp.Experimental;
using Libraries.NetworkLibrary.Udp.Common;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class RudpConfirmationReceiver:MessageHandler<DeliveryConfirmationMessage>
    {
        protected override void Handle(in DeliveryConfirmationMessage message, uint messageId, bool needResponse)
        {
            RudpStorage.Instance.RemoveMessage(message.MessageNumberThatConfirms);
        }
    }
}