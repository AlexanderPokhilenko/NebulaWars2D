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

        public virtual void FillEntity(GameContext context, GameEntity entity)
        {
            if (spawnSound != null) entity.AddSpawnSound(spawnSound);
            if (loopSound != null) entity.AddLoopSound(loopSound);
            if (deathSound != null) entity.AddDeathSound(deathSound);
        }

        public void RefillEntity(GameContext context, GameEntity entity, Vector3 position, float direction)
        {
            var id = entity.id.value;

            entity.RemoveAllComponents();
            //entity.RemoveAllOnEntityReleasedHandlers();

            entity.AddId(id);
            entity.AddPosition(position);
            entity.AddDirection(direction);

            FillEntity(context, entity);
        }

        public GameEntity CreateEntity(GameContext context)
        {
            var entity = context.CreateEntity();
            FillEntity(context, entity);
            return entity;
        }
    }
}
