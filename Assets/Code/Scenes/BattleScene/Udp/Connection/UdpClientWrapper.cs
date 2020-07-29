using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Code.Common.Logger;
using UnityEngine;

namespace Code.Scenes.BattleScene.Udp.Connection
{
   public abstract class UdpClientWrapper:IDisposable
    {
        private readonly UdpClient udpClient;
        private readonly IPEndPoint serverEndpoint;
        private CancellationTokenSource cancellationTokenSource;
        private readonly ILog log = LogManager.CreateLogger(typeof(UdpClientWrapper));

        protected UdpClientWrapper(UdpClient udpClient, IPEndPoint serverEndpoint)
        {
            this.udpClient = udpClient;
            this.serverEndpoint = serverEndpoint;
        }
        
        public void StartReceiveThread()
        {
            cancellationTokenSource = new CancellationTokenSource();
            Task listenTask = new Task(async () => await Listen(), TaskCreationOptions.LongRunning);
            listenTask.Start();
        }

        private async Task Listen()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    var result = await udpClient.ReceiveAsync();
                    byte[] receiveBytes = result.Buffer;
                    HandleBytes(receiveBytes);
                }
                catch (SocketException e)
                {
                    // 10004 thrown when socket is closed
                    if (e.ErrorCode != 10004)
                    {
                        log.Error("Socket exception while receiving data from udp client: " + e.Message);
                    }
                }
                catch (Exception e)
                {
                    log.Warn("Error receiving data from udp client: " + e.Message);
                }
            }
        }

        public void Send(byte[] data)
        {
            udpClient.Send(data, data.Length, serverEndpoint);
        }
        
        public void Stop()
        {
            cancellationTokenSource.Cancel();
            udpClient.Close();
        }

        protected abstract void HandleBytes(byte[] data);

        public void Dispose()
        {
            udpClient?.Dispose();
            cancellationTokenSource?.Dispose();
        }
    }
}