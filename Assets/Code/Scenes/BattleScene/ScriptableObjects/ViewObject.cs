using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    public abstract class ViewObject : ScriptableObject
    {
        [SerializeField]
        private AudioClip spawnSound;
        [SerializeField]
        private AudioClip loopSound;
        [SerializeField]
        private AudioClip deathSound;

        public virtual GameEntity CreateEntity(GameContext context)
        {
            var entity = context.CreateEntity();

            if (spawnSound != null) entity.AddSpawnSound(spawnSound);
            if (loopSound != null) entity.AddLoopSound(loopSound);
            if (deathSound != null) entity.AddDeathSound(deathSound);

            return entity;
        }
    }
}
