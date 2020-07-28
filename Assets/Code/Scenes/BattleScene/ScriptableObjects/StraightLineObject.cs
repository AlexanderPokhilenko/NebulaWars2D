using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewStraightLineObject", menuName = "ViewObjects/StraightLineObject", order = 53)]
    public class StraightLineObject : AbstractLineObject
    {
        [Min(0)]
        public float length = 1f;

        public override void FillEntity(GameContext context, GameEntity entity)
        {
            base.FillEntity(context, entity);
            entity.AddStraightLine(material);
            entity.AddRectangle(length, width);
        }
    }
}
