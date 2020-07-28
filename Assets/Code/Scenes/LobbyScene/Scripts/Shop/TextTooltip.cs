using System.Collections;
using Code.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.Shop
{
    public class TextTooltip : MonoBehaviour
    {
        private Text text;
        private Vector3 shiftDelta;
        private float duration = 2f;
        private Vector3 startPosition;
        private RectTransform rectTransform;
        [SerializeField] private GameObject hingGo;
        
        private void Awake()
        {
            text = hingGo.GetComponent<Text>();
            rectTransform = hingGo.GetComponent<RectTransform>();
            startPosition = rectTransform.position;
            shiftDelta = new Vector3(0,-50);
        }

        private void Start()
        {
            hingGo.SetActive(false);
        }

        public void Show(string message)
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
                float coefficient = (finishTime - Time.time)/duration;
                if (coefficient < 0)
                {
                    break;
                }
                
                rectTransform.position = startPosition + coefficient*shiftDelta;
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