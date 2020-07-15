using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;
using NetworkLibrary.NetworkLibrary.Udp;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class CooldownsHandler : IMessageHandler
    {
        public void Handle(MessageWrapper message)
        {
            var msg = ZeroFormatterSerializer.Deserialize<CooldownsMessage>(message.SerializedMessage);

            CooldownsUpdaterSystem.SetCooldowns(msg.WeaponsCooldowns);
            AbilityUpdaterSystem.SetCurrentCooldown(msg.AbilityCooldown);
        }
    }
}