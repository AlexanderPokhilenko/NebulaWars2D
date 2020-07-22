using System;
using System.Collections.Generic;
using System.Linq;
using Code.Scenes.LobbyScene.Scripts.WarshipsUi;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipOverview.Skins
{
    /// <summary>
    /// Отвечает за включение/выключение кнопок листания скинов
    /// </summary>
    public class SkinButtonsSwitcherSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly GameObject leftButton;
        private readonly GameObject rightButton;
        private readonly LobbyUiContext lobbyUiContext;

        public SkinButtonsSwitcherSystem(Contexts contexts, WarshipsUiStorage warshipsUiStorage)
            : base(contexts.lobbyUi)
        {
            lobbyUiContext = contexts.lobbyUi;
            if (warshipsUiStorage.leftSkinButton != null)
            {
                leftButton = warshipsUiStorage.leftSkinButton;
            }
            else
            {
                throw new NullReferenceException(nameof(warshipsUiStorage.leftSkinButton));
            }
            
            if (warshipsUiStorage.rightSkinButton != null)
            {
                rightButton = warshipsUiStorage.rightSkinButton;
            }
            else
            {
                throw new NullReferenceException(nameof(warshipsUiStorage.rightSkinButton));
            }
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.WarshipOverviewCurrentSkinModel);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasWarshipOverviewCurrentSkinModel;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            var skinModel = entities.Last().warshipOverviewCurrentSkinModel;
            int currentSkinIndex = skinModel.skinIndex;

            leftButton.SetActive(currentSkinIndex != 0);
            rightButton.SetActive(currentSkinIndex != skinModel.warshipDto.Skins.Count-1);
        }
    }
}