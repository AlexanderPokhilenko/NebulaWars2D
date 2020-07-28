using Code.Scenes.BattleScene.Udp.MessageProcessing;
using Code.Scenes.BattleScene.Udp.MessageProcessing.Synchronizers;
using Entitas;
using Entitas.Unity;
using Object = UnityEngine.Object;

namespace Code.Scenes.BattleScene.ECS.Systems.TearDownSystems
{
    public class ContextsClearSystem : ITearDownSystem
    {
        private readonly Contexts contexts;

        public ContextsClearSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }
        
        public void TearDown()
        {
            var entities = contexts.lobbyUi.GetEntities();
            foreach (var entity in entities)
            {
                if (entity.hasView)
                {
                    var gameObject = entity.view.gameObject;
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