using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewSpriteObject", menuName = "ViewObjects/SpriteObject", order = 51)]
    public class SpriteObject : ViewObject
    {
        public Sprite sprite;
        public RuntimeAnimatorController controller;

        public override void FillEntity(GameContext context, GameEntity entity)
        {
            base.FillEntity(context, entity);
            entity.AddSprite(sprite);
            if (controller != null) entity.AddAnimatorController(controller);
        }
    }
}
