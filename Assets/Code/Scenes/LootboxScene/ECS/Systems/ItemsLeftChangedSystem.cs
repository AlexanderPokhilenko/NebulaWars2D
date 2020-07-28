using System.Collections.Generic;
using System.Linq;
using Code.Scenes.LootboxScene.Scripts;
using Entitas;

namespace Code.Scenes.LootboxScene.ECS.Systems
{
    /// <summary>
    /// Включает текст "Осталось предметов" и обновляет его.
    /// </summary>
    public class ItemsLeftChangedSystem:ReactiveSystem<LootboxEntity>
    {
        private readonly LootboxUiStorage uiStorage;
        
        public ItemsLeftChangedSystem(Contexts contexts, LootboxUiStorage uiStorage) 
            : base(contexts.lootbox)
        {
            this.uiStorage = uiStorage;
        }
        
        protected override ICollector<LootboxEntity> GetTrigger(IContext<LootboxEntity> context)
        {
            return context.CreateCollector(LootboxMatcher.ItemsLeft);
        }

        protected override bool Filter(LootboxEntity entity)
        {
            return entity.hasItemsLeft;
        }

        protected override void Execute(List<LootboxEntity> entities)
        {
            int value = entities.Last().itemsLeft.value;
            uiStorage.itemsLeftText.text = "ITEMS LEFT: "+value;
        }
    }
}