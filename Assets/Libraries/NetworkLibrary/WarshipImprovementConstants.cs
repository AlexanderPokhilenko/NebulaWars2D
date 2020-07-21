using System;
using NetworkLibrary.NetworkLibrary.Http;

namespace NetworkLibrary.NetworkLibrary
{
    public static class WarshipImprovementConstants
    {
        public const float HealthPointsCoefficient = 0.075f;
        public const float LinearVelocityCoefficient = 0.025f;
        public const float AngularVelocityCoefficient = 0.025f;
        public const float AttackCoefficient = 0.05f;

        public static float GetCoefficient(IncrementCoefficient incrementEnum)
        {
            switch (incrementEnum)
            {
                case IncrementCoefficient.None:
                    return 0f;
                case IncrementCoefficient.HealthPoints:
                    return HealthPointsCoefficient;
                case IncrementCoefficient.LinearVelocity:
                    return LinearVelocityCoefficient;
                case IncrementCoefficient.AngularVelocity:
                    return AngularVelocityCoefficient;
                case IncrementCoefficient.Attack:
                    return AttackCoefficient;
                default:
                    throw new ArgumentOutOfRangeException(nameof(incrementEnum), incrementEnum, "Неизвестный коэффициент.");
            }
        }
    }
}