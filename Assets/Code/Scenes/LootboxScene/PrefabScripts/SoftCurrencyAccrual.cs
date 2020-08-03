using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LootboxScene.PrefabScripts
{
    /// <summary>
    /// Находится на префабе обычной валюты. Управляет анимацией при появлении префаба.
    /// </summary>
    public class SoftCurrencyAccrual : MonoBehaviour
    {
        private GameObject headerGo;
        private GameObject imageGo;
        private GameObject amountGo;
    
        public void StartAnimation(int amount)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            Text amountText = amountGo.GetComponent<Text>();
            amountText.text = $"x{amount}";
        }
    
        private void Awake()
        {
            headerGo = transform.Find("Canvas/Text_Header").gameObject;
            imageGo = transform.Find("Canvas/Image").gameObject;
            amountGo = transform.Find("Canvas/Text_Amount").gameObject;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
