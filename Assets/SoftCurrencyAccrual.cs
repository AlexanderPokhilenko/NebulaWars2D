using System;
using System.Collections;
using UnityEngine;

public class SoftCurrencyAccrual : MonoBehaviour
{
    private RectTransform headerRectTransform;
    private RectTransform imageRectTransform;
    private RectTransform amountTextRectTransform;
    private bool start;
    private int amount;
    
    public void SetData(int amountArg)
    {
        amount = amountArg;
        start = true;
    }
    
    private void Awake()
    {
        headerRectTransform = transform.Find("Canvas/Text_CoinsHeader").GetComponent<RectTransform>()
                            ?? throw new NullReferenceException("Text_CoinsHeader");
        imageRectTransform = transform.Find("Canvas/Image_SoftCurrency").GetComponent<RectTransform>()
                            ?? throw new NullReferenceException("Image_SoftCurrency");
        amountTextRectTransform = transform.Find("Canvas/Text_CoinsAmount").GetComponent<RectTransform>()
                            ?? throw new NullReferenceException("Text_CoinsAmount");
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
        StartCoroutine(HeaderAnimation());
        StartCoroutine(ImageAnimation());
        StartCoroutine(AmountAnimation());
    }
    
    private IEnumerator HeaderAnimation()
    {
        while (headerRectTransform.localScale.x<1.5)
        {
            var tmp = headerRectTransform.localScale;
            headerRectTransform.localScale = new Vector3(tmp.x+0.01f, tmp.y);
            yield return null;    
        }
    }
    
    private IEnumerator ImageAnimation()
    {
        imageRectTransform.localScale = new Vector3(0.3f,1);
        yield return null;
    }
    
    private IEnumerator AmountAnimation()
    {
        amountTextRectTransform.localScale = new Vector3(0.3f,1);
        yield return null;
    }
}
