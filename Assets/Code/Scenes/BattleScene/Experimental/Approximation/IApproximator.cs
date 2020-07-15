using System.Collections.Generic;

namespace Code.Scenes.BattleScene.Experimental.Approximation
{
    public interface IApproximator<T>
    {
        void Set(Dictionary<ushort, T> values, float time);
        Dictionary<ushort, T> Get(float time);
        void Clear();
    }
}
