using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;
using NetworkLibrary.NetworkLibrary.Udp;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class CooldownsInfosHandler : IMessageHandler
    {
        public void Handle(MessageWrapper message)
        {
            var msg = ZeroFormatterSerializer.Deserialize<CooldownsInfosMessage>(message.SerializedMessage);

            CooldownsUpdaterSystem.SetWeaponsInfos(msg.WeaponsInfos);
            AbilityUpdaterSystem.SetMaxCooldown(msg.AbilityMaxCooldown);
        }
    }
}