using System.Collections.Generic;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.LobbySceneUi
{
    public class LobbySceneUiDisablingSystem:ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyUiStorage lobbyUiStorage;

        public LobbySceneUiDisablingSystem(IContext<LobbyUiEntity> context, LobbyUiStorage lobbyUiStorage)
            : base(context)
        {
            this.lobbyUiStorage = lobbyUiStorage;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.DisableLobbySceneUi);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.isDisableLobbySceneUi;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            lobbyUiStorage.gameViewsRoot.SetActive(false);
            lobbyUiStorage.overlayCanvas.SetActive(false);
        }
    }
}