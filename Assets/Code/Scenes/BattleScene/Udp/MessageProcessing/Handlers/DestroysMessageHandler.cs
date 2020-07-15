using Code.BattleScene.ECS.Systems;
using Code.Scenes.BattleScene.Udp.MessageProcessing.Synchronizers;
using NetworkLibrary.NetworkLibrary.Udp;
using NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class DestroysMessageHandler : IMessageHandler
    {
        private readonly ParentsNetworkSynchronizer _parentsSynchronizer = ParentsNetworkSynchronizer.Instance;

        public void Handle(MessageWrapper messageWrapper)
        {
            var mes = ZeroFormatterSerializer.Deserialize<DestroysMessage>(messageWrapper.SerializedMessage);
            UpdateDestroysSystem.SetNewDestroys(mes.DestroyedIds);

            _parentsSynchronizer.Remove(mes.DestroyedIds);
        }
    }
}