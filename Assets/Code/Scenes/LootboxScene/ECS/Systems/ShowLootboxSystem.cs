using System;
using System.Collections.Generic;
using Code.Common.Logger;
using Entitas;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Scenes.LootboxScene.ECS.Systems
{
    public class ShowLootboxSystem : ReactiveSystem<LootboxEntity>
    {
        private readonly Transform contentParent;
        private readonly GameObject lootboxPrefab;
        private readonly ILog log = LogManager.CreateLogger(typeof(ShowLootboxSystem));
        
        public ShowLootboxSystem(IContext<LootboxEntity> context, GameObject lootboxPrefab, Transform contentParent) 
            : base(context)
        {
            this.lootboxPrefab = lootboxPrefab;
            this.contentParent = contentParent;

            if (lootboxPrefab == null)
            {
                throw new NullReferenceException();
            }
        }

        protected override ICollector<LootboxEntity> GetTrigger(IContext<LootboxEntity> context)
        {
            return context.CreateCollector(LootboxMatcher.ShowLootbox);
        }

        protected override bool Filter(LootboxEntity entity)
        {
            return entity.isShowLootbox;
        }

        protected override void Execute(List<LootboxEntity> entities)
        {
            GameObject go = Object.Instantiate(lootboxPrefab, contentParent);
            GameObject closedLootbox = go.transform.Find("Sprite_ClosedLootbox").gameObject;
            closedLootbox.SetActive(true);
            GameObject openedLootbox = go.transform.Find("Sprite_OpenedLootbox").gameObject;
            openedLootbox.SetActive(false);
            // var lootboxOpeningController = go.GetComponent<LootboxOpeningController>();
        }

        private void LootboxAnimationEnded()
        {
            log.Debug(nameof(LootboxAnimationEnded));
            // if (currentPrizeIndex == -1)
            // {
            //     HandleClick();
            // }   
        }
    }
}