﻿using Code.Common.Logger;

namespace Code.Common
{
    /// <summary>
    /// Отвечает за извлечение/генерацию serviceId в целях отладки. 
    /// </summary>
    public static class PlayerIdStorage
    {
        //TODO Сокрытие пошло по жопе
        public static ushort TmpPlayerMatchId { get; private set; }
        public static ushort PlayerEntityId { get; set; }
        public static int AccountId { get; set; }
        
        private static string cacheUsername;
        private static bool serviceIdIsRequested;
        private static string cachePlayerServiceId;
        private static readonly object lockObj = new object();
        private static readonly ILog log = LogManager.CreateLogger(typeof(PlayerIdStorage));

        public static void SetServiceId(string serviceId)
        {
            lock (lockObj)
            {
                log.Info($"{nameof(SetServiceId)} установка {nameof(serviceId)} {serviceId}");
                cachePlayerServiceId = serviceId;
            }
        }
        
        public static bool TryGetServiceId(out string playerServiceId)
        {
            if (cachePlayerServiceId == null)
            {
                playerServiceId = null;
                return false;
            }

            playerServiceId = cachePlayerServiceId;
            return true;
        }

        /// <summary>
        /// Сокрытие пошло по жопе
        /// </summary>
        /// <param name="temporaryId">Временный id игрока на один бой</param>
        public static void SetTmpPlayerId(ushort temporaryId)
        {
            TmpPlayerMatchId = temporaryId;
        }

        public static void SetUsername(string usernameArg)
        {
            lock (lockObj)
            {
                log.Info($"{nameof(SetUsername)} установка {nameof(cacheUsername)} {cacheUsername}");
                cacheUsername = usernameArg;
            }
        }

        public static bool TryGetUsername(out string username)
        {
            username = cacheUsername;
            return cacheUsername != null;
        }
    }
}