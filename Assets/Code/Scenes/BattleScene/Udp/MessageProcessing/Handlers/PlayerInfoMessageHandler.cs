using Code.Common.Storages;
using Code.Scenes.BattleScene.ECS.Systems.NetworkSyncSystems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class PlayerInfoMessageHandler : MessageHandler<PlayerInfoMessage>
    {
        protected override void Handle(in PlayerInfoMessage message, uint messageId, bool needResponse)
        {
            PlayerIdStorage.PlayerEntityId = message.EntityIds[PlayerIdStorage.AccountId];
            UpdatePlayersSystem.SetNewPlayers(message.EntityIds);
        }
    }
}