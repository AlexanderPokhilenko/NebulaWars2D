﻿using Code.Common.Logger;
using Code.Scenes.BattleScene.Experimental;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

//TODO большое говно
namespace Code.Scenes.BattleScene.Scripts
{
    /// <summary>
    /// Отвечает за переключение режимов ui. При старте подготавливает их для боя.
    /// Потом выключает ui для показа результатов боя.  
    /// </summary>
    [RequireComponent(typeof(LobbyLoaderController))]
    public class BattleUiController : MonoBehaviour
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(BattleUiController));
        #region Объекты для систем
        [SerializeField] private GameObject zoneGroup;
        [SerializeField] private GameObject overlayCanvas;
        [SerializeField] private GameObject gameViews;
        [SerializeField] private Joystick movementJoystick;
        [SerializeField] private Joystick attackJoystick;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject zone;
        [SerializeField] private MovingBackgroundInfo[] backgrounds;
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Text healthText;
        [SerializeField] private Slider shieldSlider;
        [SerializeField] private Text shieldText;
        [SerializeField] private Transform killsIndicatorContainer;
        [SerializeField] private KillInfoObject killMessage;
        [SerializeField] private Image arrowToCenter;
        [SerializeField] private Text killsText;
        [SerializeField] private Text aliveText;
        [SerializeField] private CannonCooldownsController cannonCooldownsController;
        [SerializeField] private CooldownInfo abilityCooldownInfo;
        [SerializeField] private Image loadingImage;
        [SerializeField] private VolumeProfile vignetteVolumeProfile;
        [SerializeField] private GameObject menuImage;
        [SerializeField] private Material nicknameFontMaterial;
        #endregion

        // private LobbyLoaderController lobbyLoaderController;
   
        private void Awake()
        {
            // lobbyLoaderController = GetComponent<LobbyLoaderController>();
            zoneGroup.SetActive(true);
            overlayCanvas.SetActive(true);
            gameViews.SetActive(true);
        }

        public void DisableZoneAndOverlayCanvas()
        {
            log.Info("DisableZoneAndOverlayCanvas start");
            zoneGroup.SetActive(false);
            overlayCanvas.SetActive(false);
            log.Info("DisableZoneAndOverlayCanvas end");
        }

        public void DisableGameViews()
        {
            gameViews.SetActive(false);
        }

        public GameObject GetGameViews() => gameViews;
        public Camera GetMainCamera() => mainCamera;
        public MovingBackgroundInfo[] GetBackgrounds() => backgrounds;
        public GameObject GetZone() => zone;
        public Joystick GetMovementJoystick() => movementJoystick;
        public Joystick GetAttackJoystick() => attackJoystick;
        public Slider GetHealthSlider() => healthSlider;
        public Text GetHealthText() => healthText;
        public Slider GetShieldSlider() => shieldSlider;
        public Text GetShieldText() => shieldText;
        public Transform GetKillIndicator() => killsIndicatorContainer;
        public KillInfoObject GetKillMessage() => killMessage;
        public Image GetArrowToCenter() => arrowToCenter;
        public Text GetKillsText() => killsText;
        public Text GetAliveText() => aliveText;
        public CannonCooldownsController GetCannonCooldownsController() => cannonCooldownsController;
        public CooldownInfo GetAbilityCooldownInfo() => abilityCooldownInfo;
        public Image GetLoadingImage() => loadingImage;
        public Vignette GetVignette() => vignetteVolumeProfile.TryGet(out Vignette vignette) ? vignette : null;
        public Material GetNicknameFontMaterial() => nicknameFontMaterial;
    }
}
