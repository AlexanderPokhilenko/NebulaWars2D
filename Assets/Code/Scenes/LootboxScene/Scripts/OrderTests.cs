using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LootboxScene.Scripts
{
    public class TestSystem1 : IExecuteSystem, IRequireSystemsInvocationOrderChecker
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public List<Type> After()
        {
            return new List<Type>()
            {
                typeof(TestSystem2)
            };
        }
    }
    public class TestSystem2 : IExecuteSystem
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
    
    public class OrderTests : MonoBehaviour
    {
        private void Awake()
        {
            SystemsContainer systemsContainer = new SystemsContainer()
                .Add(new TestSystem2())
                .Add(new TestSystem1())
                ;

            Systems systems = systemsContainer.GetSystems();
        }
    }
}