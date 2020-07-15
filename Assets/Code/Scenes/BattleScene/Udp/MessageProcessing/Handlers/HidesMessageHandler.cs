using Code.BattleScene.ECS.Systems;
using Code.Scenes.BattleScene.ECS.Systems.NetworkSyncSystems;
using NetworkLibrary.NetworkLibrary.Udp;
using NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class HidesMessageHandler : IMessageHandler
    {
        public void Handle(MessageWrapper messageWrapper)
        {
            var mes = ZeroFormatterSerializer.Deserialize<HidesMessage>(messageWrapper.SerializedMessage);
            UpdateHidingSystem.SetNewHides(messageWrapper.MessageId, mes.HiddenIds);
        }
    }
}