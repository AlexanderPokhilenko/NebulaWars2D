using System.Collections.Generic;
using Code.Scenes.LobbyScene.Scripts.Shop;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.Shop.PurchaseConfirmationWindow
{
    public class PurchaseConfirmationWindowDisablingSystem:ReactiveSystem<LobbyUiEntity>
    {
        private readonly ShopUiStorage shopUiStorage;

        public PurchaseConfirmationWindowDisablingSystem(IContext<LobbyUiEntity> context, ShopUiStorage shopUiStorage) 
            : base(context)
        {
            this.shopUiStorage = shopUiStorage;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.DisablePurchaseConfirmationWindow);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.isDisablePurchaseConfirmationWindow;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            HideWindow();
        }
        
        private void HideWindow()
        {
            shopUiStorage.purchaseConfirmationWindowRoot.SetActive(false);
        }

    }
}