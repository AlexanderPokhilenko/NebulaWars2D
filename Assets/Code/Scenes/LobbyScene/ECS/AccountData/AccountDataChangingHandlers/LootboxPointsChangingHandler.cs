using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.AccountData.AccountDataChangingHandlers
{
    /// <summary>
    /// Устанавливает значение кол-ва очков для маленького сундука.
    /// </summary>
    public class LootboxPointsChangingHandler:ReactiveSystem<LobbyUiEntity>
    {
        private readonly Text pinText;
        private readonly Text lootboxText;
        private readonly GameObject pinRoot;
        private readonly GameObject pinGameObject;
        
        public LootboxPointsChangingHandler(IContext<LobbyUiEntity> context,  Text lootboxText, 
            GameObject pinGameObject, Text pinText) 
            : base(context)
        {
            if (lootboxText == null)
            {
                throw new Exception($"{nameof(lootboxText)} was null");
            }
            this.lootboxText = lootboxText;
            this.pinGameObject = pinGameObject;
            this.pinText = pinText;
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
            if (value < 100)
            {
                lootboxText.text = value+"/100";
                if (pinGameObject.activeSelf)
                {
                    pinGameObject.SetActive(false);
                }
            }
            else
            {
                lootboxText.text = value%100+"/100";
                if (!pinGameObject.activeSelf)
                {
                    pinGameObject.SetActive(true);
                }
                
                pinText.text = "" + value / 100;
            }
        }
    }
}