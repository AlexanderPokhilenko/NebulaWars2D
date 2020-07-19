using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LootboxScene.PrefabScripts
{
    /// <summary>
    /// Находится на префабе премиум-валюты. Управляет анимацией при появлении префаба.
    /// </summary>
    public class WarshipPowerPointsAccrual : MonoBehaviour
    {
        private bool start;
        // private int amount;
        // private GameObject headerGo;
        // private GameObject imageGo;
        // private GameObject amountGo;
        private string warshipPrefabName;

        public void SetData(string warshipPrefabNameArg)
        {
            warshipPrefabName = warshipPrefabNameArg;
            start = true;
        }
    
        private void Awake()
        {
            // headerGo = transform.Find("Canvas/Text_Header").gameObject;
            // imageGo = transform.Find("Canvas/Image").gameObject;
            // amountGo = transform.Find("Canvas/Text_Amount").gameObject;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        private void Start()
        {
            StartCoroutine(Animation());
        }

        private IEnumerator Animation()
        {
            yield return new WaitUntil(()=>start);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            StartCoroutine(WarshipAnimation(warshipPrefabName));
        }
    
        private IEnumerator WarshipAnimation(string warshipPrefabName)
        {
            //todo создать кораблик слева за сценой
            GameObject warshipPrefab = Resources.Load<GameObject>($"Prefabs/{warshipPrefabName}");
            GameObject warship = Instantiate(warshipPrefab);
            //todo плано переместить корабль на цент экрана
            //todo включить систему частиц
            yield break;
        }
    }
}
