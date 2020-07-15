using Code.BattleScene.ECS.Systems;
using NetworkLibrary.NetworkLibrary.Udp;
using NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class PositionsMessageHandler:IMessageHandler
    {
        public void Handle(MessageWrapper messageWrapper)
        {
            PositionsMessage mes = ZeroFormatterSerializer.Deserialize<PositionsMessage>(messageWrapper.SerializedMessage);
            UpdateTransformSystem.SetNewTransforms(messageWrapper.MessageId, mes.EntitiesInfo);
        }
    }
}