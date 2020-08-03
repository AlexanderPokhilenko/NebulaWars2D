using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Common.Logger;
using Code.Common.NetworkStatistics;
using Code.Scenes.BattleScene.Scripts.Debug;
using Code.Scenes.BattleScene.Udp.Experimental;
using Code.Scenes.BattleScene.Udp.MessageProcessing;
using NetworkLibrary.NetworkLibrary.Udp;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp
{
    /// <summary>
    /// Перенапрвляет сообщения от UdpClient к сортировщику сообщений
    /// </summary>
    public class UdpMediator
    {
        private MessageProcessor messageProcessor;
        private readonly ILog log = LogManager.CreateLogger(typeof(UdpMediator));

        public void Initialize(UdpSendUtils udpSendUtils, int matchId)
        {
            if (messageProcessor != null)
            {
                throw new Exception("Повторная инициализация");
            }
            messageProcessor= new MessageProcessor(udpSendUtils, matchId);
        }

        public void HandleBytes(byte[] datagram)
        {
            MessagesPack messagesContainer = ZeroFormatterSerializer.Deserialize<MessagesPack>(datagram);
            NetworkStatisticsStorage.Instance.RegisterDatagram(datagram.Length, messagesContainer.Id);
            foreach (byte[] data in messagesContainer.Messages)
            {
                MessageWrapper message = ZeroFormatterSerializer.Deserialize<MessageWrapper>(data);
                NetworkStatisticsStorage.Instance.RegisterMessage(data.Length, message.MessageType);
                messageProcessor.Handle(message);
            }
        }
    }
}