using Code.Common;
using Code.Common.Storages;
using Code.Scenes.BattleScene.Scripts;
using Code.Scenes.BattleScene.Udp.Connection;
using Libraries.NetworkLibrary.Udp.Common;
using Libraries.NetworkLibrary.Udp.PlayerToServer;
using NetworkLibrary.NetworkLibrary.Udp;
using NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.Ping;
using NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.UserInputMessage;
using UnityEngine;

namespace Code.Scenes.BattleScene.Udp.Experimental
{
    /// <summary>
    /// Принимает запросы на отправку сообщений от систем и перенаправляет их UdpClient-у
    /// </summary>
    public class UdpSendUtils
    {
        private readonly int matchId;
        private readonly UdpClientWrapper udpClientWrapper;
        
        public UdpSendUtils(int matchId, UdpClientWrapper udpClientWrapper)
        {
            this.matchId = matchId;
            this.udpClientWrapper = udpClientWrapper;
        }

        public void SendInputMessage(float movementX, float movementY, float attackAngle,bool useAbility)
        {
            ushort myId = PlayerIdStorage.TmpPlayerIdForMatch;
            
            // Debug.LogWarning($"{nameof(myId)} {myId}");
            var message = new PlayerInputMessage(myId, matchId, movementX, movementY, 
                attackAngle, useAbility);
            byte[] data = MessageFactory.GetSerializedMessage(message, false, out uint messageId);
            udpClientWrapper.Send(data);
        }
        
        public void SendPingMessage()
        {
            var myId = PlayerIdStorage.TmpPlayerIdForMatch;
            var message = new PlayerPingMessage(myId, matchId);
            byte[] data = MessageFactory.GetSerializedMessage(MessageFactory.GetMessage(message,false, 
                out uint messageId));
            udpClientWrapper.Send(data);
        }
        
        public void SendDeliveryConfirmationMessage(uint messageNumberThatConfirms)
        {
            ushort myId = PlayerIdStorage.TmpPlayerIdForMatch;
            DeliveryConfirmationMessage message = new DeliveryConfirmationMessage
            {
                MessageNumberThatConfirms = messageNumberThatConfirms,
                PlayerId = myId,
                MatchId = matchId
            };
            MessageWrapper messageWrapper = MessageFactory.GetMessage(message, false, out uint messageId);
            byte[] data = MessageFactory.GetSerializedMessage(messageWrapper);
            udpClientWrapper.Send(data);
        }
        
        public void SendMessage(MessageWrapper message)
        {
            byte[] data = MessageFactory.GetSerializedMessage(message);
            udpClientWrapper.Send(data);
        }
        
        public void SendMessage(byte[] serializedMessage)
        {
            udpClientWrapper.Send(serializedMessage);
        }
        
        public void SendExitNotification()
        {
            var myId = PlayerIdStorage.TmpPlayerIdForMatch;
            BattleExitMessage exitMessage = new BattleExitMessage(matchId, myId);
            MessageWrapper message = MessageFactory.GetMessage(exitMessage, false, out uint messageId);
            byte[] data = MessageFactory.GetSerializedMessage(message);
            udpClientWrapper.Send(data);
        }
    }
}