using System.Collections.Generic;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.LobbySceneUi
{
    public class LobbySceneUiEnablingSystem:ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyUiStorage lobbyUiStorage;
        private readonly ILog log = LogManager.CreateLogger(typeof(LobbySceneUiEnablingSystem));
        
        public LobbySceneUiEnablingSystem(Contexts context, LobbyUiStorage lobbyUiStorage)
            : base(context.lobbyUi)
        {
            this.lobbyUiStorage = lobbyUiStorage;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.EnableLobbySceneUi);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.isEnableLobbySceneUi;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            lobbyUiStorage.gameViewsRoot.SetActive(true);
            lobbyUiStorage.overlayCanvas.SetActive(true);
        }
    }
}