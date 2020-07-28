using System.Collections.Generic;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LootboxScene.Scripts
{
    public class ResourcesAccrualStorage
    {
        public bool IsLootboxNeeded { get; private set; }
        public List<ResourceModel> ResourceModels { get; private set; }
        public static ResourcesAccrualStorage Instance { get; } = new ResourcesAccrualStorage();

        public void Clear()
        {
            IsLootboxNeeded = false;
            ResourceModels = null;
        }

        public void SetNoLootboxNeeded()
        {
            IsLootboxNeeded = false;
        }
        
        public void SetLootboxNeeded()
        {
            IsLootboxNeeded = true;
        }
        
        public void SetResourcesModels(List<ResourceModel> resourceModels)
        {
            ResourceModels = resourceModels;
        }
    }
}