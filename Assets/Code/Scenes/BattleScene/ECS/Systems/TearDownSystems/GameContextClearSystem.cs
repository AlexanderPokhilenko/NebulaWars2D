using Code.Scenes.BattleScene.Udp.MessageProcessing;
using Code.Scenes.BattleScene.Udp.MessageProcessing.Synchronizers;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Scenes.BattleScene.ECS.Systems.TearDownSystems
{
    public class GameContextClearSystem : ITearDownSystem
    {
        private readonly Contexts contexts;

        public GameContextClearSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }
        
        public void TearDown()
        {
            GameEntity[] entities = contexts.game.GetEntities();
            foreach (GameEntity entity in entities)
            {
                if (entity.hasView)
                {
                    GameObject gameObject = entity.view.gameObject;
                    if (gameObject != null)
                    {
                        gameObject.Unlink();
                        Object.Destroy(gameObject);   
                    }
                }
                entity.Destroy();
            }
        }
    }
}