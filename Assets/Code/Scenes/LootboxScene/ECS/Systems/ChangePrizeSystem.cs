using System.Collections.Generic;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using Code.Scenes.LootboxScene.Scripts;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LootboxScene.ECS.Systems
{
    /// <summary>
    /// Реагирует на нажатие на канвас.
    /// </summary>
    public class ChangePrizeSystem:ReactiveSystem<LootboxEntity>
    {
        private int currentPrizeIndex;
        private LootboxModel lootboxData;
        private UiSoundsManager uiSoundsManager;
        private readonly LootboxContext lootboxContext;
        private readonly LootboxSceneSwitcher lootboxLobbyLoaderController;
        private readonly ILog log = LogManager.CreateLogger(typeof(ChangePrizeSystem));
        
        public ChangePrizeSystem(Contexts contexts, LootboxSceneSwitcher lootboxLobbyLoaderController) 
            : base(contexts.lootbox)
        {
            this.lootboxLobbyLoaderController = lootboxLobbyLoaderController;
            lootboxContext = contexts.lootbox;
            currentPrizeIndex = 0;
            uiSoundsManager = UiSoundsManager.Instance();
        }

        public void SetLootboxData(LootboxModel lootboxDataArg)
        {
            lootboxData = lootboxDataArg;
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
            if (lootboxData == null)
            {
                return;
            }
            
            int numberOfClicks = entities.Count;
            for (int i = 0; i < numberOfClicks; i++)
            {
                //Если уже показан последний приз
                if (currentPrizeIndex == lootboxData.Prizes.Count)
                {
                    //Вернуться в лобби
                    lootboxLobbyLoaderController.LoadLobbyScene();
                    break;
                }

                //Можно показать приз
                uiSoundsManager.PlayAdding();
                ShiftCurrentPrize();
            }
        }

        private void ShiftCurrentPrize()
        {
            log.Info($"{nameof(ShiftCurrentPrize)} {nameof(currentPrizeIndex)} {currentPrizeIndex}");
            var entity = lootboxContext.CreateEntity();
            entity.AddShowPrize(lootboxData.Prizes[currentPrizeIndex].Quantity, lootboxData.Prizes[currentPrizeIndex].LootboxPrizeType);
            currentPrizeIndex++;
        }
    }
}
