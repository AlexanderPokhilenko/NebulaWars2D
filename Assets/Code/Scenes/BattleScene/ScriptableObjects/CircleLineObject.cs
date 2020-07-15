using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewCircleLineObject", menuName = "ViewObjects/CircleLineObject", order = 52)]
    public class CircleLineObject : AbstractLineObject
    {
        [Min(3)]
        public int segmentsNumber = 64;
        [Min(0)]
        public float radius = 0.5f;

        public override GameEntity CreateEntity(GameContext context)
        {
            var entity = base.CreateEntity(context);
            entity.AddCircleLine(segmentsNumber, width, material);
            entity.AddCircle(radius);

            return entity;
        }
    }
}
