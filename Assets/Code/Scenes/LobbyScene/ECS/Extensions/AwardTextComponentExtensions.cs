using System;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Components
{
    public static class AwardTextComponentExtensions
    {
        public static Vector3 CalculatePosition(this AwardTextComponent awardTextComponent, DateTime now)
        {
            return awardTextComponent.startPosition + new Vector3(0,80)
                *GetDistanceCoveragePercentage(awardTextComponent, now);
        }

        public static float GetDistanceCoveragePercentage(this AwardTextComponent awardTextComponent, DateTime now)
        {
            float distanceCoveragePercentage = (float) ((now - awardTextComponent.CreationTime).TotalMilliseconds
                                                        /
                                                        (awardTextComponent.FadeTime - awardTextComponent.CreationTime).TotalMilliseconds)
                ;
            return distanceCoveragePercentage;
        }
    }
}