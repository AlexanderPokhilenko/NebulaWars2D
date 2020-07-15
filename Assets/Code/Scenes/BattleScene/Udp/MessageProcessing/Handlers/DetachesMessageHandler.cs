using Code.Scenes.BattleScene.Udp.MessageProcessing.Synchronizers;
using NetworkLibrary.NetworkLibrary.Udp;
using NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class DetachesMessageHandler : IMessageHandler
    {
        private readonly ParentsNetworkSynchronizer _synchronizer = ParentsNetworkSynchronizer.Instance;
        public void Handle(MessageWrapper messageWrapper)
        {
            var mes = ZeroFormatterSerializer.Deserialize<DetachesMessage>(messageWrapper.SerializedMessage);
            _synchronizer.HandleSet(messageWrapper.MessageId, mes.DetachedIds);
        }
    }
}