using System.Collections.Generic;
using System.Linq;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.ECS.Warships.Utils;
using Entitas;
using Entitas.Unity;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using Object = UnityEngine.Object;
using Vector2 = NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2;

namespace Code.Scenes.LobbyScene.ECS.Warships
{
    /// <summary>
    /// Создаёт корабли в лобби при инициализации лобби и при смене скина.
    /// </summary>
    public class WarshipSpawnerSystem:ReactiveSystem<LobbyUiEntity>
    {
        private bool isWarshipCreationCompleted;
        private readonly GameContext gameContext;
        private readonly Transform gameViewsParent;
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipSpawnerSystem));

        public WarshipSpawnerSystem(Contexts contexts, Transform gameViewsParent) 
            : base(contexts.lobbyUi)
        {
            gameContext = contexts.game;
            isWarshipCreationCompleted = false;
            this.gameViewsParent = gameViewsParent;
            gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.View, GameMatcher.Id, GameMatcher.Transform ));
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
                
                string skinName = warshipDto.GetCurrentSkinName();
                int horizontalPosition = LobbyUiGlobals.DistanceBetweenWarships * warshipComponent.index;
                GameObject prefab = Resources.Load<GameObject>("Prefabs/" + skinName);
                GameObject warship = Object.Instantiate(prefab, gameViewsParent, false);
                warship.transform.localScale = new Vector3(1.4f,1.4f,1.4f);

                GameEntity gameEntity = gameContext.GetEntityWithId(warshipComponent.index);
                if (gameEntity == null)
                {
                    gameEntity = gameContext.CreateEntity();
                    warship.Link(gameEntity);
                    gameEntity.AddView(warship);
                    gameEntity.AddId(warshipComponent.index);
                    gameEntity.AddTransform(new Vector2(horizontalPosition, 0), 0);    
                }
                else
                {
                    gameEntity.view.gameObject.Unlink();
                    Object.Destroy(gameEntity.view.gameObject);
                    gameEntity.ReplaceView(warship);
                    warship.Link(gameEntity);
                    WarshipIndexStorage.WriteWarshipIndex(warshipComponent.index);
                }
                
            }
            
            isWarshipCreationCompleted = true;
        }
    }
}