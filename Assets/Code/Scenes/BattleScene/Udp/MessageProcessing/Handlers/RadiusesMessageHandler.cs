using Code.BattleScene.ECS.Systems;
using NetworkLibrary.NetworkLibrary.Udp;
using NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class RadiusesMessageHandler : IMessageHandler
    {
        public void Handle(MessageWrapper messageWrapper)
        {
            var mes = ZeroFormatterSerializer.Deserialize<RadiusesMessage>(messageWrapper.SerializedMessage);
            UpdateRadiusSystem.SetNewRadiuses(mes.FloatRadiusInfo);
        }
    }
}