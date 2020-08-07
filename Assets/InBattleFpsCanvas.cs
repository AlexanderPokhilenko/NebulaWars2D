using UnityEngine;

public class InBattleFpsCanvas : MonoBehaviour
{
    public void Awake()
    {
        gameObject.SetActive(FrameRateCounter.ShowFpsCanvas);
    }
}