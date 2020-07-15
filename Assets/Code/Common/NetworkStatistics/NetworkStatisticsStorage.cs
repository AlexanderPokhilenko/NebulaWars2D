using System;
using System.Collections.Generic;
using System.Linq;
using NetworkLibrary.NetworkLibrary.Udp;

namespace Code.Common
{
    /// <summary>
    /// Отвечает за запись статистики сети для всех боёв
    /// </summary>
    public class NetworkStatisticsStorage
    {
        private static readonly Lazy<NetworkStatisticsStorage> Lazy = new Lazy<NetworkStatisticsStorage> (() => new NetworkStatisticsStorage()); 
        public static NetworkStatisticsStorage Instance => Lazy.Value;

        private readonly List<MatchNetworkStatistics> matches=new List<MatchNetworkStatistics>();

        private MatchNetworkStatistics lastMatch;

        public void StartRecordingNewMatch(string matchId, string matchInfo)
        {
            lastMatch = new MatchNetworkStatistics(matchId, matchInfo);
            matches.Add(lastMatch);
        }

        public void RegisterMessage(int messageLength, MessageType messageType)
        {
            if (lastMatch == null)
            {
                throw new Exception($"Перед добавлением сообщения нужно вызвать {nameof(StartRecordingNewMatch)}");
            }

            lastMatch.RegisterMessage(messageLength, messageType);
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
            foreach (var match in matches)
            {
                match.Print();
            }
            matches.Clear();
            lastMatch = null;
        }
    }
}