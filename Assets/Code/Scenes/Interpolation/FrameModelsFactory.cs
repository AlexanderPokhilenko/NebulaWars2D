using System;
using System.Collections.Generic;
using Code.Common;
using UnityEngine;
using Random = System.Random;

namespace Code.Scenes.Interpolation
{
    public class FrameModelsFactory
    {
        public List<FrameModel> Create()
        {
            var frameModels = new List<FrameModel>();
            float x = -13;
            var random = new Random();
            for(int i = 1; x < 13; i++)
            {
                x += 1f+2*(float)random.NextDouble();
                DateTime frameTime = DateTime.UtcNow + TimeSpan.FromMilliseconds(100).Multiply(i*50);
                float y = 3 * Mathf.Sin(x);
                Vector2 position = new Vector2(x, y);
                FrameModel frameModel = new FrameModel
                {
                    position = position,
                    dateTime = frameTime
                };
                frameModels.Add(frameModel);
            }

            return frameModels;
        }
    }
}