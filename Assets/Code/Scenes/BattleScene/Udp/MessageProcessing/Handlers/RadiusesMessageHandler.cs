using Code.BattleScene.ECS.Systems;
using NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class RadiusesMessageHandler : MessageHandler<RadiusesMessage>
    {
        protected override void Handle(in RadiusesMessage message, uint messageId, bool needResponse)
        {
            UpdateRadiusSystem.SetNewRadiuses(message.FloatRadiusInfo);
        }
    }
}