using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Blur
{
    /// <summary>
    /// Включает картинку с размытием при создании компонета.
    /// </summary>
    public class BlurImageEnableHandler:ReactiveSystem<LobbyUiEntity>
    {
        private readonly GameObject blurImageGameObject;
        
        public BlurImageEnableHandler(IContext<LobbyUiEntity> context, GameObject blurGameObject) : base(context)
        {
            if (blurGameObject == null)
            {
                throw new Exception($"{nameof(blurGameObject)} was null");
            }
            blurImageGameObject = blurGameObject;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.BlurImageEnabled.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.isBlurImageEnabled;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            blurImageGameObject.SetActive(true);
        }
    }
}