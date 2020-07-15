using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Blur
{
    /// <summary>
    /// Выключает картинку с размытием когда удаляется компонент.
    /// </summary>
    public class BlurImageDisableHandler:ReactiveSystem<LobbyUiEntity>
    {
        private readonly GameObject blurImageGameObject;
        
        public BlurImageDisableHandler(IContext<LobbyUiEntity> context, GameObject blurGameObject) : base(context)
        {
            if (blurGameObject == null)
            {
                throw new Exception($"{nameof(blurGameObject)} was null");
            }
            blurImageGameObject = blurGameObject;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.BlurImageEnabled.Removed());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return !entity.isBlurImageEnabled;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            blurImageGameObject.SetActive(false);
        }
    }
}