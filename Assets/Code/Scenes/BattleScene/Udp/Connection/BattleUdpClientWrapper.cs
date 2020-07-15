
using System.Net;
using System.Net.Sockets;

namespace Code.Scenes.BattleScene.Udp.Connection
{
    public class BattleUdpClientWrapper:UdpClientWrapper
    {
        private readonly UdpMediator udpMediator;

        public BattleUdpClientWrapper(UdpMediator udpMediator, UdpClient udpClient, IPEndPoint serverEndpoint)
            :base(udpClient, serverEndpoint)
        {
            this.udpMediator = udpMediator;
        }

        protected override void HandleBytes(byte[] data)
        {
            udpMediator.HandleBytes(data);
        }
    }
}