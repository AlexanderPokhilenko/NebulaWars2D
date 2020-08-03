using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LootboxScene.PrefabScripts
{
    /// <summary>
    /// Находится на префабе премиум-валюты. Управляет анимацией при появлении префаба.
    /// </summary>
    public class HardCurrencyAccrual : MonoBehaviour
    {
        private int amount;
        private bool start;
        private GameObject headerGo;
        private GameObject imageGo;
        private GameObject amountGo;
    
        public void SetData(int amountArg)
        {
            amount = amountArg;
            start = true;
        }
    
        private void Awake()
        {
            imageGo = transform.Find("Canvas/Image").gameObject;
            headerGo = transform.Find("Canvas/Text_Header").gameObject;
            amountGo = transform.Find("Canvas/Text_Amount").gameObject;
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

            Text amountText = amountGo.GetComponent<Text>();
            amountText.text = $"x{amount}";
        }
    }
}
