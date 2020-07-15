using Entitas.Unity;
using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPrefabObject", menuName = "ViewObjects/PrefabObject", order = 54)]
    public class PrefabObject : ViewObject
    {
        public GameObject gameObject;
        public float maxSpeed;
      
        public override GameEntity CreateEntity(GameContext context)
        {
            GameEntity entity = base.CreateEntity(context);
            GameObject clonedObject = Instantiate(gameObject, GameObject.Find("Game Views").transform);
            clonedObject.name = "Game ViewComponent";
            entity.AddView(clonedObject);
            clonedObject.Link(entity);
            RuntimeAnimatorController controller = clonedObject.GetComponent<RuntimeAnimatorController>();
            if (controller != null) entity.AddAnimatorController(controller);
            if(maxSpeed > 0f) entity.AddMaxSpeed(maxSpeed);

            return entity;
        }
    }
}
