    using Code.Common.Logger;
    using Entitas;
    using UnityEngine;

    namespace Code.Scenes.LootboxScene.PrefabScripts.Wpp.ECS.Systems
    {
        /// <summary>
        /// Меняет позиции GO движущихся наград.
        /// </summary>
        public class IconsUpdaterSystem:IExecuteSystem
        {
            private readonly RectTransform upperObject;
            private readonly IGroup<WppAccrualEntity> movingAwardsGroup;
            private readonly ILog log = LogManager.CreateLogger(typeof(IconsUpdaterSystem));

            public IconsUpdaterSystem(Contexts contexts, RectTransform upperObject)
            {
                this.upperObject = upperObject;
                var context = contexts.wppAccrual;
                movingAwardsGroup = context.GetGroup(WppAccrualMatcher
                    .AllOf(WppAccrualMatcher.MovingIcon, WppAccrualMatcher.View, WppAccrualMatcher.Position));
            }
            
            public void Execute()
            {
                foreach (var entity in movingAwardsGroup)
                {
                    entity.view.gameObject.transform.position = entity.position.value;
                    entity.view.gameObject.transform.localScale = entity.scale.scale;
                    var oldColor =  entity.image.image.color; 
                    entity.image.image.color = new Color(oldColor.r, oldColor.g, oldColor.b, entity.alpha.alpha);

                    // if (entity.movingIcon.IsRaiseUpNeeded())
                    // {
                    //     entity.view.gameObject.transform.SetParent(upperObject, false);
                    //     entity.movingAward.TurnOffRaiseUp();
                    // }
                }
            }
        }
    }