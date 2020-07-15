using System;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Extensions
{
    public static class MovingAwardComponentExtension
    {
        public static DateTime GetCurrentTargetArrivalTime(this MovingAwardComponent movingAward)
        {
            return movingAward.controlPoints[movingAward.currentTargetIndex].ArrivalTime;
        }
        
        public static Vector3 GetCurrentTargetPoint(this MovingAwardComponent movingAward)
        {
            return movingAward.controlPoints[movingAward.currentTargetIndex].position;
        }

        public static bool IsRaiseUpNeeded(this MovingAwardComponent movingAwardComponent)
        {
            return movingAwardComponent.controlPoints[movingAwardComponent.currentTargetIndex].moveToUp;
        }

        public static void TurnOffRaiseUp(this MovingAwardComponent movingAwardComponent)
        {
            movingAwardComponent.controlPoints[movingAwardComponent.currentTargetIndex].moveToUp = false;
        }

        private static DateTime GetCurrentLineStartTime(this MovingAwardComponent movingAward)
        {
            return movingAward.controlPoints[movingAward.currentTargetIndex-1].ArrivalTime;
        }

        private static Vector3 GetCurrentLineStartPosition(this MovingAwardComponent movingAward)
        {
            return movingAward.controlPoints[movingAward.currentTargetIndex-1].position;
        }

        private static float GetPercentageOfCoveredDistance(this MovingAwardComponent movingAward, DateTime now)
        {
            return (float) ((now - movingAward.GetCurrentLineStartTime()).TotalMilliseconds
                            /
                            (movingAward.GetCurrentTargetArrivalTime() - movingAward.GetCurrentLineStartTime()).TotalMilliseconds);
        }

        private static Vector3 GetDeltaVector3(this MovingAwardComponent movingAward)
        {
            return movingAward.GetCurrentTargetPoint() - movingAward.controlPoints[movingAward.currentTargetIndex - 1].position;
        }

        public static Vector3 CalculateScale(this MovingAwardComponent movingAward,DateTime now)
        {
            var deltaScale = movingAward.controlPoints[movingAward.currentTargetIndex].scale 
                             - movingAward.controlPoints[movingAward.currentTargetIndex - 1].scale;
            return movingAward.controlPoints[movingAward.currentTargetIndex - 1].scale + movingAward.GetPercentageOfCoveredDistance(now) * deltaScale;
        }

        public static float CalculateAlpha(this MovingAwardComponent movingAward, DateTime now)
        {
            float deltaAlpha = movingAward.controlPoints[movingAward.currentTargetIndex].alpha - movingAward.controlPoints[movingAward.currentTargetIndex - 1].alpha;
            return movingAward.controlPoints[movingAward.currentTargetIndex - 1].alpha + movingAward.GetPercentageOfCoveredDistance(now) * deltaAlpha;
        }

        public static Vector3 CalculatePosition(this MovingAwardComponent movingAward, DateTime now)
        {
            Vector3 deltaPositionForTime = movingAward.GetDeltaVector3() * 
                                           movingAward.GetPercentageOfCoveredDistance(now);
            return movingAward.GetCurrentLineStartPosition() +  deltaPositionForTime;
        }
    }
}