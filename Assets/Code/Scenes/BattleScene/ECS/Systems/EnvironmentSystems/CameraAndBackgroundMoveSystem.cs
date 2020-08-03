using Code.Common;
using Code.Common.Storages;
using Code.Scenes.BattleScene.Experimental;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace Code.BattleScene.ECS.Systems
{
    public class CameraAndBackgroundMoveSystem : IExecuteSystem, ITearDownSystem
    {
        private readonly GameContext gameContext;
        private readonly Camera mainCamera;
        private readonly MovingBackgroundInfo[] backgrounds;
        private readonly Image loadingImage;
        private const float SmoothTime = 0.15f;
        private Vector3 cameraVelocity = Vector3.zero;

        public CameraAndBackgroundMoveSystem(Contexts contexts, Camera camera, MovingBackgroundInfo[] bgInfos, Image loadingScreen)
        {
            gameContext = contexts.game;
            mainCamera = camera;
            backgrounds = bgInfos;
            loadingImage = loadingScreen;
            foreach (var bgInfo in backgrounds)
            {
                var background = bgInfo.image;
                bgInfo.coefficient *= background.sprite.pixelsPerUnit / background.material.mainTexture.width;
            }
        }

        public void Execute()
        {
            var playerEntity = gameContext.GetEntityWithId(PlayerIdStorage.PlayerEntityId);
            if (playerEntity != null && playerEntity.hasTransform)
            {
                var position = playerEntity.transform.position;

                var transform = mainCamera.transform;
                var z = transform.position.z;
                var newPosition = Vector3.SmoothDamp(transform.position, new Vector3(position.x, position.y, z), ref cameraVelocity, SmoothTime);
                transform.position = newPosition;

                foreach (var (background, k) in backgrounds)
                {
                    background.material.mainTextureOffset = k * newPosition;
                }

                loadingImage.gameObject.SetActive(false);
            }
            else
            {
                loadingImage.gameObject.SetActive(true);
            }
        }

        public void TearDown()
        {
            loadingImage.gameObject.SetActive(true);
            foreach (var bgInfo in backgrounds)
            {
                bgInfo.image.material.mainTextureOffset = Vector2.zero;
            }
        }
    }
}