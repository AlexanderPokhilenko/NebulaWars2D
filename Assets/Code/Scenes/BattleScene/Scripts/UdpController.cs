using System.Net;
using System.Net.Sockets;
using Code.Common;
using Code.Scenes.BattleScene.Udp;
using Code.Scenes.BattleScene.Udp.Connection;
using Code.Scenes.BattleScene.Udp.Experimental;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.BattleScene.Scripts
{
    /// <summary>
    /// Отвечает за создание/остановку udp соединения.
    /// </summary>
    public class UdpController : MonoBehaviour
    {
        private UdpSendUtils udpSendUtils;
        private BattleUdpClientWrapper udpClientWrapper;
        private readonly ILog log = LogManager.CreateLogger(typeof(UdpController));
        
        private void Awake()
        {
            //Если в прошлом бою уже был создан UdpClient
            udpClientWrapper?.Stop();
            
            var matchData = MyMatchDataStorage.Instance.GetMatchModel();
            int matchId = matchData.MatchId;
            int gameServerPort = matchData.GameServerPort;
            string gameServerIp = matchData.GameServerIp;
            IPEndPoint serverIpEndPoint = new IPEndPoint(IPAddress.Parse(gameServerIp), gameServerPort);
            UdpMediator udpMediator = new UdpMediator();
            
            log.Info("Установка прослушки udp.");
            UdpClient udpClient = new UdpClient
            {
                Client =
                {
                    Blocking = false,
                    ReceiveTimeout = 1000
                }
            };
            
            udpClientWrapper = new BattleUdpClientWrapper(udpMediator, udpClient, serverIpEndPoint);
            udpSendUtils = new UdpSendUtils(matchId, udpClientWrapper);
            udpMediator.Initialize(udpSendUtils, matchId);
            udpClientWrapper.StartReceiveThread();   
        }
        
        public UdpSendUtils GetUdpSendUtils()
        {
            return udpSendUtils;
        }

        /// <summary>
        /// Тут не нужно закрывать соединение потому, что сообщения могут
        ///  отправляться/приниматься ещё несколько секунд
        /// </summary>
        private void OnDestroy()
        {
            ;
        }
    }
}