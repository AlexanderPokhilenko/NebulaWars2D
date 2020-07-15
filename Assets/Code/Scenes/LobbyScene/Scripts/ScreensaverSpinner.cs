using System;
using System.Collections;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class ScreensaverSpinner : MonoBehaviour
    {
        [SerializeField] private RectTransform spinnerImage;
        private const int BarCount = 11;
    
        private void Start()
        {
            if (spinnerImage == null)
            {
                throw new Exception("Не установлена картинка");
            }
            StartCoroutine(Rotate());
        }

        private IEnumerator Rotate()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f/BarCount);
                spinnerImage.Rotate(Vector3.forward, -360f/BarCount);    
            }
        }
    }
}
