using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class MaxHealthPointsHandler:MessageHandler<MaxHealthPointsMessage>
    {
        protected override void Handle(in MaxHealthPointsMessage message, uint messageId, bool needResponse)
        {
            MaxHealthPointsUpdaterSystem.SetMaxHealthPoints(message.Value);
        }
    }
}