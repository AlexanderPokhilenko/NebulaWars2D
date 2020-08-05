using Code.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class FrameRateHandler : MessageHandler<FrameRateMessage>
    {
        protected override void Handle(in FrameRateMessage message, uint messageId, bool needResponse)
        {
            TimeSpeedSystem.SetFrameRate(messageId, message.DeltaTime);
        }
    }
}