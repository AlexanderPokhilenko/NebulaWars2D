using System;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LootboxScene.Scripts;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using System.Collections.Generic;
using EpicLootBoxEffects.Scripts;

namespace Code.Scenes.LootboxScene.ECS.Systems
{
    /// <summary>
    /// Реагирует на нажатие на канвас.
    /// </summary>
    public class ClickHandlerSystem:ReactiveSystem<LootboxEntity>
    {
        private int currentPrizeIndex;
        private LootboxModel lootboxModel;
        private readonly LootboxContext lootboxContext;
        private readonly UiSoundsManager uiSoundsManager;
        private readonly LootboxSceneSwitcher lootboxLobbyLoaderController;
        private readonly LootboxOpeningController lootboxOpenEffectController;
        private readonly ILog log = LogManager.CreateLogger(typeof(ClickHandlerSystem));
        
        public ClickHandlerSystem(Contexts contexts, LootboxSceneSwitcher lootboxLobbyLoaderController,
            LootboxOpeningController lootboxOpenEffectController, UiSoundsManager uiSoundsManager) 
            : base(contexts.lootbox)
        {
            this.lootboxLobbyLoaderController = lootboxLobbyLoaderController;
            this.lootboxOpenEffectController = lootboxOpenEffectController;
            lootboxContext = contexts.lootbox;
            currentPrizeIndex = 0;
            this.uiSoundsManager = uiSoundsManager;
        }

        public void SetLootboxModel(LootboxModel lootboxDataArg)
        {
            lootboxModel = lootboxDataArg;
        } 
        
        protected override ICollector<LootboxEntity> GetTrigger(IContext<LootboxEntity> context)
        {
            return context.CreateCollector(LootboxMatcher.CanvasClick.Added());
        }

        protected override bool Filter(LootboxEntity entity)
        {
            return entity.isCanvasClick;
        }

        protected override void Execute(List<LootboxEntity> entities)
        {
            if (lootboxModel == null)
            {
                return;
            }
            
            int numberOfClicks = entities.Count;
            for (int i = 0; i < numberOfClicks; i++)
            {
                //Если коробка не открыта
                if (currentPrizeIndex == 0)
                {
                    lootboxOpenEffectController.OpenLootbox();
                    UiSoundsManager.Instance().PlayLootbox();
                    ShiftCurrentPrize();
                }
                //Если все призы уже показаны
                else if (currentPrizeIndex == lootboxModel.Prizes.Count)
                {
                    //Вернуться в лобби
                    lootboxLobbyLoaderController.LoadLobbyScene();
                    break;
                }
                //Если есть ресурсы, которые нужно показать
                else
                {
                    uiSoundsManager.PlayAdding();
                }

                ShiftCurrentPrize();
            }
        }

        private void ShiftCurrentPrize()
        {
            log.Info($"{nameof(ShiftCurrentPrize)} {nameof(currentPrizeIndex)} {currentPrizeIndex}");
            LootboxEntity entity = lootboxContext.CreateEntity();
            int quantity = lootboxModel.Prizes[currentPrizeIndex].Quantity;
            LootboxPrizeType lootboxPrizeType = lootboxModel.Prizes[currentPrizeIndex].LootboxPrizeType; 
            entity.AddShowPrize(quantity, lootboxPrizeType);
            currentPrizeIndex++;
        }
    }
}
