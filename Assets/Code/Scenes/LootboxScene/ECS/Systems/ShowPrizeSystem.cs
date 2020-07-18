using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Scenes.LootboxScene.PrefabScripts;
using Code.Scenes.LootboxScene.Scripts;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LootboxScene.ECS.Systems
{
    /// <summary>
    /// Показывает новый ресурс.
    /// </summary>
    public class ShowPrizeSystem:ReactiveSystem<LootboxEntity>
    {
        private readonly LootboxUiStorage uiStorage;
        
        public ShowPrizeSystem(Contexts contexts, LootboxUiStorage uiStorage) 
            : base(contexts.lootbox)
        {
            this.uiStorage = uiStorage;
        }
        
        protected override ICollector<LootboxEntity> GetTrigger(IContext<LootboxEntity> context)
        {
            return context.CreateCollector(LootboxMatcher.ShowPrize.Added());
        }

        protected override bool Filter(LootboxEntity entity)
        {
            return entity.hasShowPrize;
        }

        protected override void Execute(List<LootboxEntity> entities)
        {
            //очистить
            ClearResources();
            //начать показывать текущий приз
            LootboxEntity currentPrize = entities.Last();
            ShowPrize(currentPrize);
        }

        private void ClearResources()
        {
            uiStorage.resourcesRoot.transform.DestroyAllChildren();
        }

        private void ShowPrize(LootboxEntity currentPrize)
        {
            ShowPrizeComponent prize = currentPrize.showPrize;
            Transform parent = uiStorage.resourcesRoot.transform;
            switch (prize.LootboxPrizeModel.LootboxPrizeType)
            {
                case LootboxPrizeType.SoftCurrency:
                {
                    var go = UnityEngine.Object.Instantiate(uiStorage.softCurrencyPrefab, parent);
                    var script = go.GetComponent<SoftCurrencyAccrual>();
                    script.SetData(prize.LootboxPrizeModel.Quantity);
                    break;
                }
                case LootboxPrizeType.HardCurrency:
                {
                    var go = UnityEngine.Object.Instantiate(uiStorage.hardCurrencyPrefab, parent);
                    var script = go.GetComponent<HardCurrencyAccrual>();
                    script.SetData(prize.LootboxPrizeModel.Quantity);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}