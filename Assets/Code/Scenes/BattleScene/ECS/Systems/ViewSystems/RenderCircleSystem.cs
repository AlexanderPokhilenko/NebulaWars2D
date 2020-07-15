using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class RenderCircleSystem : ReactiveSystem<GameEntity>
    {
        public RenderCircleSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            var matcher = GameMatcher.AllOf(GameMatcher.CircleLine, GameMatcher.Circle);
            return context.CreateCollector(matcher);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCircleLine && entity.hasCircle && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                GameObject go = e.view.gameObject;
                LineRenderer lineRenderer = go.GetComponent<LineRenderer>();
                if (lineRenderer == null) lineRenderer = go.AddComponent<LineRenderer>();

                lineRenderer.material = e.circleLine.material;
                lineRenderer.startWidth = e.circleLine.width;
                lineRenderer.endWidth = e.circleLine.width;
                lineRenderer.positionCount = e.circleLine.numSegments + 1;
                lineRenderer.useWorldSpace = false;
                lineRenderer.textureMode = LineTextureMode.Tile;
                lineRenderer.loop = true;

                float deltaTheta = 2.0f * Mathf.PI / e.circleLine.numSegments;
                float theta = 0f;

                float radius = e.circle.radius;

                for (int i = 0; i < e.circleLine.numSegments + 1; i++)
                {
                    float x = radius * Mathf.Cos(theta);
                    float y = radius * Mathf.Sin(theta);
                    Vector3 pos = new Vector3(x, y, 0f);
                    lineRenderer.SetPosition(i, pos);
                    theta += deltaTheta;
                }
            }
        }
    }
}