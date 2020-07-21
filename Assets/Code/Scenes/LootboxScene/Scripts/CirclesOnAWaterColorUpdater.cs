using System;
using Code.Common.Logger;
using UnityEngine;

namespace Code.Scenes.LootboxScene.Scripts
{
    public class CirclesOnAWaterColorUpdater : MonoBehaviour
    {
        [SerializeField] private ParticleSystem circlesOnAWater;
        private readonly ILog log = LogManager.CreateLogger(typeof(CirclesOnAWaterColorUpdater));
        
        private void Awake()
        {
            if (circlesOnAWater == null)
            {
                throw new NullReferenceException(nameof(circlesOnAWater));
            }
        }

        public void SetStartColor(Color color)
        {
            ParticleSystem.MainModule mainModule = circlesOnAWater.main;
            mainModule.startColor = color;
        }
    }
}