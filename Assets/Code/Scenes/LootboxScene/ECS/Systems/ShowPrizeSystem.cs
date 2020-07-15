using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.UI;

namespace DefaultNamespace
{
    /// <summary>
    /// Показывает новый приз.
    /// </summary>
    public class ShowPrizeSystem:ReactiveSystem<LootboxEntity>
    {
        private readonly Text text;
        
        public ShowPrizeSystem(Contexts contexts, Text text) 
            : base(contexts.lootbox)
        {
            this.text = text;
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
            //убрать предыдущий приз
            ClearCanvas();
            //начать показывать текущий приз
            var currentPrize = entities.Last();
            ShowPrize(currentPrize);
        }

        private void ClearCanvas()
        {
            text.text = string.Empty;
        }

        private void ShowPrize(LootboxEntity currentPrize)
        {
            var prize = currentPrize.showPrize;
            text.text = prize.LootboxPrizeType + " "+prize.amount;
        }
    }
}