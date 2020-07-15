using Code.BattleScene.ECS.Systems;
using Code.Common;
using Code.Scenes.BattleScene.ECS.Systems;
using Code.Scenes.BattleScene.ECS.Systems.NetworkSenderSystems;
using Code.Scenes.BattleScene.ECS.Systems.TearDownSystems;
using Code.Scenes.BattleScene.ECS.Systems.ViewSystems;
using Code.Scenes.BattleScene.Experimental.Approximation;
using Code.Scenes.BattleScene.Udp.Experimental;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Code.Scenes.BattleScene.Scripts
{
    /// <summary>
    /// Отвечает за управление ecs системами.
    /// </summary>
    [RequireComponent(typeof(BattleUiController))]
    public class EcsController:MonoBehaviour
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(EcsController));
        
        private Systems systems;
        private bool abilityButtonIsPressed;
        private UdpController udpControllerSingleton;
        private BattleUiController battleUiController;
        private readonly object lockObj = new object();
        
        private void Awake()
        {
            udpControllerSingleton = GetComponent<UdpController>();
            battleUiController = GetComponent<BattleUiController>();
        }

        private void Start()
        {
            UdpSendUtils udpSendUtils = udpControllerSingleton.GetUdpSendUtils();
            systems = CreateSystems(udpSendUtils);
            Contexts.sharedInstance.game.SetZoneInfo(Vector2.zero, 10f);
            systems.ActivateReactiveSystems();
            systems.Initialize();
        }
        
        private void Update()
        {
            //Возможно, стоит это вынести отдельно
            contexts.input.isTryingToUseAbility = abilityButtonIsPressed;
#if UNITY_EDITOR_WIN
            contexts.input.isTryingToUseAbility |= Input.GetKey(KeyCode.Space);
#endif
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                battleUiController.SwitchMenu();
            }

            systems.Execute();
            systems.Cleanup();
        }

        private void OnDestroy()
        {
            systems.DeactivateReactiveSystems();
            systems.TearDown();
            systems.ClearReactiveSystems();
        }

        private Contexts contexts;
        private Systems CreateSystems(UdpSendUtils udpSendUtils)
        {
            var prevFrameTime = Time.time - Time.deltaTime;
            int aliveCount = MyMatchDataStorage.Instance.GetMatchModel().PlayerModels.Length;

            udpControllerSingleton.GetUdpSendUtils();
            
            contexts = Contexts.sharedInstance;
            systems = new Systems()
                    .Add(new UpdateTransformSystem(contexts))
                    .Add(new UpdateRadiusSystem(contexts, new FloatLinearInterpolator(prevFrameTime)))
                    .Add(new UpdateParentsSystem(contexts))
                    .Add(new DetachParentsSystem(contexts))
                    .Add(new UpdateHidingSystem(contexts))

                    .Add(new GlobalTransformSystem(contexts))
                    .Add(new UpdatePlayersSystem(contexts))

                    .Add(new AddViewSystem(contexts, battleUiController.GetGameViews()))
                    .Add(new RenderSpriteSystem(contexts))
                    .Add(new RenderCircleSystem(contexts))
                    .Add(new RenderLineSystem(contexts))
                    .Add(new AddNicknameDistanceSystem(contexts))
                    .Add(new AddTextSystem(contexts, battleUiController.GetNicknameFontMaterial()))
                    .Add(new SetAnimatorSystem(contexts))
                    .Add(new GameObjectParentsCheckerSystem(contexts))
                    .Add(new GameObjectDetachParentsSystem(contexts, battleUiController.GetGameViews()))
                    .Add(new RenderLocalTransformSystem(contexts))
                    .Add(new AddSpeedSystem(contexts))
                    .Add(new RenderSmoothedTransformSystem(contexts))
                    .Add(new RotateTextSystem(contexts))
                    .Add(new MoveTextSystem(contexts))

                    .Add(new UpdateParticlesSystem(contexts))

                    .Add(new UpdateDestroysSystem(contexts))

                    .Add(new GameObjectHidingSystem(contexts))

                    .Add(new SpawnSoundSystem(contexts))
                    //LoopSoundSystem?
                    .Add(new DeathSoundSystem(contexts))

                    .Add(new DeathAnimationSystem(contexts))
                    .Add(new DestroyTimerSubtractionSystem(contexts))
                    .Add(new DestroySystem(contexts))

                    .Add(new CameraAndBackgroundMoveSystem(contexts, battleUiController.GetMainCamera(),
                        battleUiController.GetBackgrounds(), battleUiController.GetLoadingImage()))
                    .Add(new MaterialsMoveSystem(contexts, battleUiController.GetMaterials()))
                    .Add(new ZoneMoveSystem(contexts, battleUiController.GetZone()))
                    .Add(new UpdateDirectionToCenterSystem(contexts, battleUiController.GetArrowToCenter()))
                    .Add(new JoysticksInputSystem(contexts, battleUiController.GetMovementJoystick(),
                        battleUiController.GetAttackJoystick()))
                    .Add(new PlayerInputSenderSystem(contexts, udpSendUtils))
                    .Add(new AbilityInputClearingSystem(contexts))
                    .Add(new RudpMessagesSenderSystem(udpSendUtils))
                    .Add(new HealthAndShieldPointsUpdaterSystem(battleUiController.GetHealthSlider(),
                        battleUiController.GetHealthText(), battleUiController.GetShieldSlider(),
                        battleUiController.GetShieldText(), new FloatLinearInterpolator(prevFrameTime),
                                battleUiController.GetVignette()))
                     .Add(new KillsIndicatorSystem(battleUiController.GetKillMessage(), battleUiController.GetKillIndicator(), battleUiController.GetKillsText(), battleUiController.GetAliveText(), aliveCount))
                    .Add(new CooldownsUpdaterSystem(battleUiController.GetCannonCooldownsController(), new FloatLinearInterpolator(prevFrameTime)))
                    .Add(new AbilityUpdaterSystem(battleUiController.GetAbilityCooldownInfo(), new FloatLinearInterpolator(prevFrameTime)))
                    .Add(new ContextsClearSystem(contexts))
                ;
            return systems;
        }

        public void AbilityButton_OnPointerDown()
        {
            abilityButtonIsPressed = true;
        }

        public void AbilityButton_OnPointerUp()
        {
            abilityButtonIsPressed = false;
        }

        /// <summary>
        /// Это говно нужно для спавна кораблика в окне показа наград после боя.
        /// </summary>
        public void EnablePassiveMode()
        {
            lock(lockObj)
            {
                StopBattleSystems();
                ResetSystems();   
            }
        }
        
        private void StopBattleSystems()
        {
            systems.DeactivateReactiveSystems();
            systems.TearDown();
            systems.ClearReactiveSystems();
        }

        /// <summary>
        /// Это говно нужно для спавна кораблика в окне показа наград после боя.
        /// </summary>
        private void ResetSystems()
        {
            systems = new Systems()
                .Add(new AddViewSystem(contexts, battleUiController.GetGameViews()))
                .Add(new RenderSpriteSystem(contexts))
                .Add(new RenderCircleSystem(contexts))
                .Add(new RenderLineSystem(contexts))
                .Add(new SetAnimatorSystem(contexts))
                .Add(new UpdateParticlesSystem(contexts))
                .Add(new RenderTransformSystem(contexts))
                .Add(new ContextsClearSystem(contexts));
        }
        
        public void DeleteAllGameEntities()
        {
            var allGameEntities = contexts.game.GetEntities();
            foreach (var entity in allGameEntities)
            {
                Debug.Log("Удаление сущности ");
                if (entity.hasView)
                {
                    var go = entity.view.gameObject;
                    if (go != null)
                    {
                        go.Unlink();
                        Destroy(go);   
                    }
                }
                entity.Destroy();
            }
            // contexts.game.SetZoneInfo(new Vector2(int.MaxValue, int.MaxValue), 0);
        }
    }
}