using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    public abstract class AbstractLineObject : ViewObject
    {
        [Min(0)]
        public float width = 1f;
        public Material material;
    }
}
