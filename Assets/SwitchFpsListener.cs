using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SwitchFpsListener : MonoBehaviour
{
    public Text buttonText;

    public void Awake()
    {
        if(buttonText == null) buttonText = GetComponentInChildren<Text>();
        var frameController = FrameRateCounter.Instance();
        frameController.currentListener = this;
        GetComponent<Button>().onClick.AddListener(frameController.SwitchFps);
        frameController.UpdateText();
    }
}