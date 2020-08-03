using System.Collections.Generic;
using Code.Scenes.BattleScene.Udp.Experimental;
using Entitas;
using UnityEngine;

//TODO использовать контейнер

namespace Code.Scenes.BattleScene.ECS.Systems.NetworkSenderSystems
{
    public class RudpMessagesSenderSystem:IExecuteSystem
    {
        private readonly UdpSendUtils udpSendUtils;

        public RudpMessagesSenderSystem(UdpSendUtils udpSendUtils)
        {
            this.udpSendUtils = udpSendUtils;
        }
        
        public void Execute()
        {
            ICollection<byte[]> messages = RudpStorage.Instance.GetReliableMessages();
            if (messages != null && messages.Count != 0)
            {
                foreach (var message in messages)
                {
                    udpSendUtils.SendMessage(message);
                }
            }
        }
    }
}