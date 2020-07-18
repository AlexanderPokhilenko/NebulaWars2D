using System;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Blur
{
    /// <summary>
    /// Меняет значение размытия в зависимости от нажатых кнопок "Старт" "Отмена"
    /// </summary>
    public class BlurValueUpdatingSystem:IExecuteSystem, ITearDownSystem
    {
        private const float MaxBlurValue = 0.01f;
        private const float BlurValueIncrement = MaxBlurValue * 0.05f;
        private const float BlurValueDecrement = BlurValueIncrement * 3;
        private const float BlurToAlphaCoefficient = 1f / MaxBlurValue;
        private readonly Material blurMaterial;
        private readonly LobbyUiContext context;
        private static readonly int BlurValueId = Shader.PropertyToID("_BlurValue");
        private static readonly int AlphaId = Shader.PropertyToID("_Alpha");

        public BlurValueUpdatingSystem(LobbyUiContext context, Material blurMaterial)
        {
            this.context = context;
            if (blurMaterial == null)
            {
                throw new Exception($"{nameof(blurMaterial)} was null");
            }
            this.blurMaterial = blurMaterial;
        }
        public void Execute()
        {
            UpdateBlurValue();
            SetBlurValue();
        }

        public void TearDown()
        {
            context.blurValue.blurValue = 0f;
            SetBlurValue();
        }

        private void UpdateBlurValue()
        {
            if (context.isStartButtonClicked)
            {
                if (context.blurValue.blurValue < MaxBlurValue)
                {
                    context.blurValue.blurValue += BlurValueIncrement;
                }
                else
                {
                    context.isStartButtonClicked = false;
                }
            }
            else if (context.isCancelButtonClicked)
            {
                if (context.blurValue.blurValue > 0)
                {
                    context.blurValue.blurValue -= BlurValueDecrement;
                    if (context.blurValue.blurValue < 0)
                    {
                        context.blurValue.blurValue = 0;
                    }
                }
                else
                {
                    context.isCancelButtonClicked = false;
                }
            }
        }
        
        private void SetBlurValue()
        {
            blurMaterial.SetFloat(BlurValueId, context.blurValue.blurValue);
            blurMaterial.SetFloat(AlphaId, context.blurValue.blurValue * BlurToAlphaCoefficient);
        }
    }
}