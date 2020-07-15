using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Components.Game
{
    [Game]
    public class SpawnSoundComponent : IComponent
    {
        public AudioClip value;
    }
}
