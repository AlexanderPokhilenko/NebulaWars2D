using Code.Scenes.BattleScene.Experimental;
using Entitas;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Code.BattleScene.ECS.Systems
{
    public class MaterialsMoveSystem : IExecuteSystem, ITearDownSystem
    {
        private readonly MovingMaterialInfo[] materials;

        public MaterialsMoveSystem(Contexts contexts, MovingMaterialInfo[] matInfos)
        {
            materials = matInfos;
        }

        public void Execute()
        {
            foreach (var (material, offset) in materials)
            {
                material.mainTextureOffset += offset * Time.deltaTime;
            }
        }

        public void TearDown()
        {
            foreach (var (material, _) in materials)
            {
                material.mainTextureOffset = Vector2.zero;
            }
        }
    }
}