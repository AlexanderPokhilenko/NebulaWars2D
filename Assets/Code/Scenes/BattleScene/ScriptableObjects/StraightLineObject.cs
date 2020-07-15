using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewStraightLineObject", menuName = "ViewObjects/StraightLineObject", order = 53)]
    public class StraightLineObject : AbstractLineObject
    {
        [Min(0)]
        public float length = 1f;

        public override GameEntity CreateEntity(GameContext context)
        {
            var entity = base.CreateEntity(context);
            entity.AddStraightLine(material);
            entity.AddRectangle(length, width);

            return entity;
        }
    }
}
