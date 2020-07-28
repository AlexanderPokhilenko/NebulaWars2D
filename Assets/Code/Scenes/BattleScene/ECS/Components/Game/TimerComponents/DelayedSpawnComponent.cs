﻿namespace Code.Scenes.BattleScene.ECS.Components.Game.TimerComponents
{
    [Game]
    public class DelayedSpawnComponent : TimerComponent
    {
        public ViewTypeId typeId;
        public float positionX;
        public float positionY;
        public float direction;
    }
}