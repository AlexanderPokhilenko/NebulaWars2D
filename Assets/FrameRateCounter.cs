using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Code.Common;
using UnityEngine;
using UnityEngine.UI;

public class FrameRateCounter : Singleton<FrameRateCounter>
{
    private Text text;
    protected override bool DontDestroy { get; } = true;

    protected override void Awake()
    {
        base.Awake();
        text = GetComponentInChildren<Text>();
        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.25f);
            int a = (int) (1f / Time.unscaledDeltaTime);
            text.text = a.ToString()+" fps";    
        }
    }
}
