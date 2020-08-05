using System;
using UnityEngine;
using Random = System.Random;

public class HalfToFloatTests : MonoBehaviour
{
    private void Start()
    {
        Random random = new Random();   
        for (float value = -50f; value < 50;)
        {
            value += (float) random.NextDouble();
            ushort u0 = Mathf.FloatToHalf(value);
            float f0r = Mathf.HalfToFloat(u0);
            float delta0 = Math.Abs(value - f0r);
            // Debug.LogError($"{nameof(delta0)} {delta0}");

            const float c = 1f/10;
            ushort u1 = Mathf.FloatToHalf(value*c);
            float f1r = Mathf.HalfToFloat(u1)/c;
            float delta1 = Math.Abs(value - f1r);
            // Debug.LogError($"{nameof(delta1)} {delta1}");
            if (delta1 > delta0)
            {
                Debug.LogError($"ухудшилось");
            }
            else if(delta0==delta1)
            {
                Debug.LogError($"совпадает");
            }
            else
            {
                Debug.LogError($"улучшилось");
            }
        }
    }
}
