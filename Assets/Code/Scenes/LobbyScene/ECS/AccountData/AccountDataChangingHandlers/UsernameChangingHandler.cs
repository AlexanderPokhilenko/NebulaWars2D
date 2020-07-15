﻿using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.Systems.Reactive.AccountInfoChangingHandlers
{
    /// <summary>
    /// Устанавливает значение имени пользователя при добавлении компонента.
    /// </summary>
    public class UsernameChangingHandler:ReactiveSystem<LobbyUiEntity>
    {
        private readonly Text usernameText;
        
        public UsernameChangingHandler(IContext<LobbyUiEntity> context, Text usernameText) 
            : base(context)
        {
            if (usernameText == null)
            {
                throw new Exception($"{nameof(usernameText)} was null");
            }
            this.usernameText = usernameText;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.Username.Added());
        }
    
        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasUsername;
        }
    
        protected override void Execute(List<LobbyUiEntity> entities)
        {
            var entity = entities.Single();
            usernameText.text = entity.username.username;
        }
    }
}