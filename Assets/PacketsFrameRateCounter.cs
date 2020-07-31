using System.Collections;
using System.Collections.Generic;
using Code.Common.NetworkStatistics;
using UnityEngine;
using UnityEngine.UI;

public class PacketsFrameRateCounter : MonoBehaviour
{
    private Text text;
    
    private void Awake()
    {
        text = GetComponent<Text>();
    }
    
    private void Update()
    {
        text.text = NetworkStatisticsStorage.Instance.GetLastFramerate().ToString();
    }
}
