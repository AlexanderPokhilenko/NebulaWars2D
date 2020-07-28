using System;
using System.Collections;
using Code.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Shop
{
    public class ShopTextHint : MonoBehaviour
    {
        private Text text;
        private RectTransform rectTransform;
        private Vector3 startPosition;
        private Vector3 shiftDelta;
        private float duration = 2f;
        private void Awake()
        {
            text = GetComponent<Text>();
            rectTransform = GetComponent<RectTransform>();
            startPosition = rectTransform.position;
            shiftDelta = new Vector3(0,-0.5f);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void Enable(string message)
        {
            UiSoundsManager.Instance().PlayError();
            text.text = message;
            gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(Disable());
            StartCoroutine(MoveUp());
        }

        private IEnumerator MoveUp()
        {
            rectTransform.position = startPosition;
            float finishTime = Time.time+duration;
            while (true)
            {
                float coef = (finishTime - Time.time)/duration;
                rectTransform.position = startPosition + coef*shiftDelta;
                yield return null;
            }
        }
        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(duration);
            gameObject.SetActive(false);
        }
    }
}