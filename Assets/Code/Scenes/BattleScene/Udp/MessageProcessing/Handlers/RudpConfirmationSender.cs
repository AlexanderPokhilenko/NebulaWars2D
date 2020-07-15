using Code.Scenes.BattleScene.Udp.Experimental;
using NetworkLibrary.NetworkLibrary.Udp;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class RudpConfirmationSender:IMessageHandler
    {
        private readonly UdpSendUtils udpSendUtils;

        public RudpConfirmationSender(UdpSendUtils udpSendUtils)
        {
            this.udpSendUtils = udpSendUtils;
        }
        
        public void Handle(MessageWrapper messageWrapper)
        {
            udpSendUtils.SendDeliveryConfirmationMessage(messageWrapper.MessageId);
        }
    }
}