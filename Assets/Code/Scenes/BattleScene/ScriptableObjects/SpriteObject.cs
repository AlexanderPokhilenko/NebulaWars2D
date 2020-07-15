using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewSpriteObject", menuName = "ViewObjects/SpriteObject", order = 51)]
    public class SpriteObject : ViewObject
    {
        public Sprite sprite;
        public RuntimeAnimatorController controller;

        public override GameEntity CreateEntity(GameContext context)
        {
            var entity = base.CreateEntity(context);
            entity.AddSprite(sprite);
            if (controller != null) entity.AddAnimatorController(controller);

            return entity;
        }
    }
}
