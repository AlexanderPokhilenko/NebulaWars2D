using Entitas;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Components.Game.AudioComponents
{
    [Game]
    public class DeathSoundComponent : IComponent
    {
        public AudioClip value;
    }
}
