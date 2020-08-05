using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class HealthPointsHandler:MessageHandler<HealthPointsMessage>
    {
        protected override void Handle(in HealthPointsMessage message, uint messageId, bool needResponse)
        {
            HealthAndShieldPointsUpdaterSystem.SetHealthPoints(message.Value);
        }
    }
}