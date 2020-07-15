using System;
using System.Collections.Generic;
using Code.Scenes.BattleScene.Udp.Experimental;
using Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers;
using NetworkLibrary.NetworkLibrary.Udp;
using UnityEngine;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing
{
    /// <summary>
    /// Перенаправляет входящее сообщение на нужный обработчик. 
    /// </summary>
    public class MessageProcessor
    {
        private readonly HashSet<uint> receivedMessagesRUDP;
        private readonly PlayerInfoMessageHandler playerInfoMessageHandler;
        private readonly PositionsMessageHandler positionsMessageHandler;
        private readonly RadiusesMessageHandler radiusesMessageHandler;
        private readonly ParentsMessageHandler parentsMessageHandler;
        private readonly DetachesMessageHandler detachesMessageHandler;
        private readonly DestroysMessageHandler destroysMessageHandler;
        private readonly HidesMessageHandler hidesMessageHandler;
        private readonly RudpConfirmationSender rudpConfirmationSender;
        private readonly HealthPointsHandler hpHandler;
        private readonly MaxHealthPointsHandler maxHpHandler;
        private readonly ShieldPointsHandler shieldHandler;
        private readonly MaxShieldPointsHandler maxShieldHandler;
        private readonly RudpConfirmationReceiver rudpConfirmationReceiver;
        private readonly KillsHandler killsHandler;
        private readonly ShowPlayerAchievementsHandler playerAchievementsHandler;
        private readonly CooldownsInfosHandler cooldownInfoHandler;
        private readonly CooldownsHandler cooldownHandler;

        public MessageProcessor(UdpSendUtils udpSendUtils, int matchId)
        {
            receivedMessagesRUDP = new HashSet<uint>();
            playerInfoMessageHandler = new PlayerInfoMessageHandler();
            positionsMessageHandler = new PositionsMessageHandler();
            radiusesMessageHandler = new RadiusesMessageHandler();
            parentsMessageHandler = new ParentsMessageHandler();
            detachesMessageHandler = new DetachesMessageHandler();
            destroysMessageHandler = new DestroysMessageHandler();
            hidesMessageHandler = new HidesMessageHandler();
            rudpConfirmationSender = new RudpConfirmationSender(udpSendUtils);
            hpHandler = new HealthPointsHandler();
            rudpConfirmationReceiver = new RudpConfirmationReceiver();
            maxHpHandler = new MaxHealthPointsHandler();
            shieldHandler = new ShieldPointsHandler();
            maxShieldHandler = new MaxShieldPointsHandler();
            killsHandler = new KillsHandler();
            playerAchievementsHandler = new ShowPlayerAchievementsHandler(matchId);
            cooldownInfoHandler = new CooldownsInfosHandler();
            cooldownHandler = new CooldownsHandler();
        }
        
        public void Handle(MessageWrapper messageWrapper)
        {
            if (messageWrapper.NeedResponse)
            {
                rudpConfirmationSender.Handle(messageWrapper);
                //Если мы уже обработали это сообщение, то мы его пропускаем.
                if (!receivedMessagesRUDP.Add(messageWrapper.MessageId)) return;
            }
            
            switch (messageWrapper.MessageType)
            {
                case MessageType.Positions:
                    positionsMessageHandler.Handle(messageWrapper);
                    break;
                case MessageType.DeliveryConfirmation:
                    rudpConfirmationReceiver.Handle(messageWrapper);
                    break;
                case MessageType.HealthPoints:
                    hpHandler.Handle(messageWrapper);
                    break;
                case MessageType.MaxHealthPoints:
                    maxHpHandler.Handle(messageWrapper);
                    break;
                case MessageType.Kill:
                    killsHandler.Handle(messageWrapper);
                    break;
                case MessageType.PlayerTracking:
                    //TODO добавить
                    break;
                case MessageType.PointTracking:
                    //TODO добавить
                    break;
                case MessageType.ShowPlayerAchievements:
                    playerAchievementsHandler.Handle(messageWrapper);
                    break;
                case MessageType.ShieldPoints:
                    shieldHandler.Handle(messageWrapper);
                    break;
                case MessageType.MaxShieldPoints:
                    maxShieldHandler.Handle(messageWrapper);
                    break;
                case MessageType.CooldownsInfos:
                    cooldownInfoHandler.Handle(messageWrapper);
                    break;
                case MessageType.Cooldowns:
                    cooldownHandler.Handle(messageWrapper);
                    break;
                case MessageType.PlayerInfo:
                    playerInfoMessageHandler.Handle(messageWrapper);
                    break;
                case MessageType.Radiuses:
                    radiusesMessageHandler.Handle(messageWrapper);
                    break;
                case MessageType.Parents:
                    parentsMessageHandler.Handle(messageWrapper);
                    break;
                case MessageType.Detaches:
                    detachesMessageHandler.Handle(messageWrapper);
                    break;
                case MessageType.Destroys:
                    destroysMessageHandler.Handle(messageWrapper);
                    break;
                case MessageType.Hides:
                    hidesMessageHandler.Handle(messageWrapper);
                    break;
                default: 
                    throw new Exception($"Пришло сообщение с неожиданным типом = {messageWrapper.MessageType}");
            }
        }
    }
}