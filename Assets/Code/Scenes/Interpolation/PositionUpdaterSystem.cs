// using System;
// using System.Collections.Generic;
// using Code.Common;
// using UnityEngine;
//
// namespace Code.Scenes.Interpolation
// {
//     public class PositionUpdaterSystem:MonoBehaviour
//     {
//         private readonly object lockObj = new object();
//         [SerializeField] private GameObject gameObject;
//         private readonly Interolator interolator = new Interolator();
//         private readonly List<FrameModel> frameModels = new List<FrameModel>();
//
//         private void Awake()
//         {
//             Application.targetFrameRate = 60;
//         }
//
//         public void AddFrame(FrameModel frameModel)
//         {
//             lock (lockObj)
//             {
//                 frameModels.Add(frameModel);
//                 UnityThread.Execute(() =>
//                 {
//                     Debug.Log($"кол-во кадров "+frameModels.Count);
//                 });
//             }
//         }
//
//         private void Update()
//         {
//             lock (lockObj)
//             {
//                 try
//                 {
//                     DateTime now = DateTime.UtcNow-TimeSpan.FromMilliseconds(1000f/InterpolationGlobals.serverFrameRate*4);
//                     FrameModel p0Frame = null;
//                     FrameModel p1Frame = null;
//                     FrameModel p2Frame = null;
//                     FrameModel p3Frame = null;
//                     if (!TryGetFrames(now, ref p0Frame, ref p1Frame, ref p2Frame, ref p3Frame))
//                     {
//                         return;
//                     }
//             
//                     //0..1
//                     float t = GetProgress(p2Frame.dateTime, p3Frame.dateTime, now);
//             
//                     Debug.Log($"t {t}");
//                     Vector2 currentPoint = interolator.Do(p0Frame.position, p1Frame.position,
//                         p2Frame.position, p3Frame.position, t);
//                     gameObject.transform.position = currentPoint;
//                 }
//                 catch (Exception e)
//                 {
//                     Debug.LogError(e.Message+" "+e.StackTrace);
//                 }
//             }
//         }
//
//         private float GetProgress(DateTime p2FrameTime, DateTime p3FrameTime, DateTime now)
//         {
//             if (p3FrameTime < p2FrameTime)
//             {
//                 throw new Exception("Неправильный порядок кадров.");
//             }
//             
//             if (now < p2FrameTime)
//             {
//                 return 0;
//             }
//             
//             if (p3FrameTime < now)
//             {
//                 return 1;
//             }
//
//             TimeSpan timeSpanLong = p3FrameTime - p2FrameTime;
//             TimeSpan timeSpanShort = now - p2FrameTime;
//
//             return 1f * timeSpanShort.Milliseconds / timeSpanLong.Milliseconds;
//         }
//         
//         private bool TryGetFrames(
//             DateTime dateTime, 
//             ref FrameModel p0Frame,
//             ref FrameModel p1Frame,
//             ref FrameModel p2Frame, 
//             ref FrameModel p3Frame)
//         {
//             //Поиск кадра для нужного времени
//             int p2Index = frameModels.Count - 1;
//             while(dateTime < frameModels[p2Index].dateTime)
//             {
//                 p2Index--;
//                 if (p2Index < 0)
//                 {
//                     Debug.LogError("Не найден кадр с нужным временем");
//                     return false;
//                 }
//             }
//
//             if (p2Index - 2 < 0)
//             {
//                 Debug.LogError("Тут1");
//                 return false;
//             }
//             
//             if (p2Index + 1 > frameModels.Count - 1)
//             {
//                 Debug.LogError("Там1");
//                 return false;
//             }
//             
//             p3Frame = frameModels[p2Index + 1];
//             p2Frame = frameModels[p2Index];
//             p1Frame = frameModels[p2Index - 1];
//             p0Frame = frameModels[p2Index - 2];
//             return true;
//         }
//     }
// }