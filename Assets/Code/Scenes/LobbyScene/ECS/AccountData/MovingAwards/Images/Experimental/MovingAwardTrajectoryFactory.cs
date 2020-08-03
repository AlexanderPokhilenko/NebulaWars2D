using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common;
using UnityEngine;
using Random = System.Random;

namespace Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards.Images.Experimental
{
    /// <summary>
    /// Создаёт траекторию по которой должны двигаться награды.
    /// </summary>
    public class MovingAwardTrajectoryFactory
    {
        private static readonly TimeSpan DelayBeforeTheStartOfMovement = TimeSpan.FromMilliseconds(15);

        public List<ControlPoint> Create(int index, DateTime startSpawnTime, Vector3 spawnPosition, 
            Vector3 finalPointPosition, Random random, float screenHeight)
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

            List<ControlPoint> result = new List<ControlPoint>();
            
            //точка спавна. прозрачно
            result.Add(new ControlPoint
            {
                position = spawnPosition,
                arrivalTime = startSpawnTime,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 0
            });
            
            //точка спавна. не прозрачно
            result.Add(new ControlPoint
            {
                position = spawnPosition,
                arrivalTime = startSpawnTime + DelayBeforeTheStartOfMovement,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });
            
            //время ожидания на точке спавна
            //это нужно, чтобы награды по одной выходили из точки спавна
            TimeSpan delay1 = DelayBeforeTheStartOfMovement.Multiply(index);
            result.Add(new ControlPoint
            {
                position = spawnPosition,
                arrivalTime = result.Last().arrivalTime +delay1,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });
            
            //время на перемещение от спавна к новой точке
            TimeSpan delay2 = TimeSpan.FromSeconds(0.3);
            result.Add(new ControlPoint
            {
                position = spawnPosition + displacementVector,
                arrivalTime = result.Last().arrivalTime + delay2,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });

            //время ожидания рядом со спавном
            TimeSpan delay3 = TimeSpan.FromSeconds(0.2f);
            result.Add(new ControlPoint
            {
                position = spawnPosition + displacementVector,
                arrivalTime = result.Last().arrivalTime + delay3,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });

            //время на перемещение к финальной точке
            TimeSpan delay4 = TimeSpan.FromSeconds(0.8).Multiply(0.4+randomDouble3);
            result.Add(new ControlPoint
            {
                position = finalPointPosition,    
                arrivalTime = result.Last().arrivalTime + delay4,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });
            
            //время ожидания на финальной точке
            TimeSpan delay5 = DelayBeforeTheStartOfMovement.Multiply(16);
            result.Add(new ControlPoint
            {
                position = finalPointPosition,    
                arrivalTime = result.Last().arrivalTime + delay5,
                scale = new Vector3(1,1,1)*3/4,
                alpha = 1
            });

            //время на уменьшение размера
            //moveToUp нужен для того, чтобы картинка, которая начала уменьшаться на финальной точке вышла на
            //передний план. Если она уменьшается на заднем плане кажется, что награды просто зависли.
            TimeSpan delay6 = DelayBeforeTheStartOfMovement.Multiply(3);
            result.Add(new ControlPoint
            {
                position = finalPointPosition,    
                arrivalTime = result.Last().arrivalTime + delay6,
                scale = new Vector3(1,1,1)/2,
                alpha = 1,
                moveToUp = true
            });

            return result;   
        }
    }
}