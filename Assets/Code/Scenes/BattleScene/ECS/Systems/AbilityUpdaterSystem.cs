﻿using Entitas;
using System;
using System.Collections.Generic;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.BattleScene.Experimental;
using Code.Scenes.BattleScene.Experimental.Approximation;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems
{
    public class AbilityUpdaterSystem : IExecuteSystem, ITearDownSystem
    {
        private static volatile float maxCooldown;
        private static volatile float currentCooldown;
        private static volatile bool maxCooldownWasChanged;
        private static volatile bool currentCooldownWasChanged;
        private readonly CooldownInfo _cooldownInfo;
        private readonly IApproximator<float> approximator;
        private readonly ILog log = LogManager.CreateLogger(typeof(AbilityUpdaterSystem));

        public AbilityUpdaterSystem(CooldownInfo abilityCooldownInfo, IApproximator<float> abilityCooldownApproximator)
        {
            if (abilityCooldownInfo == null)
            {
                throw new NullReferenceException($"{nameof(AbilityUpdaterSystem)} {nameof(abilityCooldownInfo)} was null");
            }

            approximator = abilityCooldownApproximator;

            approximator.Set(new Dictionary<ushort, float> { { 0, float.PositiveInfinity } }, Time.time - Time.deltaTime);
            approximator.Set(new Dictionary<ushort, float> { { 0, float.PositiveInfinity } }, Time.time);

            _cooldownInfo = abilityCooldownInfo;
        }
            
        public static void SetMaxCooldown(float maxCooldownArg)
        {
            maxCooldown = maxCooldownArg;
            maxCooldownWasChanged = true;
        }
        
        public static void SetCurrentCooldown(float cooldownArg)
        {
            currentCooldown = cooldownArg;
            currentCooldownWasChanged = true;
        }

        public void Execute()
        {
            if (maxCooldownWasChanged)
            {
                _cooldownInfo.Load(maxCooldown);
                maxCooldownWasChanged = false;
            }

            _cooldownInfo.SetCooldown(approximator.Get(Time.time)[0]);

            if (currentCooldownWasChanged)
            {
                approximator.Set(new Dictionary<ushort, float> {{0, currentCooldown}}, Time.time);
                currentCooldownWasChanged = false;
            }
        }

        public void TearDown()
        {
            approximator.Clear();
        }
    }
}