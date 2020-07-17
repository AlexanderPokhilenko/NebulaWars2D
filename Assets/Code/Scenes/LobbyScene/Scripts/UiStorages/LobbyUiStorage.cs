using Code.Common;
using Code.Common.Logger;
using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.UiStorages
{
    /// <summary>
    /// Отвечает за хранение ссылок на ui элементы. 
    /// </summary>
    public class LobbyUiStorage : MonoBehaviour
    {
        [Header("Загрузка боя")]
        [Tooltip("Описание")]
        public GameObject blurImage;
        public GameObject battleLoadingMenu;
        public Text waitTimeText;
        public Text numberOfPlayersInQueueText;
        public Text numberOfPlayersInBattlesText;

        [Header("Кнопка START")] 
        public RectTransform startButton;
        
        [Header("Картинки вокруг кнопки START")]
        public RectTransform[] startButtonSatellites;
        
        [Header("Данные аккаунта")]
        public Text softCurrencyText;
        public Text hardCurrencyText;
        public Text usernameText;
        public Text accountRatingText;
        public Text smallLootboxText;
        public Slider lootboxSlider;
        
        public RectTransform trophy;
        public RectTransform regularCurrency;
        
        [Header("Кнопки смены кораблей")]
        public GameObject buttonScrollRight;
        public GameObject buttonScrollLeft;

        [Header("Шкала опыта над текущим кораблём")]
        public Text rankText;
        public Text ratingText;
        public Slider ratingSlider;

        [Header("Пин для маленького сундука")]
        public GameObject smallLootboxPinGameObject;
        public Text smallLootboxPinText;

        [Header("Родитель для корабликов")]
        public Transform warshipsRoot;

        [HideInInspector] public UiSoundsManager lobbySoundsManager;
        [HideInInspector] public Material blurMaterial;
        private readonly ILog log = LogManager.CreateLogger(typeof(LobbyUiStorage));

        private void Awake()
        {
            lobbySoundsManager = UiSoundsManager.Instance();
            var buttons = FindObjectsOfType<Button>();
            foreach (var button in buttons) // Возможно, потом стоит заменить на что-то лучшее
            {
                button.onClick.AddListener(lobbySoundsManager.PlayClick);
            }
            try
            {
                blurMaterial = blurImage.GetComponent<Image>().material;
            }
            catch (Exception e)
            {
                log.Fatal("Start method throw an exception " + e.Message);
            }
        }

        public void Check()
        {
            Assert.IsNotNull(blurImage);
            Assert.IsNotNull(battleLoadingMenu);
            Assert.IsNotNull(waitTimeText);
            Assert.IsNotNull(numberOfPlayersInQueueText);
            Assert.IsNotNull(numberOfPlayersInBattlesText);
            Assert.IsNotNull(startButton);
            Assert.IsNotNull(startButtonSatellites);
            Assert.IsNotNull(hardCurrencyText);
            Assert.IsNotNull(softCurrencyText);
            Assert.IsNotNull(usernameText);
            Assert.IsNotNull(accountRatingText);
            Assert.IsNotNull(smallLootboxText);
            Assert.IsNotNull(trophy);
            Assert.IsNotNull(regularCurrency);
            Assert.IsNotNull(buttonScrollRight);
            Assert.IsNotNull(buttonScrollLeft);
            Assert.IsNotNull(rankText);
            Assert.IsNotNull(ratingText);
            Assert.IsNotNull(ratingSlider);
            Assert.IsNotNull(smallLootboxPinGameObject);
            Assert.IsNotNull(smallLootboxPinText);
            Assert.IsNotNull(lobbySoundsManager);
        }
    }
}
