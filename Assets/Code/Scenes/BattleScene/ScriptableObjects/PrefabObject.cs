using Entitas.Unity;
using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPrefabObject", menuName = "ViewObjects/PrefabObject", order = 54)]
    public class PrefabObject : ViewObject
    {
        public GameObject gameObject;
        public float maxSpeed;

        public override void FillEntity(GameContext context, GameEntity entity)
        {
            base.FillEntity(context, entity);
            GameObject clonedObject = Instantiate(gameObject, GameObject.Find("Game Views").transform);
            clonedObject.name = "Game ViewComponent";
            entity.AddView(clonedObject);
            clonedObject.Link(entity);
            var animator = clonedObject.GetComponent<Animator>();
            if (animator != null && animator.runtimeAnimatorController != null) entity.AddAnimatorController(animator.runtimeAnimatorController);
            if (maxSpeed > 0f) entity.AddMaxSpeed(maxSpeed);
        }
    }
}
