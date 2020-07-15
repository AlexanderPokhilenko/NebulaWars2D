using Code.BattleScene.ECS.Systems;
using Code.Common;
using Code.Scenes.BattleScene.ECS.Systems.NetworkSyncSystems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;
using NetworkLibrary.NetworkLibrary.Udp;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class PlayerInfoMessageHandler : IMessageHandler
    {
        public void Handle(MessageWrapper messageWrapper)
        {
            var mes = ZeroFormatterSerializer.Deserialize<PlayerInfoMessage>(messageWrapper.SerializedMessage);
            PlayerIdStorage.PlayerEntityId = mes.EntityIds[PlayerIdStorage.AccountId];
            UpdatePlayersSystem.SetNewPlayers(mes.EntityIds);
        }
    }
}