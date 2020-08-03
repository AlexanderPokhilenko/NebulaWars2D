using Code.Common;
using Code.Common.Logger;
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
        public GameObject gameViewsRoot;
        public GameObject overlayCanvas;
        
        [Header("Загрузка боя")]
        [Tooltip("Описание")]
        // public Image blurImage;
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
        

        [Header("Шкала опыта над текущим кораблём")]
        public Text rankText;
        public Text ratingText;
        public Slider ratingSlider;

        [Header("Пин для маленького сундука")]
        public GameObject smallLootboxPinGameObject;
        public Text smallLootboxPinText;

        [Header("Родитель для корабликов")]
        public Transform warshipsRoot;

        [Header("Канвас с меню поиска матча")] 
        public GameObject matchSearchCanvas;

        [HideInInspector] public UiSoundsManager lobbySoundsManager;
        // [HideInInspector] public Material blurMaterial;
        // [HideInInspector] public Material uiBlurDefaultMaterial;
        // [HideInInspector] public bool blurIsActive = true;
        private readonly ILog log = LogManager.CreateLogger(typeof(LobbyUiStorage));

        private void Awake()
        {
            lobbySoundsManager = UiSoundsManager.Instance();
            var buttons = FindObjectsOfType<Button>();
            foreach (var button in buttons) // Возможно, потом стоит заменить на что-то лучшее
            {
                button.onClick.AddListener(lobbySoundsManager.PlayClick);
            }

            // try
            // {
            //     blurMaterial = blurImage.material;
            // }
            // catch (Exception e)
            // {
            //     log.Fatal("Start method throw an exception " + e.Message);
            //     blurIsActive = false;
            // }

            // var qualityLevel = QualitySettings.GetQualityLevel();
            // if(qualityLevel < 2) blurIsActive = false;
            //
            // if (!blurIsActive)
            // {
            //     uiBlurDefaultMaterial = new Material(Shader.Find("UI/Default"));
            //     blurImage.material = uiBlurDefaultMaterial;
            // }
        }

        // private void OnDestroy()
        // {
        //     if(uiBlurDefaultMaterial) DestroyImmediate(uiBlurDefaultMaterial);
        // }

        public void Check()
        {
            Assert.IsNotNull(gameViewsRoot);
            Assert.IsNotNull(overlayCanvas);
            // Assert.IsNotNull(blurImage);
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
            Assert.IsNotNull(rankText);
            Assert.IsNotNull(ratingText);
            Assert.IsNotNull(ratingSlider);
            Assert.IsNotNull(smallLootboxPinGameObject);
            Assert.IsNotNull(smallLootboxPinText);
            Assert.IsNotNull(lobbySoundsManager);
        }
    }
}
