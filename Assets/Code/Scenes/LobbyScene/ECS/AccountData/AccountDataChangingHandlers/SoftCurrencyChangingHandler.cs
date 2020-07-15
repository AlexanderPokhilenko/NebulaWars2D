using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.Systems.Reactive.AccountInfoChangingHandlers
{
    /// <summary>
    /// Устанавливает значение кол-ва обычной валюты в при добавлении компонента.
    /// </summary>
    public class SoftCurrencyChangingHandler:ReactiveSystem<LobbyUiEntity>
    {
        private readonly Text regularCurrencyText;
        
        public SoftCurrencyChangingHandler(IContext<LobbyUiEntity> context, Text regularCurrencyText) 
            : base(context)
        {
            if (regularCurrencyText == null)
            {
                throw new NullReferenceException($"{nameof(regularCurrencyText)} was null");
            }
            this.regularCurrencyText = regularCurrencyText;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.SoftCurrency.Added());
        }
    
        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasSoftCurrency;
        }
    
        protected override void Execute(List<LobbyUiEntity> entities)
        {
            LobbyUiEntity entity = entities.Single();
            regularCurrencyText.text = entity.softCurrency.value.ToString();
        }
    }
}