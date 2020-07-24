using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation
{
    public class InsufficientResourceErrorHandler : MonoBehaviour
    {
        private ScrollViewSmoothMovementBehaviour scrollViewSmoothMovementBehaviour;
        private readonly ILog log = LogManager.CreateLogger(typeof(InsufficientResourceErrorHandler));
        
        private void Awake()
        {
            scrollViewSmoothMovementBehaviour = FindObjectOfType<ScrollViewSmoothMovementBehaviour>();
        }

        public void ShowError(InsufficientResourceEnum insufficientResourceEnum)
        {
            log.Error("Показыть ошибку");
            //скрыть меню подтверждения покупки
            //начать перелистывать на раздел с валютой
            //показать всплывающий текст ошибки
            //звук ошибки
        }
    }
}