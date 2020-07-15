using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer;
using NetworkLibrary.NetworkLibrary.Udp;
using UnityEngine;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class MaxHealthPointsHandler:IMessageHandler
    {
        public void Handle(MessageWrapper message)
        {
            MaxHealthPointsMessage maxHealthPoints =
                ZeroFormatterSerializer.Deserialize<MaxHealthPointsMessage>(message.SerializedMessage);
            
            HealthAndShieldPointsUpdaterSystem.SetMaxHealthPoints(maxHealthPoints.Value);
           //DebugLogError("Пришло сообщение с максимальным показателем прочности значение = "+maxHealthPoints.Value);
        }
    }
}