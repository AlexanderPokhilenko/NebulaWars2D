using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Scenes.LobbyScene.ECS;
using UnityEngine;
using Random = System.Random;

namespace Code.Scenes.LootboxScene.PrefabScripts.Wpp
{
    public class WppIconTrajectoryFactory
    {
        private static readonly TimeSpan DelayBeforeTheStartOfMovement = TimeSpan.FromMilliseconds(20);
        private const float Scale = 0.75F;
        public List<ControlPoint> Create( int index, DateTime startSpawnTime, Vector3 spawnPosition, 
            Vector3 finalPointPosition, Random random)
        {
            //[0, 1]
            double randomDouble3 = random.NextDouble();
            
            //вторая точка
            Vector3 secondPoint = GetSecondPoint(random, spawnPosition);
            List<ControlPoint> result = new List<ControlPoint>();
            
            //точка спавна. прозрачно
            result.Add(new ControlPoint
            {
                position = spawnPosition,
                arrivalTime = startSpawnTime,
                scale = Vector3.one*Scale,
                alpha = 0
            });
            
        
            //время ожидания на точке спавна
            //это нужно, чтобы награды по одной выходили из точки спавна
            TimeSpan delay1 = DelayBeforeTheStartOfMovement.Multiply(index);
            result.Add(new ControlPoint
            {
                position = spawnPosition,
                arrivalTime = result.Last().arrivalTime +delay1,
                scale = Vector3.one*Scale,
                alpha = 0
            });
            
            //время на перемещение ко второй точке
            TimeSpan delay2 = TimeSpan.FromSeconds(0.5);
            result.Add(new ControlPoint
            {
                position = secondPoint,
                arrivalTime = result.Last().arrivalTime + delay2,
                scale = Vector3.one*Scale,
                alpha = 1
            });

            //время ожидания на второй точке
            TimeSpan delay3 = TimeSpan.FromSeconds(0.2f);
            result.Add(new ControlPoint
            {
                position = secondPoint,
                arrivalTime = result.Last().arrivalTime + delay3,
                scale = Vector3.one*Scale,
                alpha = 1
            });

            //время на перемещение к финишу
            TimeSpan delay4 = TimeSpan.FromSeconds(0.8).Multiply(0.4+randomDouble3);
            result.Add(new ControlPoint
            {
                position = finalPointPosition,    
                arrivalTime = result.Last().arrivalTime + delay4,
                scale = Vector3.one*Scale,
                alpha = 1
            });
            
            //время ожидания на финише
            TimeSpan delay5 = DelayBeforeTheStartOfMovement.Multiply(2);
            result.Add(new ControlPoint
            {
                position = finalPointPosition,    
                arrivalTime = result.Last().arrivalTime + delay5,
                scale = Vector3.one*Scale,
                alpha = 1
            });

            //время на уменьшение размера
            //moveToUp нужен для того, чтобы картинка, которая начала уменьшаться на финальной точке вышла на
            //передний план. Если она уменьшается на заднем плане кажется, что награды просто зависли.
            TimeSpan delay6 = DelayBeforeTheStartOfMovement;
            result.Add(new ControlPoint
            {
                position = finalPointPosition,    
                arrivalTime = result.Last().arrivalTime + delay6,
                scale = Vector3.one*Scale/4,
                alpha = 1,
                moveToUp = true
            });

            return result;
        }
        
        private Vector3 GetSecondPoint(Random random, Vector3 spawnPosition)
        {
            float distanceFromCenter = 200;
            float randomAngle = (float) (random.NextDouble() * 2 * Mathf.PI);
            float x = Mathf.Sin(randomAngle)*distanceFromCenter+spawnPosition.x;
            float y = Mathf.Cos(randomAngle)*distanceFromCenter+spawnPosition.y;
            Vector3 secondPoint = new Vector3(x, y);
            return secondPoint;
        }
    }
}