using System;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS
{
    public class ControlPoint
    {
        public Vector3 position;
        public DateTime arrivalTime;
        public Vector3 scale;
        /// <summary>
        /// 0 - прозрачный, 1 - не прозрачный
        /// </summary>
        public float alpha;
        public bool moveToUp;
    }
}