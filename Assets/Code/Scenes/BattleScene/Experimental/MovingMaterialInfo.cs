using System;
using UnityEngine;

namespace Code.Scenes.BattleScene.Experimental
{
    [Serializable]
    public class MovingMaterialInfo
    {
        public Material material;
        public Vector2 offset;

        public void Deconstruct(out Material mat, out Vector2 o)
        {
            mat = material;
            o = offset;
        }
    }
}
