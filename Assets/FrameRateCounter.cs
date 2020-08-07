using System;
using System.Collections;
using Code.Common;
using UnityEngine;
using UnityEngine.UI;

public class FrameRateCounter : Singleton<FrameRateCounter>
{
    public static bool ShowFpsCanvas { get; private set; }
    public SwitchFpsListener currentListener;
    private Text text1;
    private Text text2;
    protected override bool DontDestroy { get; } = true;
    private IEnumerator coroutine;
    private int prevSec;
    private int fps;
    
    protected override void Awake()
    {
        base.Awake();

        ShowFpsCanvas = PlayerPrefs.HasKey(nameof(ShowFpsCanvas));
        var texts = GetComponentsInChildren<Text>();
        text1 = texts[0];
        text2 = texts[1];

        UpdateCanvas();
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

    public void SwitchFps()
    {
        ShowFpsCanvas = !ShowFpsCanvas;

        UpdateCanvas();
        UpdateText();
    }

    private void UpdateCanvas()
    {
        gameObject.SetActive(ShowFpsCanvas);
        if (ShowFpsCanvas)
        {
            coroutine = Coroutine();
            StartCoroutine(coroutine);
        }
        else
        {
            if (coroutine != null) StopCoroutine(coroutine);
        }
    }

    public void UpdateText()
    {
        currentListener.buttonText.text = ShowFpsCanvas ? "Hide FPS" : "Show FPS";
    }

    private void OnDestroy()
    {
        if (ShowFpsCanvas)
        {
            PlayerPrefs.SetInt(nameof(ShowFpsCanvas), 1);
        }
        else
        {
            PlayerPrefs.DeleteKey(nameof(ShowFpsCanvas));
        }

        PlayerPrefs.Save();
    }
}
