using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Scenes.LobbyScene.ECS.Components;
using Entitas;
using Entitas.Unity;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using Object = UnityEngine.Object;
using Vector2 = NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2;

namespace Code.Scenes.LobbyScene.ECS.Systems.Reactive.Warships
{
    /// <summary>
    /// Создаёт корабли в лобби при инициализации лобби и при смене скина.
    /// </summary>
    public class WarshipSpawnerSystem:ReactiveSystem<LobbyUiEntity>
    {
        private bool isWarshipCreationCompleted;
        private readonly GameContext gameContext;
        private readonly Transform gameViewsParent;
        private readonly LobbyUiContext lobbyUiContext;
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipSpawnerSystem));

        public WarshipSpawnerSystem(Contexts contexts, Transform gameViewsParent) 
            : base(contexts.lobbyUi)
        {
            this.gameViewsParent = gameViewsParent;
            gameContext = contexts.game;
            isWarshipCreationCompleted = false;
            lobbyUiContext = contexts.lobbyUi;
            gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Id, GameMatcher.Transform ));
        }
        
        public bool IsWarshipCreationCompleted()
        {
            return isWarshipCreationCompleted;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.Warship.Added());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasWarship;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            foreach (WarshipComponent warshipComponent in entities.Select(entity=>entity.warship))
            {
                log.Info("Спавн корабля с id = "+warshipComponent.index);
                WarshipDto warshipDto = warshipComponent.warshipDto;
                
                int skinIndex = CurrentWarshipSkinIndexStorage.Get(warshipDto.WarshipName);
                string skinName = warshipDto.Skins[skinIndex].Name;
                int horizontalPosition = LobbyUiGlobals.DistanceBetweenWarships * warshipComponent.index;
                GameObject prefab = Resources.Load<GameObject>("Prefabs/" + skinName);
                GameObject go = Object.Instantiate(prefab, gameViewsParent, false);

                GameEntity gameEntity = gameContext.GetEntityWithId(warshipComponent.index);
                if (gameEntity == null)
                {
                    gameEntity = gameContext.CreateEntity();
                    go.Link(gameEntity);
                    gameEntity.AddView(go);
                    gameEntity.AddId(warshipComponent.index);
                    gameEntity.AddTransform(new Vector2(horizontalPosition, 0), 0);    
                }
                else
                {
                    gameEntity.view.gameObject.Unlink();
                    Object.Destroy(gameEntity.view.gameObject);
                    gameEntity.ReplaceView(go);
                    go.Link(gameEntity);
                }
            }
            
            int currentWarshipIndex = CurrentWarshipIndexStorage.Get();
            lobbyUiContext.ReplaceCurrentWarshipIndex(currentWarshipIndex);
            isWarshipCreationCompleted = true;
        }
    }
}