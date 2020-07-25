using System.Collections.Generic;
using Entitas;

namespace Code.Scenes.LootboxScene.Scripts
{
    public class SystemsContainer
    {
        private readonly List<ISystem> systems = new List<ISystem>();
        public SystemsContainer Add(ISystem system)
        {
            systems.Add(system);
            return this;
        }

        public Systems GetSystems()
        {
            Check();
            Systems result = new Systems();
            foreach (var system in systems)
            {
                result.Add(system);
            }

            return result;
        }
        
        private void Check()
        {
            var checker = new SystemsInvocationOrderChecker();
            checker.Check(systems);
        }
    }
}