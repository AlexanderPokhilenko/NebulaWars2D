using System;

namespace Code.Scenes.BattleScene.Udp
{
    public class EventProbability
    {
        private readonly Random random;
        private readonly int probability;

        public EventProbability(int probability)
        {
            this.probability = probability;
            random = new Random();
        }

        public bool IsEventHappened()
        {
            var tmpInt = random.Next(1, 101);
            return tmpInt < probability;
        }
    }
}