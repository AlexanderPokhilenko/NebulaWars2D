using Code.Scenes.BattleScene.Udp.MessageProcessing.Synchronizers;
using NetworkLibrary.NetworkLibrary.Udp;
using NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class ParentsMessageHandler : IMessageHandler
    {
        private readonly ParentsNetworkSynchronizer _synchronizer = ParentsNetworkSynchronizer.Instance;
        public void Handle(MessageWrapper messageWrapper)
        {
            var mes = ZeroFormatterSerializer.Deserialize<ParentsMessage>(messageWrapper.SerializedMessage);
            _synchronizer.HandleDictionary(messageWrapper.MessageId, mes.ParentInfo);
        }
    }
}