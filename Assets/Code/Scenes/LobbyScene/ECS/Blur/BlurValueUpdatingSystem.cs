using System;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Blur
{
    /// <summary>
    /// Меняет значение размытия в зависимости от нажатых кнопок "Старт" "Отмена"
    /// </summary>
    public class BlurValueUpdatingSystem:IExecuteSystem
    {
        private const byte MaxBlurValue = 10;
        private readonly Material blurMaterial;
        private readonly LobbyUiContext context;
        private static readonly int Size = Shader.PropertyToID("_Size");
        
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

        private void UpdateBlurValue()
        {
            if (context.isStartButtonClicked)
            {
                if (context.blurValue.blurValue < MaxBlurValue)
                {
                    context.blurValue.blurValue++;
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
                    context.blurValue.blurValue-=3;
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
            blurMaterial.SetFloat(Size, context.blurValue.blurValue);
        }
    }
}