// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using Code.Common;
// using UnityEngine;
//
// namespace Code.Scenes.Interpolation
// {
//     public class PositionsFactory:MonoBehaviour
//     {
//         private Thread thread;
//         private PositionUpdaterSystem positionUpdaterSystem;
//         private readonly List<FrameModel> frameModels = new FrameModelsFactory().Create();
//
//         private void Awake()
//         {
//             UnityThread.InitUnityThread();
//             positionUpdaterSystem = FindObjectOfType<PositionUpdaterSystem>();
//             thread = new Thread(async ()=>
//             {
//                 await EndlessPoint(frameModels);   
//             });
//         }
//
//         private void OnDrawGizmos()
//         {
//             Gizmos.color = Color.red;
//             for (int index = 0; index < frameModels.Count-1; index++)
//             {
//                 Vector2 t1 = frameModels[index].position;
//                 Vector2 t2 = frameModels[index + 1].position;
//                 Gizmos.DrawLine(t1, t2);
//             }
//         }
//
//         private void OnDestroy()
//         {
//             thread.Abort();
//             thread.Join();
//         }
//
//         private async Task EndlessPoint(List<FrameModel> list)
//         {
//             foreach (var frameModel in list)
//             {
//                 await Task.Delay(100);
//                 positionUpdaterSystem.AddFrame(frameModel);
//             }
//         }
//     }
// }