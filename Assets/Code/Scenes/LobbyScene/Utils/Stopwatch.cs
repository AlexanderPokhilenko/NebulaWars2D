using System;

namespace Code.Scenes.LobbyScene.Utils
{
    /// <summary>
    /// Нужен для того, чтобы получать время задержки при отправке сообщений по http для MatchmakerNegotiator
    /// </summary>
    public class Stopwatch
    {
        private DateTime? lastCallTime;
        
        //[0, 1000]
        public int GetDelayNoMoreThanASecond()
        {
            DateTime now = DateTime.Now;
            int resultDelay;
            if (lastCallTime == null)
            {
                resultDelay = 1000;
            }
            else
            {
                TimeSpan timeBetweenMethodCalls = now - lastCallTime.Value;
                if (timeBetweenMethodCalls.TotalMilliseconds > 1000)
                {
                    resultDelay = 1000;
                }
                else
                {
                    resultDelay = (int) timeBetweenMethodCalls.TotalMilliseconds;
                }
            }
            lastCallTime = now;
            return resultDelay;
        }
    }
}