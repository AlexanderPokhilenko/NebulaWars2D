﻿using Code.Scenes.BattleScene.ECS.Components.Game.TimerComponents;
using Code.Scenes.BattleScene.Experimental;
using Code.Scenes.BattleScene.ScriptableObjects;
using Entitas;
using NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Code.BattleScene.ECS.Systems
{
    /// <summary>
    /// Создаёт/Обновляет значение компонета позиции игрового объекта, если есть новое сообщение от сервера.
    /// </summary>
    public class UpdateTransformSystem : IExecuteSystem
    {
        private static readonly object LockObj = new object();
        private static Dictionary<ushort, ViewTransform> _transforms = new Dictionary<ushort, ViewTransform>();
        private static uint _lastMessageId;
        private static bool WasProcessed = true;
        private readonly GameContext gameContext;
        private readonly IGroup<GameEntity> gameEntitiesGroup;
        private readonly List<GameEntity> buffer;
        private const int predictedCapacity = 128;
        private const float TimeDelay = ClientTimeManager.TimeDelay;

        public UpdateTransformSystem(Contexts contexts)
        {
            gameContext = contexts.game;
            gameEntitiesGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Direction));
            buffer = new List<GameEntity>(predictedCapacity);
            _lastMessageId = 0;
            WasProcessed = true;
            _transforms.Clear();
        }

        public static void SetNewTransforms(uint messageId, Dictionary<ushort, ViewTransform> values)
        {
            lock (LockObj)
            {
                if (WasProcessed)
                {
                    _transforms = values;
                    WasProcessed = false;
                }
                else
                {
                    if (messageId > _lastMessageId)
                    {
                        foreach (var pair in values)
                        {
                            _transforms[pair.Key] = pair.Value;
                        }

                        _lastMessageId = messageId;
                    }
                    else
                    {
                        foreach (var pair in _transforms)
                        {
                            values[pair.Key] = pair.Value;
                        }

                        _transforms = values;
                    }
                }
            }
        }

        public void Execute()
        {
            Dictionary<ushort, ViewTransform> viewTransforms;
            lock (LockObj)
            {
                if (WasProcessed) return;
                WasProcessed = true;
                viewTransforms = new Dictionary<ushort, ViewTransform>(_transforms);
            }

            //Зона всегда является объектом с id = 0
            if (viewTransforms.TryGetValue(0, out var zoneTransform))
            {
                if (gameContext.hasZoneInfo)
                {
                    gameContext.zoneInfo.position = zoneTransform.GetPosition();
                }
            }

            //Перебор локальных сущностей
            foreach (var gameEntity in gameEntitiesGroup.GetEntities(buffer))
            {
                ushort currentId = gameEntity.id.value;
                bool thereIsThisObject = viewTransforms.ContainsKey(currentId);
                if (thereIsThisObject)
                {
                    //Объект остался
                    UpdateTransform(gameEntity, viewTransforms[currentId]);
                    //Пометка того, что объект обработан
                    viewTransforms.Remove(currentId);
                }
            }

            //Добавление новых объектов
            foreach (var newEntity in viewTransforms.OrderBy(pair => pair.Key))
            {
                AddNewObject(newEntity.Key, newEntity.Value);
            }
        }

        private void AddNewObject(ushort id, ViewTransform newTransform)
        {
            var newObject = gameContext.CreateEntity();
            newObject.AddId(id);
            newObject.AddViewType(newTransform.typeId);
            if (newTransform.typeId == ViewTypeId.Shield) newObject.isShield = true;
            newObject.AddDelayedSpawn(newTransform.typeId, newTransform.X, newTransform.Y, newTransform.Angle, TimeDelay);
            newObject.AddPosition(new Vector3(newTransform.X, newTransform.Y, -0.00001f * id));
            newObject.AddDirection(newTransform.Angle);
        }

        private static void UpdateTransform(GameEntity entity, ViewTransform newTransform)
        {
            entity.isHidden = false;
            entity.ReplacePosition(new Vector3(newTransform.X, newTransform.Y, entity.position.value.z));
            entity.ReplaceDirection(newTransform.Angle);
            var oldViewType = entity.viewType.id;
            if (oldViewType != newTransform.typeId)
            {
                entity.isShield = newTransform.typeId == ViewTypeId.Shield;
                var timeDelay = TimeDelay;
                if (ViewObjectsBase.Instance.GetViewObject(oldViewType).TryGetDeathDelay(out var deathDelay))
                {
                    timeDelay -= deathDelay;
                }
                entity.ReplaceViewType(newTransform.typeId);
                if (entity.hasDelayedRecreation)
                {
                    var component = new DelayedRecreationComponent
                    {
                        typeId = newTransform.typeId,
                        positionX = newTransform.X,
                        positionY = newTransform.Y,
                        direction = newTransform.Angle,
                        time = timeDelay
                    };
                    if (entity.hasManyDelayedRecreations)
                    {
                        entity.manyDelayedRecreations.components.Enqueue(component);
                    }
                    else
                    {
                        var queue = new Queue<DelayedRecreationComponent>();
                        queue.Enqueue(component);

                        entity.AddManyDelayedRecreations(queue);
                    }
                }
                else
                {
                    entity.AddDelayedRecreation(newTransform.typeId, newTransform.X, newTransform.Y, newTransform.Angle, timeDelay);
                }
            }
        }
    }
}