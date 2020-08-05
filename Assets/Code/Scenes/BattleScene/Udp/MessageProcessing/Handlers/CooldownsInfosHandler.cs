using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class CooldownsInfosHandler : MessageHandler<CooldownsInfosMessage>
    {
        protected override void Handle(in CooldownsInfosMessage message, uint messageId, bool needResponse)
        {
            CooldownsUpdaterSystem.SetWeaponsInfos(message.WeaponsInfos);
            AbilityUpdaterSystem.SetMaxCooldown(message.AbilityMaxCooldown);
        }
    }
}