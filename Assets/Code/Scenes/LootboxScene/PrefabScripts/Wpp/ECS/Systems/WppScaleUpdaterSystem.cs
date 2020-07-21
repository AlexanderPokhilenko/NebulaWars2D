using System.Collections.Generic;
using System.Linq;
using Code.Common.Logger;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LootboxScene.PrefabScripts.Wpp.ECS.Systems
{
    public class WppScaleUpdaterSystem : ReactiveSystem<WppAccrualEntity>
    {
        private readonly Text text;
        private readonly GameObject redScale;
        private readonly GameObject greenScale;
        private readonly ILog log = LogManager.CreateLogger(typeof(WppScaleUpdaterSystem));

        public WppScaleUpdaterSystem(IContext<WppAccrualEntity> context, Text text, GameObject redScale,
            GameObject greenScale) : base(context)
        {
            this.text = text;
            this.redScale = redScale;
            this.greenScale = greenScale;
        }

        protected override ICollector<WppAccrualEntity> GetTrigger(IContext<WppAccrualEntity> context)
        {
            return context.CreateCollector(WppAccrualMatcher.WarshipPowerPoints);
        }

        protected override bool Filter(WppAccrualEntity entity)
        {
            return entity.hasWarshipPowerPoints;
        }

        protected override void Execute(List<WppAccrualEntity> entities)
        {
            WarshipPowerPointsComponent actual = entities.Last().warshipPowerPoints;
            log.Debug("Обновление шкалы. Новое значение "+actual.value);

            if (actual.value < actual.maxValueForLevel)
            {
                text.text = $"{actual.value}/{actual.maxValueForLevel}";
            }
            else
            {
                redScale.SetActive(false);
                greenScale.SetActive(true);
            }
        }
    }
}