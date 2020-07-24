using System.Collections;
using System.Collections.Generic;
using Code.Common.Logger;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Shop
{
    /// <summary>
    /// Передвигает меню по указанным координатам. Нужно после нажатия на кнопки снизу.
    /// </summary>
    public class ScrollViewSmoothMovementBehaviour : MonoBehaviour
    {
        private float screenWidth;
        private ScrollRect scrollRect;
        private RectTransform scrollViewContent;
        private Dictionary<string, float> sectionStartPosition;
        private readonly ILog log = LogManager.CreateLogger(typeof(ScrollViewSmoothMovementBehaviour));

        private void Awake()
        {
            ShopUiStorage shopUiStorage = FindObjectOfType<ShopUiStorage>();
            scrollViewContent = shopUiStorage.shopScrollViewContent;
            screenWidth = shopUiStorage.canvasCameraSpace.rect.width;
            scrollRect = shopUiStorage.scrollRect;
        }

        public void SetSectionPositions(Dictionary<string, float> sectionStartPositionArg)
        {
            sectionStartPosition = sectionStartPositionArg;
        }

        public void StartMovement(string sectionName)
        {
            if (sectionStartPosition != null)
            {
                if (sectionStartPosition.TryGetValue(sectionName, out float xPosition))
                {
                    StopAllCoroutines();
                    StartCoroutine(Move(xPosition));
                }
                else
                {
                    log.Error($"Не найдена координата раздела с именем {sectionName}");
                }
            }
            else
            {
                log.Error("Позиции разделов не инициализированы.");
            }
        }

        private IEnumerator Move(float xTargetPosition)
        {
            scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
            if (xTargetPosition + screenWidth > scrollViewContent.rect.width)
            {
                xTargetPosition = scrollViewContent.rect.width - screenWidth;
            }

            const float stepSizeAbs = 50;
            float pathLength;
            do
            {
                float currentPosition = GetCurrentPosition();
                pathLength = Mathf.Abs(xTargetPosition - currentPosition);
                float currentStepSize = Mathf.Min(pathLength, stepSizeAbs);
                if (xTargetPosition < currentPosition)
                {
                    currentStepSize *= -1;
                }
                
                float xPosition = currentPosition + currentStepSize;
                var anchoredPosition = scrollViewContent.anchoredPosition;
                var newPosition = new Vector2(-xPosition, anchoredPosition.y);
                scrollViewContent.anchoredPosition = newPosition;
                yield return null;
            } 
            while (pathLength > 0.001);
            
            scrollRect.movementType = ScrollRect.MovementType.Elastic;
        }

        private float GetCurrentPosition()
        {
            return -scrollViewContent.anchoredPosition.x;
        }
    }
}