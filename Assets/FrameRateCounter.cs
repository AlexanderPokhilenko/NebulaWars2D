using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Code.Common;
using UnityEngine;
using UnityEngine.UI;

public class FrameRateCounter : Singleton<FrameRateCounter>
{
    private Text text1;
    private Text text2;
    protected override bool DontDestroy { get; } = true;
    private int prevSec;
    private int fps;
    protected override void Awake()
    {
        base.Awake();
        var texts = GetComponentsInChildren<Text>();
        text1 = texts[0];
        text2 = texts[1];
        StartCoroutine(Coroutine());
    }

    private void Update()
    {
        fps++;
        
        int sec = DateTime.UtcNow.Second;
        if (sec != prevSec)
        {
            text1.text = $"{fps} fps";
            fps = 0;
            prevSec = sec;
        }
    }

    private IEnumerator Coroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.25f);
            int a = (int) (1f / Time.unscaledDeltaTime);
            text2.text = a+" fps";    
        }
    }
}
