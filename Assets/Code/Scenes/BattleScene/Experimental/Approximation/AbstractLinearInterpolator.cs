using System.Collections.Generic;
using System.Linq;

namespace Code.Scenes.BattleScene.Experimental.Approximation
{
    public abstract class AbstractLinearInterpolator<T> : IApproximator<T>
    {
        protected Dictionary<ushort, T> oldValues;
        protected Dictionary<ushort, T> newValues;
        protected float receivingTime;
        protected float deltaTime;

        protected AbstractLinearInterpolator(float time)
        {
            receivingTime = time;
            deltaTime = 0f;
            oldValues = new Dictionary<ushort, T>(0);
            newValues = oldValues;
        }

        public virtual void Clear()
        {
            oldValues.Clear();
            newValues.Clear();
            deltaTime = 0f;
            receivingTime = 0f;
        }

        public virtual void Set(Dictionary<ushort, T> values, float time)
        {
            oldValues = newValues;
            newValues = values;
            deltaTime = time - receivingTime;
            receivingTime = time;
        }

        public Dictionary<ushort, T> Get(float time)
        {
            var currentDeltaTime = time - receivingTime;
            if (currentDeltaTime > deltaTime) return new Dictionary<ushort, T>(newValues);
            float percent = currentDeltaTime / deltaTime;

            var result = oldValues.ToDictionary(p => p.Key, old =>
            {
                if (newValues.TryGetValue(old.Key, out var newValue))
                {
                    return GetValue(old.Value, newValue, percent);
                }
                else
                {
                    return old.Value;
                }
            });
            return result;
        }

        protected abstract T GetValue(T oldVal, T newVal, float percent);
    }
}
