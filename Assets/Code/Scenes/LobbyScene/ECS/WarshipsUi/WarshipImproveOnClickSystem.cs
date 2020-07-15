using System.Collections.Generic;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.Components.WarshipsUi.WarshipOverview
{
    public class WarshipImproveOnClickSystem:ReactiveSystem<LobbyUiEntity>
    {
        public WarshipImproveOnClickSystem(IContext<LobbyUiEntity> context) 
            : base(context)
        {
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.ImproveWarshipButtonPressed);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.messageImproveWarshipButtonPressed;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            //todo если денег хватает, то 
        }
    }
}