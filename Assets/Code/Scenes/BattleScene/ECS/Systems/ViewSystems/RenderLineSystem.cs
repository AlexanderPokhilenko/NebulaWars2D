﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class RenderLineSystem : ReactiveSystem<GameEntity>
    {
        public RenderLineSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            var matcher = GameMatcher.AllOf(GameMatcher.StraightLine, GameMatcher.Rectangle);
            return context.CreateCollector(matcher);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasStraightLine && entity.hasRectangle && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                GameObject go = e.view.gameObject;
                LineRenderer lineRenderer = go.GetComponent<LineRenderer>();
                if (lineRenderer == null) lineRenderer = go.AddComponent<LineRenderer>();

                lineRenderer.material = e.straightLine.material;
                lineRenderer.startWidth = e.rectangle.height;
                lineRenderer.endWidth = e.rectangle.height;
                lineRenderer.positionCount = 2;
                lineRenderer.useWorldSpace = false;
                lineRenderer.textureMode = LineTextureMode.Tile;
                lineRenderer.loop = false;

                var halfLength = e.rectangle.width / 2f;
                lineRenderer.SetPosition(0, new Vector3(-halfLength, 0, 0));
                lineRenderer.SetPosition(1, new Vector3(halfLength, 0, 0));
            }
        }
    }
}