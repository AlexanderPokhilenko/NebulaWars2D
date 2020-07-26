using System;
using System.Collections.Generic;
using Code.Scenes.LootboxScene.Scripts;
using Entitas;
using UnityEngine;

namespace Code.Common.Experimental.SystemsOrderChecker
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
                .Add(new TestSystem1())
                .Add(new TestSystem2())
                ;

            Systems systems = systemsContainer.GetSystems();
        }
    }
}