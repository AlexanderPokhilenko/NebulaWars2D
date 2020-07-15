using System;
using Code.Scenes.LobbyScene.ECS.Components;
using UnityEngine;
using UnityEngine.Assertions;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Синглтон
    /// Хранит публичные ссылки на ui элементы, которые нужны для рисования анимации начисления наград.
    /// </summary>
    public class MovingAwardsUiElementsStorage : MonoBehaviour
    {
        [Header("Родительские объекты на Canvas")]
        public RectTransform movingAwardImageParentRectTransform;
        public RectTransform movingAwardTextParentRectTransform;
        public RectTransform movingAwardImageUpperObject;
        
        [Header("Старт и финиш для обычной валюты")]
        [SerializeField] private RectTransform softCurrencyStartPoint;
        [SerializeField] private RectTransform softCurrencyFinishPoint;
        
        [Header("Старт и финиш для премиум валюты")]
        [SerializeField] private RectTransform hardCurrencyStartPoint;
        [SerializeField] private RectTransform hardCurrencyFinishPoint;
        
        [Header("Старт и финиш для рейтинга")]
        [SerializeField] private RectTransform trophyStartPoint;
        [SerializeField] private RectTransform trophyFinishPoint;
        
        [Header("Старт и финиш для баллов маленького сундука")]
        [SerializeField] private RectTransform smallLootboxStartPoint;
        [SerializeField] private RectTransform smallLootboxFinishPoint;

        private static MovingAwardsUiElementsStorage instance;
        private void Awake()
        {
            instance = this;
        }

        public static MovingAwardsUiElementsStorage Instance()
        {
            return instance;
        }
        
        public Vector3 GetStartPoint(AwardType awardType)
        {
            switch (awardType)
            {
                case AwardType.SoftCurrency:
                    return softCurrencyStartPoint.position;
                case AwardType.AccountRating:
                    return trophyStartPoint.position;
                case AwardType.HardCurrency:
                    return hardCurrencyStartPoint.position;
                case AwardType.LootboxPoints:
                    return smallLootboxStartPoint.position;
                default:
                    throw new ArgumentOutOfRangeException(nameof(awardType), awardType, null);
            }
        }
        
        public Vector3 GetFinishPoint(AwardType awardType)
        {
            switch (awardType)
            {
                case AwardType.SoftCurrency:
                    return softCurrencyFinishPoint.position;
                case AwardType.AccountRating:
                    return trophyFinishPoint.position;
                case AwardType.HardCurrency:
                    return hardCurrencyFinishPoint.position;
                case AwardType.LootboxPoints:
                    return smallLootboxFinishPoint.position;
                default:
                    throw new ArgumentOutOfRangeException(nameof(awardType), awardType, null);
            }
        }

        public void Check()
        {
            Assert.IsNotNull(movingAwardImageParentRectTransform);
            Assert.IsNotNull(movingAwardTextParentRectTransform);
            Assert.IsNotNull(movingAwardImageUpperObject);
            Assert.IsNotNull(softCurrencyStartPoint);
            Assert.IsNotNull(softCurrencyFinishPoint);
            Assert.IsNotNull(hardCurrencyStartPoint);
            Assert.IsNotNull(hardCurrencyFinishPoint);
            Assert.IsNotNull(trophyStartPoint);
            Assert.IsNotNull(trophyFinishPoint);
            Assert.IsNotNull(smallLootboxStartPoint);
            Assert.IsNotNull(smallLootboxFinishPoint);
        }
    }
}