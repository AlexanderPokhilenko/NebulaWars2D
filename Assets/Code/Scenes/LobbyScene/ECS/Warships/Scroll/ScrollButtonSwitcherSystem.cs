using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Warships.Scroll
{
    /// <summary>
    /// Включает/выключает кнопки для лислания кораблей если в сторону больше нельзя листать.
    /// </summary>
    public class ScrollButtonSwitcherSystem:ReactiveSystem<GameEntity>
    {
        private readonly GameObject leftButton;
        private readonly GameObject rightButton;
        private readonly IGroup<GameEntity> withTransformGroup;
        private readonly LobbyUiContext lobbyUiContext;
        
        public ScrollButtonSwitcherSystem(Contexts contexts, GameObject leftButton, GameObject rightButton)
            : base(contexts.game)
        {
            lobbyUiContext = contexts.lobbyUi;
            withTransformGroup = contexts.game.GetGroup(GameMatcher.Transform);

            if (leftButton == null)
            {
                throw new NullReferenceException($"{nameof(leftButton)} was null");
            }

            if (rightButton == null)
            {
                throw new NullReferenceException($"{nameof(rightButton)} was null");
            }
            
            this.leftButton = leftButton;
            this.rightButton = rightButton;
        }
        
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Transform);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTransform;
        }

        protected override void Execute(List<GameEntity> _)
        {
            float minX = withTransformGroup.AsEnumerable().Min(entity => entity.transform.position.x);
            float maxX = withTransformGroup.AsEnumerable().Max(entity => entity.transform.position.x);
            
            //Если самый левый корабль по центру, то листать влево нельзя
            if (Math.Abs(minX) < 0.01)
            {
                if (!lobbyUiContext.isBlockWarshipsShiftToTheRight)
                {
                    leftButton.SetActive(false);
                    lobbyUiContext.isBlockWarshipsShiftToTheRight = true;
                }
            }
            else
            {
                leftButton.SetActive(true);
                if (lobbyUiContext.isBlockWarshipsShiftToTheRight)
                {
                    lobbyUiContext.isBlockWarshipsShiftToTheRight = false;
                }
            }
            
            //Если самый правый корабль по центру, то листать вправо нельзя
            if (Math.Abs(maxX) < 0.01)
            {
                if (!lobbyUiContext.isBlockWarshipsShiftToTheLeft)
                {
                    rightButton.SetActive(false);
                    lobbyUiContext.isBlockWarshipsShiftToTheLeft = true;
                }
            }
            else
            {
                rightButton.SetActive(true);
                if (lobbyUiContext.isBlockWarshipsShiftToTheLeft)
                {
                    lobbyUiContext.isBlockWarshipsShiftToTheLeft = false;
                }
            }
        }
    }
}