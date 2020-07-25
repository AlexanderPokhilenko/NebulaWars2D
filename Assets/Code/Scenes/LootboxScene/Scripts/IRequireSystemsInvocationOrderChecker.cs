using System;
using System.Collections.Generic;

namespace Code.Scenes.LootboxScene.Scripts
{
    public interface IRequireSystemsInvocationOrderChecker
    {
        List<Type> After();
    }
}