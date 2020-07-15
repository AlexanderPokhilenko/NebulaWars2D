using System;
using System.Collections.Generic;
using System.Linq;
using Code.Scenes.LobbyScene.ECS.Components;
using UnityEngine;
using Random = System.Random;

namespace Code.Scenes.LobbyScene.ECS.Systems.Execute
{
    /// <summary>
    /// Создаёт траекторию по которой должны двигаться награды.
    /// </summary>
    public class MovingAwardControlPointsFactory
    {
        private readonly TimeSpan delayBeforeTheStartOfMovement = TimeSpan.FromMilliseconds(15);
        
        public List<ControlPoint> Create(int index, DateTime startSpawnTime, Vector3 spawnPosition, Vector3 finalPointPosition,
            Random random, float screenHeight)
        {
            //[0, 1]
            double randomDouble1 = random.NextDouble();
            double randomDouble2 = random.NextDouble();
            double randomDouble3 = random.NextDouble();
            
            //[0, 360]
            float angle = (float) randomDouble1*360;
            
            //вектор смещения от места спавна
            float vectorLength = (float) (screenHeight + screenHeight*randomDouble2/8);
            Vector3 straightVector = new Vector3(vectorLength, 0,0);
            Vector3 displacementVector = Quaternion.AngleAxis(angle, Vector3.forward) * straightVector;

            var result = new List<ControlPoint>();
            
            //точка спавна
            result.Add(new ControlPoint
            {
                position = spawnPosition,
                ArrivalTime = startSpawnTime,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 0
            });
            
            //точка спавна
            result.Add(new ControlPoint
            {
                position = spawnPosition,
                ArrivalTime = startSpawnTime + delayBeforeTheStartOfMovement,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });
            
            //время ожидания на точке спавна
            //это нужно, чтобы награды по одной выходили из точки спавна
            TimeSpan delay1 = delayBeforeTheStartOfMovement.Multiply(index);
            result.Add(new ControlPoint
            {
                position = spawnPosition,
                ArrivalTime = result.Last().ArrivalTime +delay1,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });
            
            //время на перемещение от спавна к новой точке
            TimeSpan delay2 = TimeSpan.FromSeconds(0.3);
            result.Add(new ControlPoint
            {
                position = spawnPosition + displacementVector,
                ArrivalTime = result.Last().ArrivalTime + delay2,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });

            //время ожидания рядом со спавном
            TimeSpan delay3 = TimeSpan.FromSeconds(0.2f);
            result.Add(new ControlPoint
            {
                position = spawnPosition + displacementVector,
                ArrivalTime = result.Last().ArrivalTime + delay3,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });

            //время на перемещение к финальной точке
            TimeSpan delay4 = TimeSpan.FromSeconds(0.8).Multiply(0.4+randomDouble3);
            result.Add(new ControlPoint
            {
                position = finalPointPosition,    
                ArrivalTime = result.Last().ArrivalTime + delay4,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });
            
            //время ожидания на финальной точке
            TimeSpan delay5 = delayBeforeTheStartOfMovement.Multiply(16);
            result.Add(new ControlPoint
            {
                position = finalPointPosition,    
                ArrivalTime = result.Last().ArrivalTime + delay5,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });

            //время на уменьшение размера
            //moveToUp нужен для того, чтобы картинка, которая начала уменьшаться на финальной точке вышла на
            //передний план. Если она уменьшается на заднем плане кажется, что награды просто зависли.
            TimeSpan delay6 = delayBeforeTheStartOfMovement.Multiply(3);
            result.Add(new ControlPoint
            {
                position = finalPointPosition,    
                ArrivalTime = result.Last().ArrivalTime + delay6,
                scale = new Vector3(1,1,1)/2,
                alpha = 1,
                moveToUp = true
            });

            return result;   
        }
    }
}