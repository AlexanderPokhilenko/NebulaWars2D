using System.Collections.Generic;
using Entitas;
using TMPro;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class AddTextSystem : ReactiveSystem<GameEntity>
    {
        private readonly Material material;

        public AddTextSystem(Contexts contexts, Material nicknameMat) : base(contexts.game)
        {
            material = nicknameMat;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            var matcher = GameMatcher.AllOf(GameMatcher.View);
            return context.CreateCollector(matcher);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.hasPlayer && !entity.hasTextMeshPro;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var go = e.view.gameObject;

                var text = new GameObject("Name");
                text.transform.SetParent(go.transform);
                var tmp = text.AddComponent<TextMeshPro>();
                var rectTr = tmp.rectTransform;
                rectTr.sizeDelta = new Vector2(4f, 0.5f);
                tmp.alignment = TextAlignmentOptions.Center;
                tmp.enableAutoSizing = true;
                tmp.fontMaterial = material;
                tmp.fontSizeMin = 3;
                tmp.fontSizeMax = 6;
                tmp.text = e.player.nickname;
                e.AddTextMeshPro(tmp);
            }
        }
    }
}