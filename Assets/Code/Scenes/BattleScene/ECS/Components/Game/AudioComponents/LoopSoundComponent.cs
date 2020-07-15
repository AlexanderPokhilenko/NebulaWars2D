using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Components.Game
{
    [Game]
    public class LoopSoundComponent : IComponent
    {
        public AudioClip value;
    }
}
