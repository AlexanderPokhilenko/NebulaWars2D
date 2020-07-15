using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer;
using NetworkLibrary.NetworkLibrary.Udp;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class ShieldPointsHandler : IMessageHandler
    {
        public void Handle(MessageWrapper message)
        {
            ShieldPointsMessage shieldMessage =
                ZeroFormatterSerializer.Deserialize<ShieldPointsMessage>(message.SerializedMessage);

            HealthAndShieldPointsUpdaterSystem.SetShieldPoints(shieldMessage.Value);
        }
    }
}