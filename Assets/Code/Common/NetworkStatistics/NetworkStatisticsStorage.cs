using System;
using System.Collections.Generic;
using NetworkLibrary.NetworkLibrary.Udp;

namespace Code.Common.NetworkStatistics
{
    /// <summary>
    /// Отвечает за запись статистики сети для всех боёв
    /// </summary>
    public class NetworkStatisticsStorage
    {
        private MatchNetworkStatistics lastMatch;
        public static NetworkStatisticsStorage Instance => Lazy.Value;
        private readonly List<MatchNetworkStatistics> matches=new List<MatchNetworkStatistics>();
        private static readonly Lazy<NetworkStatisticsStorage> Lazy = 
            new Lazy<NetworkStatisticsStorage> (() => new NetworkStatisticsStorage()); 

        public void StartRecordingNewMatch(string matchId, string matchInfo)
        {
            lastMatch = new MatchNetworkStatistics(matchId, matchInfo);
            matches.Add(lastMatch);
        }

        // public void RegisterMessage(int messageLength, MessageType messageType)
        // {
        //     if (lastMatch == null)
        //     {
        //         throw new Exception($"Перед добавлением сообщения нужно вызвать {nameof(StartRecordingNewMatch)}");
        //     }
        //
        //     lastMatch.RegisterMessage(messageLength, messageType);
        // }

        public int GetLastFramerate()
        {
            return lastMatch.GetLastFramerate();
        }
        public void RegisterDatagram(int datagramLength)
        {
            if (lastMatch == null)
            {
                throw new Exception($"Перед добавлением сообщения нужно вызвать {nameof(StartRecordingNewMatch)}");
            }

            lastMatch.RegisterDatagram(datagramLength);
        }

        public void PrintSavedMatches()
        {
            foreach (MatchNetworkStatistics match in matches)
            {
                match.Print();
            }
            matches.Clear();
            lastMatch = null;
        }
    }
}