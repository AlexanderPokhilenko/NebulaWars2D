using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Common;
using Code.Common.Logger;
using JetBrains.Annotations;
using NetworkLibrary.NetworkLibrary.Http;
using ZeroFormatter;

namespace Code.Scenes.LobbyScene.Scripts.Listeners
{
    public class LootboxModelDownloader
    {
        private Task<LootboxModel> task;
        private readonly ILog log = LogManager.CreateLogger(typeof(LootboxModelDownloader));
        private static readonly Lazy<LootboxModelDownloader> instance = 
            new Lazy<LootboxModelDownloader>(() => new LootboxModelDownloader());
        public static LootboxModelDownloader Instance => instance.Value;

        public void StartDownloading()
        {
            task = DownloadLootboxData();
        }

        public bool IsDownloadingCompleted()
        {
            return true;
            if (task == null)
            {
                log.Debug("task is null");
                return false;
            }
            
            return task.IsCompleted;
        }
        
        [CanBeNull]
        public LootboxModel GetLootboxModel()
        {
            // return task.Result;
            LootboxModel lootboxModel = new LootboxModel()
            {
                Prizes = new List<LootboxPrizeModel>()
                {
                    new LootboxPrizeModel()
                    {
                        LootboxPrizeType = LootboxPrizeType.SoftCurrency,
                        SerializedModel = ZeroFormatterSerializer.Serialize(new LootboxSoftCurrencyModel()
                        {
                            Amount = 53
                        })
                    },
                    new LootboxPrizeModel()
                    {
                        LootboxPrizeType = LootboxPrizeType.HardCurrency,
                        SerializedModel = ZeroFormatterSerializer.Serialize(new LootboxHardCurrencyModel()
                        {
                            Amount = 53
                        })
                    },
                    new LootboxPrizeModel()
                    {
                        LootboxPrizeType = LootboxPrizeType.WarshipPowerPoints,
                        SerializedModel = ZeroFormatterSerializer.Serialize(new LootboxWarshipPowerPointsModel()
                        {
                            WarshipPrefabName = "hare",
                            Amount = 20
                        })
                    }
                }
            };
            return lootboxModel;
        }
        
        private async Task<LootboxModel> DownloadLootboxData()
        {
            string url = NetworkGlobals.GetLootboxDataUrl;
            if (!PlayerIdStorage.TryGetServiceId(out string playerServiceId))
            {
                log.Error($"{nameof(DownloadLootboxData)} {nameof(playerServiceId)} is null");
                return null;
            }
            
            if (playerServiceId == null)
            {
                log.Error($"{nameof(playerServiceId)} is null");
                return null;
            }
            
            (string name, string value)[] fields =
            {
                (nameof(playerServiceId), playerServiceId)
            };

            try
            {
                byte[] data = await HttpWrapper.Post(url, fields);
                if (data != null && data.Length != 0)
                {
                    return ZeroFormatterSerializer.Deserialize<LootboxModel>(data);
                }
                else
                {
                    log.Error("Пустой ответ от сервера");
                }
            }
            catch (Exception e)
            {
                log.Error("Упало при скачивании данных о лутбоксе " + e.Message);
            }

            return null;
        }
    }
}