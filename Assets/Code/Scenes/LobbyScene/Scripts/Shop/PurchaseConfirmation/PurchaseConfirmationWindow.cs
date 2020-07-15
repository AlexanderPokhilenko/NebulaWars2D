using Code.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Показывает и скрывает окно подтверждения покупки.
    /// </summary>
    public class PurchaseConfirmationWindow:MonoBehaviour
    {
        private ShopUiStorage shopUiStorage;
        
        private void Awake()
        {
            shopUiStorage = FindObjectOfType<ShopUiStorage>();
            shopUiStorage.purchaseConfirmationWindowRoot.SetActive(false);
            
            //слушатель на кнопку с крестиком
            Button backgroundButton = shopUiStorage.purchaseConfirmationWindowRoot.transform
                .Find("Image_Menu/Button_Close")
                .GetComponent<Button>();
            backgroundButton.onClick.RemoveAllListeners();
            backgroundButton.onClick.AddListener(HideWindow);
            
            //слушатель на чёрный фон
            Button closeButton = shopUiStorage.purchaseConfirmationWindowRoot.transform
                .Find("Image_PurchaseConfirmationWindow")
                .GetComponent<Button>();
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(HideWindow);
        }

        public void HideWindow()
        {
            shopUiStorage.purchaseConfirmationWindowRoot.SetActive(false);
        }

        public void ShowWindow()
        {
            shopUiStorage.purchaseConfirmationWindowRoot.SetActive(true);
        }

        public void ClearWindow()
        {
            shopUiStorage.purchaseConfirmationWindowContent.transform.DestroyAllChildren();
        }
    }
}