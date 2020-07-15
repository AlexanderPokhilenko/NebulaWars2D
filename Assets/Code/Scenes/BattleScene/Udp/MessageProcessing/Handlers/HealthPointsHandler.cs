using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer;
using NetworkLibrary.NetworkLibrary.Udp;
using UnityEngine;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class HealthPointsHandler:IMessageHandler
    {
        public void Handle(MessageWrapper message)
        {
            HealthPointsMessage hpMessage =
                ZeroFormatterSerializer.Deserialize<HealthPointsMessage>(message.SerializedMessage);
            
            HealthAndShieldPointsUpdaterSystem.SetHealthPoints(hpMessage.Value);
            ////DebugLogError("Пришло сообщение с показателем прочности значение = "+hpMessage.Value);
        }
    }
}