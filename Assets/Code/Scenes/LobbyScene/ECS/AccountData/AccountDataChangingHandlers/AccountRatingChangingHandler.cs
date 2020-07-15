using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.AccountData.AccountDataChangingHandlers
{
    /// <summary>
    /// Устанавливает значение рейтинга аккаунта при добавлении компонента.
    /// </summary>
    public class AccountRatingChangingHandler:ReactiveSystem<LobbyUiEntity>
    {
        private readonly Text accountRatingText;
        
        public AccountRatingChangingHandler(IContext<LobbyUiEntity> context, Text accountRatingText) 
            : base(context)
        {
            if (accountRatingText == null)
            {
                throw new Exception(nameof(accountRatingText));
            }
            this.accountRatingText= accountRatingText;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.AccountRating.Added());
        }
    
        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasAccountRating;
        }
    
        protected override void Execute(List<LobbyUiEntity> entities)
        {
            var entity = entities.Single();
            accountRatingText.text = entity.accountRating.value.ToString();
        }
    }
}