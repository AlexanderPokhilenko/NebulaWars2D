using System;
using System.Collections.Generic;
using Code.Scenes.LobbyScene.ECS;
using Entitas;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Code.Scenes.LootboxScene.PrefabScripts.Wpp.ECS.Systems
{
    public class WppImagesInstantiatorSystem:ReactiveSystem<WppAccrualEntity>
    {
        private readonly RectTransform parent;
        private readonly GameObject wppIconPrefab;

        public WppImagesInstantiatorSystem(Contexts contexts, RectTransform parent, GameObject wppIconPrefab) 
            : base(contexts.wppAccrual)
        {
            this.parent = parent;
            this.wppIconPrefab = wppIconPrefab;
        }

        protected override ICollector<WppAccrualEntity> GetTrigger(IContext<WppAccrualEntity> context)
        {
            return context.CreateCollector(WppAccrualMatcher.AllOf(WppAccrualMatcher.MovingIcon)
                .NoneOf(WppAccrualMatcher.View, WppAccrualMatcher.Image));
        }

        protected override bool Filter(WppAccrualEntity entity)
        {
            return entity.hasMovingIcon && !entity.hasView && !entity.hasImage;
        }

         protected override void Execute(List<WppAccrualEntity> entities)
        {
            int index = 0;
            foreach (var entity in entities)
            {
                GameObject awardGo = Object.Instantiate(wppIconPrefab, parent,false);
                awardGo.name += (index++).ToString();
                entity.AddView(awardGo);
                entity.AddImage(awardGo.GetComponent<Image>());    
            }
        }
    }
}