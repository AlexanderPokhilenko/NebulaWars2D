using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.WarshipsUi
{
    /// <summary>
    /// Хранит ссылки на ui элементы для списка кораблей.
    /// </summary>
    public class WarshipsUiStorage : MonoBehaviour
    {
        [Header("Корневые элементы для списка кораблей")]
        public GameObject warshipListRootGameObject;
        public GameObject warshipsListBackgroundGameObject;
        public GameObject warshipRootGameObject;
        
        [Header("Разные штуки для меню корабля")] 
        public Text warshipName;
        public Text warshipTypeName;
        public Text warshipDescription;
        public Text warshipPowerLevel;

        [Header("Рейтинг корабля")]
        public Text warshipRank;
        public Text trophyText;
        public Slider trophySlider;

        [Header("Сила корабля")] 
        public GameObject redScale;
        public Text powerValueText;
        public Slider powerSlider;
        
        public GameObject greenScale;
        public Text greenPowerPointsValueText;


        [Header("Кнопка для покупки улучшения")]
        public Button improveButton;
        public Text improveButtonCost;

        [Header("Кнопка выбора корабля")] 
        public Button chooseButton;

        [Header("Корневой объект для префаба корабля")]
        public GameObject warshipRoot;

        [Header("Всплывающее окно с улучшением")]
        public GameObject popupWindow;
        public Text popupWindowCostText;
        public Button popupWindowBuyButton;
        public Button popupWindowCloseButton;

        [Header("Подсказа о недостаче баллов прокачки корабля")]
        public GameObject hint;

        [Header("Окно с зарактеристиками корабля")]
        public Button warshipCharacteristicsButton;

        [Header("Модальное окно с характеристиками корабля")]
        public Text modalWindowHeaderText;
        public GameObject defenceHorizontalLayout;
        public GameObject attackGridLayout;
        public GameObject ultimateGridLayout;
        public GameObject modalWindowImproveButton;
        public Text attackDescription;
        public Text attackName;
        public Text ultimateDescription;
        public Text ultimateName;

        [Header("Кнопки для переключения скинов")]
        public GameObject leftSkinButton;
        public GameObject rightSkinButton;
        
        public void Check()
        {
            Assert.IsNotNull(warshipListRootGameObject);
            Assert.IsNotNull(warshipsListBackgroundGameObject);
            Assert.IsNotNull(warshipRootGameObject);
            Assert.IsNotNull(warshipName);
            Assert.IsNotNull(warshipTypeName);
            Assert.IsNotNull(warshipDescription);
            Assert.IsNotNull(warshipPowerLevel);
            Assert.IsNotNull(warshipRank);
            Assert.IsNotNull(trophyText);
            Assert.IsNotNull(trophySlider);
            Assert.IsNotNull(powerValueText);
            Assert.IsNotNull(powerSlider);
            Assert.IsNotNull(improveButton);
            Assert.IsNotNull(improveButtonCost);
            Assert.IsNotNull(chooseButton);
            Assert.IsNotNull(warshipRoot);
            Assert.IsNotNull(popupWindow);
            Assert.IsNotNull(popupWindowCostText);
            Assert.IsNotNull(popupWindowBuyButton);
            Assert.IsNotNull(popupWindowCloseButton);
        }
    }
}