using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.AccountData.AccountDataChangingHandlers
{
    /// <summary>
    /// Устанавливает значение кол-ва очков для маленького сундука.
    /// </summary>
    public class LootboxSliderChangingHandler:ReactiveSystem<LobbyUiEntity>
    {
        private readonly Slider slider;
        public LootboxSliderChangingHandler(IContext<LobbyUiEntity> context,  Slider slider) 
            : base(context)
        {
            this.slider = slider;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.PointsForSmallLootbox.Added());
        }
    
        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasPointsForSmallLootbox;
        }
    
        protected override void Execute(List<LobbyUiEntity> entities)
        {
            LobbyUiEntity entity = entities.Last();
            int value = entity.pointsForSmallLootbox.value;
            slider.value = value%100 / 100f;
        }
    }
}