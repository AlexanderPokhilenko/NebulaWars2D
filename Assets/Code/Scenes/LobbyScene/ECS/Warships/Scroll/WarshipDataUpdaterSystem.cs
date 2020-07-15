using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Обновляет рейтинг и ранг при листании кораблей в ui.
    /// </summary>
    public class WarshipDataUpdaterSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly Text rankText;
        private readonly Text ratingText;
        private readonly Slider slider;
        private readonly LobbyUiContext lobbyUiContext;

        public WarshipDataUpdaterSystem(Contexts contexts, Text rankText, Text ratingText, Slider slider) 
            : base(contexts.lobbyUi)
        {
            lobbyUiContext = contexts.lobbyUi;
            this.rankText = rankText;
            this.ratingText = ratingText;
            this.slider = slider;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.CurrentWarshipIndex.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasCurrentWarshipIndex;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            //получить данные о корабле
            int currentWarshipIndex = entities.Last().currentWarshipIndex.value;
            var currentWarshipComponent = lobbyUiContext
                .GetGroup(LobbyUiMatcher.Warship)
                .AsEnumerable()
                .Last(entity => entity.warship.index == currentWarshipIndex).warship;
            int rating = currentWarshipComponent.warshipDto.Rating;
            WarshipRankModel rankModel = WarshipRatingScaleStorage.Instance.GetRankModel(rating);
            
            //вставить значения
            rankText.text = rankModel.currentRank.ToString();
            ratingText.text = rankModel.ToString();
            slider.value = rankModel.rankProgress;
        }
    }
}