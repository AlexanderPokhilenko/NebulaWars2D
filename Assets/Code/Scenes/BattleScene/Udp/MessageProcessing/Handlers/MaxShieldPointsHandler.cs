using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer;
using NetworkLibrary.NetworkLibrary.Udp;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class MaxShieldPointsHandler : IMessageHandler
    {
        public void Handle(MessageWrapper message)
        {
            MaxShieldPointsMessage maxShieldPoints =
                ZeroFormatterSerializer.Deserialize<MaxShieldPointsMessage>(message.SerializedMessage);

            HealthAndShieldPointsUpdaterSystem.SetMaxShieldPoints(maxShieldPoints.Value);
        }
    }
}