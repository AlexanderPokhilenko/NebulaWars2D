﻿using Code.Common.Logger;
using Entitas;
using System;
using UnityEngine;

namespace Code.Scenes.BattleScene.ECS.Systems.ViewSystems
{
    public class MoveTextSystem : IExecuteSystem
    {
        private readonly GameContext gameContext;
        private readonly IGroup<GameEntity> withText;
        private readonly ILog log = LogManager.CreateLogger(typeof(MoveTextSystem));
        
        public MoveTextSystem(Contexts contexts)
        {
            gameContext = contexts.game;
            withText = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.View,
                    GameMatcher.TextMeshPro,
                    GameMatcher.InfoDistance)
                .NoneOf(GameMatcher.Hidden));
        }

        public void Execute()
        {
            try
            {
                var playerEntity = gameContext.currentPlayerEntity;
                if(playerEntity == null || !playerEntity.hasView) return;
                var playerPosition = playerEntity.view.gameObject.transform.position;

                foreach (var e in withText)
                {
                    var currentTransform = e.view.gameObject.transform;
                    var nickDist = e.infoDistance.value;
                    var tmp = e.textMeshPro.value;
                    Vector3 direction;
                    if (e == playerEntity)
                    {
                        direction = Vector3.up;
                    }
                    else
                    {
                        var currentPosition = currentTransform.position;
                        direction = (currentPosition - playerPosition).normalized;
                    }
                
                    tmp.transform.localPosition = Quaternion.Inverse(currentTransform.rotation) * direction * nickDist;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message+" "+e.StackTrace);
            }
        }
    }
}