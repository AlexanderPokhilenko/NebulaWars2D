using System.Collections.Generic;
using Code.Scenes.BattleScene.Experimental;
using Entitas;
using Entitas.Unity;
using TMPro;
using UnityEngine;

namespace Code.BattleScene.ECS.Systems
{
    public class UpdateTeamsSystem : IExecuteSystem
    {
        private static readonly object LockObj = new object();
        private static Dictionary<ushort, byte> _teams = new Dictionary<ushort, byte>();
        private static uint _lastMessageId;
        private static bool WasProcessed = true;
        private readonly List<Material> materials;
        private readonly GameContext gameContext;

        public UpdateTeamsSystem(Contexts contexts, int totalTeamsCount)
        {
            gameContext = contexts.game;
            _lastMessageId = 0;
            WasProcessed = true;
            _teams.Clear();

            materials = TeamsColorManager.Instance().GetOutlineMaterials(totalTeamsCount);
        }

        public static void SetNewTeams(uint messageId, Dictionary<ushort, byte> values)
        {
            lock (LockObj)
            {
                if (WasProcessed)
                {
                    _teams = values;
                    WasProcessed = false;
                }
                else
                {
                    if (messageId > _lastMessageId)
                    {
                        foreach (var pair in values)
                        {
                            _teams[pair.Key] = pair.Value;
                        }

                        _lastMessageId = messageId;
                    }
                    else
                    {
                        foreach (var pair in _teams)
                        {
                            values[pair.Key] = pair.Value;
                        }

                        _teams = values;
                    }
                }
            }
        }

        public void Execute()
        {
            lock (LockObj)
            {
                if (WasProcessed) return;
                var teams = new Dictionary<ushort, byte>(_teams);

                foreach (var pair in teams)
                {
                    var id = pair.Key;
                    var entity = gameContext.GetEntityWithId(id);
                    if (entity != null && entity.hasView && !entity.hasDelayedRecreation && !entity.hasDelayedSpawn)
                    {
                        var teamMaterial = materials[pair.Value];
                        var transform = entity.view.gameObject.transform;
                        var renderer = transform.GetComponent<Renderer>();
                        if(renderer != null) renderer.material = teamMaterial;

                        foreach (Transform childTrans in transform)
                        {
                            if (childTrans.gameObject.GetEntityLink() != null) continue;
                            var textMeshPro = childTrans.GetComponent<TextMeshPro>();
                            if (textMeshPro != null) continue;
                            var particleSystem = childTrans.GetComponent<ParticleSystem>();
                            if (particleSystem != null) continue;
                            var lineRenderer = childTrans.GetComponent<LineRenderer>();
                            if (lineRenderer != null) continue;

                            renderer = childTrans.GetComponent<Renderer>();
                            if(renderer != null) renderer.material = teamMaterial;
                        }

                        _teams.Remove(id);
                    }
                }

                if (_teams.Count == 0) WasProcessed = true;
            }
        }
    }
}