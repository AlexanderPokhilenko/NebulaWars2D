using Code.BattleScene.ECS.Systems;
using NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class PositionsMessageHandler:MessageHandler<PositionsMessage>
    {
        protected override void Handle(in PositionsMessage message, uint messageId, bool needResponse)
        {
            UpdateTransformSystem.SetNewTransforms(messageId, message.EntitiesInfo);
        }
    }
}