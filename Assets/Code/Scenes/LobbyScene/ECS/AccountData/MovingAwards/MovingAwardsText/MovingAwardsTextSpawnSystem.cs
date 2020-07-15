using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Code.Scenes.LobbyScene.ECS.Systems.Execute
{
    /// <summary>
    /// Создаёт объект для текста, когда получает команду.
    /// </summary>
    public class MovingAwardsTextSpawnSystem : ReactiveSystem<LobbyUiEntity>
    {
        private GameObject awardTextGoCache;
        private readonly RectTransform movingAwardsTextParentRect;
        
        public MovingAwardsTextSpawnSystem(Contexts contexts, RectTransform movingAwardsTextParentRect) 
            : base(contexts.lobbyUi)
        {
            this.movingAwardsTextParentRect = movingAwardsTextParentRect;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.AwardText.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasAwardText && entity.hasPosition;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            foreach (var lobbyUiEntity in entities)
            {
                var awardTextPrefab = GetAwardTextPrefab();
                GameObject textGo = Object.Instantiate(awardTextPrefab, movingAwardsTextParentRect, false);
                var text = textGo.GetComponent<Text>();
                text.text = $"+{lobbyUiEntity.awardText.quantity}";
                lobbyUiEntity.AddView( textGo);
                lobbyUiEntity.AddText(text);
            }
        }

        private GameObject GetAwardTextPrefab()
        {
            if (awardTextGoCache == null)
            {
                awardTextGoCache = Resources.Load<GameObject>("Prefabs/AwardText");
                if (awardTextGoCache == null)
                {
                    throw new Exception("awardTextGoCache prefab not found");
                }    
            }

            return awardTextGoCache;
        }
    }
}