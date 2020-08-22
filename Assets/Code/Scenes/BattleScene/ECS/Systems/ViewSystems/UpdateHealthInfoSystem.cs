using System.Collections.Generic;
using Code.Scenes.BattleScene.Experimental;
using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class UpdateHealthInfoSystem : ReactiveSystem<GameEntity>
    {
        private readonly HealthInfoObject prototype;

        public UpdateHealthInfoSystem(Contexts contexts, HealthInfoObject healthInfoPrototype) : base(contexts.game)
        {
            prototype = healthInfoPrototype;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            var matcher = GameMatcher.AllOf(GameMatcher.Health, GameMatcher.View);
            return context.CreateCollector(matcher);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.hasHealth && !entity.isCurrentShield;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                HealthInfoObject infoObject;
                if (e.hasHealthInfo)
                {
                    infoObject = e.healthInfo.value;
                }
                else
                {
                    var go = e.view.gameObject;
                    infoObject = Object.Instantiate(prototype, go.transform);
                    e.AddHealthInfo(infoObject);
                    if (e.isShield) infoObject.SetShieldStyle();
                    if (!e.hasPlayer && !e.isShield) infoObject.SetTransparency(0f);
                    if (e.hasHealthBarFading) e.RemoveHealthBarFading();
                }
                infoObject.SetMaxHealthPoints(e.health.maximum);
                infoObject.SetHealthPoints(e.health.current);
            }
        }
    }
}