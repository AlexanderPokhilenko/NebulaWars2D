using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using TMPro;
using UnityEngine;

namespace Code.BattleScene.ECS.Systems
{
    public class UpdateTeamsSystem : IExecuteSystem, ITearDownSystem
    {
        private static readonly object LockObj = new object();
        private static Dictionary<ushort, byte> _teams = new Dictionary<ushort, byte>();
        private static uint _lastMessageId;
        private static bool WasProcessed = true;
        private readonly Material[] materials;
        private readonly GameContext gameContext;

        public UpdateTeamsSystem(Contexts contexts, int totalTeamsCount)
        {
            gameContext = contexts.game;
            _lastMessageId = 0;
            WasProcessed = true;
            _teams.Clear();

            materials = new Material[totalTeamsCount];
            var outlineShader = Shader.Find("Sprites/Outline");
            for (var i = 0; i < totalTeamsCount; i++)
            {
                materials[i] = new Material(outlineShader);
                materials[i].SetColor("_SolidOutline", Color.HSVToRGB((float)i / totalTeamsCount, 1f, 1f));
                materials[i].SetFloat("_Thickness", 1f);
            }
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

        public void TearDown()
        {
            foreach (var material in materials)
            {
                Object.DestroyImmediate(material);
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