// using System;
// using System.Collections.Generic;
// using Entitas;
// using UnityEngine;
//
// namespace Code.Scenes.LobbyScene.ECS
// {
//     
//     [LobbyUi]
//     public class MovingAwardComponent: IComponent
//     {
//         public int Increment;
//         public AwardType awardType;
//         public int currentTargetIndex;
//         public List<ControlPoint> controlPoints;
//     }
//
//     public class ControlPoint
//     {
//         public Vector3 position;
//         public DateTime ArrivalTime;
//         public Vector3 scale;
//         /// <summary>
//         /// 0 - прозрачный, 1 - не прозрачный
//         /// </summary>
//         public float alpha;
//         public bool moveToUp;
//     }
// }