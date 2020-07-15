using System;
using System.Collections.Generic;
using Code.Common;
using Code.Scenes.LobbyScene.Scripts;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.Components.CommonLayoutSwitcher
{
    /// <summary>
    /// Хранит текущее состояние. Оно представлено перечислением ShittyUiLayerState.
    /// Реагирут на нажатие кнопки Back.
    /// </summary>
    public class LobbyLayoutSwitcher:ReactiveSystem<LobbyUiEntity>
    {
        private ShittyUiLayerState currentLayer;
        private readonly IContext<LobbyUiEntity> context;
        private readonly PurchaseConfirmationWindow purchaseConfirmationWindow;
        private readonly ILog log = LogManager.CreateLogger(typeof(LobbyLayoutSwitcher));
        
        public LobbyLayoutSwitcher(IContext<LobbyUiEntity> context, 
            PurchaseConfirmationWindow purchaseConfirmationWindow) : base(context)
        {
            this.context = context;
            this.purchaseConfirmationWindow = purchaseConfirmationWindow;
            currentLayer = ShittyUiLayerState.DefaultLayer;
        }
        
        public void SetCurrentLayer(ShittyUiLayerState shittyUiLayerState)
        {
            // log.Debug("Установка нового слоя "+shittyUiLayerState);
            currentLayer = shittyUiLayerState;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> contextArg)
        {
            return contextArg.CreateCollector(LobbyUiMatcher.BackButtonPressed);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.messageBackButtonPressed;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            switch (currentLayer)
            {
                case ShittyUiLayerState.DefaultLayer:
                    log.Debug("Недопустимое нажатие на кнопку назад. Текущий слой "+currentLayer);
                    break;
                case ShittyUiLayerState.ShopLayer:
                    context.CreateEntity().messageDisableShopUiLayer = true;
                    break;
                case ShittyUiLayerState.ShopPurchaseConfirmationLayer:
                    //todo это кусок говна
                    purchaseConfirmationWindow.HideWindow();
                    SetCurrentLayer(ShittyUiLayerState.ShopLayer);
                    break;
                case ShittyUiLayerState.WarshipsList:
                    context.CreateEntity().messageDisableWarshipListUiLayer = true;
                    break;
                case ShittyUiLayerState.WarshipOverview:
                    context.CreateEntity().messageDisableWarshipOverviewUiLayer = true;
                    break;
                case ShittyUiLayerState.WarshipOverviewModalWindow:
                    context.CreateEntity().messageDisableWarshipOverviewModalWindow = true;
                    break;
                case ShittyUiLayerState.WarshipImprovementModalWindow:
                    context.CreateEntity().messageDisableWarshipImprovementModalWindow = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentLayer));
            }
        }
    }

    public enum ShittyUiLayerState
    {
        DefaultLayer,
        ShopLayer,
        ShopPurchaseConfirmationLayer,
        WarshipsList,
        WarshipOverview,
        WarshipOverviewModalWindow,
        WarshipImprovementModalWindow
    }
}