using System;
using System.Collections.Generic;
using Code.Scenes.LootboxScene.Scripts;
using Entitas;
using UnityEngine;

namespace Code.Common.Experimental.SystemsOrderChecker
{
   
    
    public class OrderTests : MonoBehaviour
    {
        private void Awake()
        {
            SystemsContainer systemsContainer = new SystemsContainer()
                // .Add(new TestSystem1())
                // .Add(new TestSystem2())
                ;

            Systems systems = systemsContainer.GetSystems();
        }
    }
}