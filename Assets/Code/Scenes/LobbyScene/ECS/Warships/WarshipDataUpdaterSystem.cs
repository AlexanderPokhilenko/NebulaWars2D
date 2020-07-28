using System.Collections.Generic;
using System.Linq;
using Code.Common.Statistics;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.Warships
{
    /// <summary>
    /// Обновляет рейтинг и ранг при листании кораблей в ui.
    /// </summary>
    public class WarshipDataUpdaterSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly Text rankText;
        private readonly Slider slider;
        private readonly Text ratingText;
        private readonly LobbyUiContext lobbyUiContext;

        public WarshipDataUpdaterSystem(Contexts contexts, Text rankText, Text ratingText, Slider slider) 
            : base(contexts.lobbyUi)
        {
            this.slider = slider;
            this.rankText = rankText;
            this.ratingText = ratingText;
            lobbyUiContext = contexts.lobbyUi;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.CurrentWarshipTypeEnum.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasCurrentWarshipTypeEnum;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            //получить данные о корабле
            WarshipTypeEnum warshipTypeEnum = entities.Last().currentWarshipTypeEnum.value;
            var currentWarshipComponent = lobbyUiContext
                .GetGroup(LobbyUiMatcher.Warship)
                .AsEnumerable()
                .Single(entity => entity.warship.warshipDto.WarshipTypeEnum == warshipTypeEnum).warship;
            int rating = currentWarshipComponent.warshipDto.Rating;
            WarshipRankModel rankModel = WarshipRatingScaleStorage.Instance.GetRankModel(rating);
            
            //вставить значения
            rankText.text = rankModel.currentRank.ToString();
            ratingText.text = rankModel.ToString();
            slider.value = rankModel.rankProgress;
        }
    }
}