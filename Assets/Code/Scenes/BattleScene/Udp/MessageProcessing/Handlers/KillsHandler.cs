// using Boo.Lang;

using System.Collections.Generic;
using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;
using NetworkLibrary.NetworkLibrary.Udp;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class KillsHandler : IMessageHandler
    {
        readonly List<uint> messageIds = new List<uint>();

        public void Handle(MessageWrapper message)
        {
            if (messageIds.Contains(message.MessageId))
            {
                return;
            }
            else
            {
                messageIds.Add(message.MessageId);
            }

            var killInfo = ZeroFormatterSerializer.Deserialize<KillMessage>(message.SerializedMessage);
            KillsIndicatorSystem.AddNewKillInfo(killInfo);
        }
    }
}