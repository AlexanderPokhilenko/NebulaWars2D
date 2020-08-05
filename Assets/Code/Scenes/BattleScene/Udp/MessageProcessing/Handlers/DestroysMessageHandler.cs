using Code.Scenes.BattleScene.ECS.Systems.NetworkSyncSystems;
using Code.Scenes.BattleScene.Udp.MessageProcessing.Synchronizers;
using NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class DestroysMessageHandler : MessageHandler<DestroysMessage>
    {
        private readonly ParentsNetworkSynchronizer _parentsSynchronizer = ParentsNetworkSynchronizer.Instance;

        protected override void Handle(in DestroysMessage message, uint messageId, bool needResponse)
        {
            UpdateDestroysSystem.SetNewDestroys(message.DestroyedIds);

            _parentsSynchronizer.Remove(message.DestroyedIds);
        }
    }
}