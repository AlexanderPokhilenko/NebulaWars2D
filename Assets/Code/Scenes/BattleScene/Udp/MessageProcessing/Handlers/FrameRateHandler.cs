using Code.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;
using NetworkLibrary.NetworkLibrary.Udp;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class FrameRateHandler : IMessageHandler
    {
        public void Handle(MessageWrapper message)
        {
            var msg = ZeroFormatterSerializer.Deserialize<FrameRateMessage>(message.SerializedMessage);

            TimeSpeedSystem.SetFrameRate(message.MessageId, msg.DeltaTime);
        }
    }
}