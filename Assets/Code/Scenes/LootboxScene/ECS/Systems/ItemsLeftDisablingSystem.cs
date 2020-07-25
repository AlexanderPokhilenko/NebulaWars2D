using System.Collections.Generic;
using Code.Scenes.LootboxScene.Scripts;
using Entitas;

namespace Code.Scenes.LootboxScene.ECS.Systems
{
    public class ItemsLeftDisablingSystem:ReactiveSystem<LootboxEntity>
    {
        private readonly LootboxUiStorage uiStorage;
        
        public ItemsLeftDisablingSystem(Contexts contexts, LootboxUiStorage uiStorage) 
            : base(contexts.lootbox)
        {
            this.uiStorage = uiStorage;
        }
        
        protected override ICollector<LootboxEntity> GetTrigger(IContext<LootboxEntity> context)
        {
            return context.CreateCollector(LootboxMatcher.DisableItemsLeftMenu);
        }

        protected override bool Filter(LootboxEntity entity)
        {
            return entity.isDisableItemsLeftMenu;
        }

        protected override void Execute(List<LootboxEntity> entities)
        {
            uiStorage.itemsLeftRoot.SetActive(false);
        }
    }
}