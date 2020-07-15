using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.Systems.Reactive.AccountInfoChangingHandlers
{
    /// <summary>
    /// Устанавливает значение кол-ва премиумной валюты в при добавлении компонента.
    /// </summary>
    public class HardCurrencyChangingHandler:ReactiveSystem<LobbyUiEntity>
    {
        private readonly Text premiumCurrencyText;
        
        public HardCurrencyChangingHandler(IContext<LobbyUiEntity> context, Text premiumCurrencyText) 
            : base(context)
        {
            if (premiumCurrencyText == null)
            {
                throw new NullReferenceException(nameof(premiumCurrencyText));
            }
            this.premiumCurrencyText = premiumCurrencyText;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.HardCurrency.Added());
        }
    
        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasHardCurrency;
        }
    
        protected override void Execute(List<LobbyUiEntity> entities)
        {
            LobbyUiEntity entity = entities.Single();
            premiumCurrencyText.text = entity.hardCurrency.value.ToString();
        }
    }
}