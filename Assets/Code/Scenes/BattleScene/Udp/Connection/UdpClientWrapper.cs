using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Code.Common;
using Code.Common.Logger;
using UnityEngine;

namespace Code.Scenes.BattleScene.Udp.Connection
{
   public abstract class UdpClientWrapper:IDisposable
    {
        private readonly UdpClient udpClient;
        private CancellationTokenSource cancellationTokenSource;
        private readonly ILog log = LogManager.CreateLogger(typeof(UdpClientWrapper));

        protected UdpClientWrapper(UdpClient udpClient)
        {
            this.udpClient = udpClient;
        }
        
        public void StartReceiveThread()
        {
            cancellationTokenSource = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(ThreadWork);
        }
        
        private async void ThreadWork(object state)
        {
            await Listen();
        }

        private async Task Listen()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    UdpReceiveResult result = await udpClient.ReceiveAsync();
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
                catch (ObjectDisposedException e)
                {
                    log.Warn("UdpClient was disposed. All ok.");
                }
                catch (Exception e)
                {
                    log.Error("Error receiving data from udp client: " + e.Message);
                }
            }
        }

        public void Send(byte[] data)
        {
            udpClient.SendAsync(data, data.Length);
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