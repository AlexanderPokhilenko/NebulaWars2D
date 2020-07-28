using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Code.Common.Experimental.SystemsOrderChecker
{
    public class SystemsInvocationOrderChecker
    {
        public void Check(List<ISystem> systems)
        {
            foreach (ISystem system in systems)
            {
                if (system is IRequireSystemsInvocationOrderChecker test)
                {
                    List<Type> afterTypes = test.After();
                    if (afterTypes != null && afterTypes.Count!=0)
                    {
                        //проверить слудующие системы
                        int currentSystemsIndex = systems.IndexOf(system);
                        List<ISystem> afterSystems = systems.Skip(currentSystemsIndex).ToList(); 
                        
                        CheckSegment(afterSystems, afterTypes);
                    }
                }
            }
        } 
        
        private void CheckSegment(List<ISystem> systems, List<Type> types)
        {
            Type currentType = types.First();
            foreach (var system in systems)
            {
                if (system.GetType() == currentType)
                {
                    types.Remove(currentType);
                    currentType = types.FirstOrDefault();
                    if (currentType == null)
                    {
                        break;
                    }
                }
            }

            if (types.Count != 0)
            {
                Debug.LogError($"Список названий систем, которые не удалось найти после системы {systems.First().GetType().Name} :");
                foreach (Type remainingType in types)
                {
                    Debug.LogError(remainingType.Name);
                }
                throw new Exception("Порядок вызова систем неверный. ");
            }
        }
    }
}