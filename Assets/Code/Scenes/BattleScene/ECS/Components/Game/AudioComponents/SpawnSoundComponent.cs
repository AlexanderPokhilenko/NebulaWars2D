using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Components.Game.AudioComponents
{
    [Game]
    public class SpawnSoundComponent : IComponent
    {
        public AudioClip value;
    }
}
