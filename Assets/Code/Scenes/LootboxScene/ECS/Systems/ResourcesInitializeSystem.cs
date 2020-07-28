    using Code.Common;
using Code.Scenes.LootboxScene.Scripts;
using Entitas;

namespace Code.Scenes.LootboxScene.ECS.Systems
{
    public class ResourcesInitializeSystem : IInitializeSystem
    {
        private readonly LootboxUiStorage lootboxUiStorage;

        public ResourcesInitializeSystem(LootboxUiStorage lootboxUiStorage)
        {
            this.lootboxUiStorage = lootboxUiStorage;
        }
        
        public void Initialize()
        {
            lootboxUiStorage.resourcesRoot.transform.DestroyAllChildren();
        }
    }
}