using System;
using System.Collections;
using Code.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Shop
{
    public class ShopTextHint : MonoBehaviour
    {
        [SerializeField] private GameObject hingGo;
        private Text text;
        private RectTransform rectTransform;
        private Vector3 startPosition;
        private Vector3 shiftDelta;
        private float duration = 2f;
        private void Awake()
        {
            text = hingGo.GetComponent<Text>();
            rectTransform = hingGo.GetComponent<RectTransform>();
            startPosition = rectTransform.position;
            shiftDelta = new Vector3(0,-0.5f);
        }

        private void Start()
        {
            hingGo.SetActive(false);
        }

        public void Enable(string message)
        {
            UiSoundsManager.Instance().PlayError();
            text.text = message;
            hingGo.SetActive(true);
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
                if (coef < 0)
                {
                    break;
                }
                rectTransform.position = startPosition + coef*shiftDelta;
                yield return null;
            }
        }
        
        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(duration);
            hingGo.SetActive(false);
        }
    }
}