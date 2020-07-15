using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards.Images
{
    /// <summary>
    /// Создаёт GameObject-ы для двигающихся наград из префабов в зависимости от типа награды.
    /// </summary>
    public class MovingAwardImagesGameObjectCreationSystem:ReactiveSystem<LobbyUiEntity>
    {
        private readonly RectTransform movingAwardsParentRectTransform;
        private GameObject regularCurrencyGameObjectCache;
        private GameObject premiumCurrencyGameObjectCache;
        private GameObject trophyGameObjectCache;
        private GameObject lootboxPointGameObjectCache;
        
        public MovingAwardImagesGameObjectCreationSystem(Contexts contexts,
            RectTransform movingAwardsParentRectTransform) 
            : base(contexts.lobbyUi)
        {
            this.movingAwardsParentRectTransform = movingAwardsParentRectTransform;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.AllOf(LobbyUiMatcher.MovingAward)
                .NoneOf(LobbyUiMatcher.View, LobbyUiMatcher.Image));
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasMovingAward && !entity.hasView && !entity.hasImage;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            int index = 0;
            foreach (var entity in entities)
            {
                GameObject awardGo = SpawnAwardPrefab(entity.movingAward.awardType);
                awardGo.name += (index++).ToString();
                entity.AddView(awardGo);
                entity.AddImage(awardGo.GetComponent<Image>());    
            }
        }

        private GameObject SpawnAwardPrefab(AwardType awardType)
        {
            GameObject prefab;
            switch (awardType)
            {
                case AwardType.SoftCurrency:
                    prefab = GetRegularCurrencyPrefab();
                    break;
                case AwardType.AccountRating:
                    prefab = GetTrophyPrefab();
                    break;
                case AwardType.HardCurrency:
                    prefab = GetPremiumCurrencyPrefab();
                    break;
                case AwardType.LootboxPoints:
                    prefab = GetLootboxPointPrefab();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(awardType), awardType, null);
            }
            GameObject result = Object.Instantiate(prefab, movingAwardsParentRectTransform,false);
            return result;
        }
        
        private GameObject GetRegularCurrencyPrefab()
        {
            if (regularCurrencyGameObjectCache == null)
            {
                regularCurrencyGameObjectCache = Resources.Load<GameObject>("Prefabs/RegularCurrencyIcon");
                if (regularCurrencyGameObjectCache == null)
                {
                    throw new Exception("RegularCurrencyIcon prefab not found");
                }    
            }

            return regularCurrencyGameObjectCache;
        }
        
        private GameObject GetPremiumCurrencyPrefab()
        {
            if (premiumCurrencyGameObjectCache == null)
            {
                premiumCurrencyGameObjectCache = Resources.Load<GameObject>("Prefabs/HardCurrencyIcon");
                if (premiumCurrencyGameObjectCache == null)
                {
                    throw new Exception("HardCurrency prefab not found");
                }    
            }

            return premiumCurrencyGameObjectCache;
        }

        private GameObject GetLootboxPointPrefab()
        {
            if (lootboxPointGameObjectCache == null)
            {
                lootboxPointGameObjectCache = Resources.Load<GameObject>("Prefabs/SmallLootboxPoint");
                if (lootboxPointGameObjectCache == null)
                {
                    throw new Exception("SmallLootboxPoint prefab not found");
                }    
            }

            return lootboxPointGameObjectCache;
        }
        
        private GameObject GetTrophyPrefab()
        {
            if (trophyGameObjectCache == null)
            {
                trophyGameObjectCache = Resources.Load<GameObject>("Prefabs/Trophy");
                if (trophyGameObjectCache == null)
                {
                    throw new Exception("AccountRating prefab not found");
                }    
            }

            return trophyGameObjectCache;
        }
    }
}