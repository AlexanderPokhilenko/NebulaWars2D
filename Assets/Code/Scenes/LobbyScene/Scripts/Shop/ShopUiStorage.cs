using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Хранит ссылки на префабы для меню в магазине
    /// </summary>
    public class ShopUiStorage : MonoBehaviour
    {
        /// <summary>
        /// Префаб для раздела.
        /// </summary>
        public GameObject shopFlexibleSectionPrefab;
        /// <summary>
        /// Родитель прозрачного фона.
        /// </summary>
        public RectTransform shopScrollViewContent;
        /// <summary>
        /// Прозрачный фон к которому крепятся все разделы.
        /// </summary>
        public GameObject shopSectionsParent;
        /// <summary>
        /// Родитель окна подтверждения покупки.
        /// </summary>
        public GameObject purchaseConfirmationWindowRoot;
        /// <summary>
        /// Родительский объект для содержимого окна подтверждения покупки.
        /// </summary>
        public GameObject purchaseConfirmationWindowContent;
        /// <summary>
        /// Нужно для того, чтобы значть ширину экрана
        /// </summary>
        public RectTransform canvasCameraSpace;

        public ScrollRect scrollRect;
    }
}