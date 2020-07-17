using Code.Common;
using Code.Scenes.BattleScene.Udp.Experimental;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.BattleScene.Scripts
{
    [RequireComponent(typeof(LobbyLoaderController))]
    [RequireComponent(typeof(BattleUiController))]
    public class BattleMenuUiController : MonoBehaviour
    {
        private BattleUiController battleUiController;
        private LobbyLoaderController lobbyLoaderController;
        private SoundManager soundManager;
        private UiSoundsManager uiSoundsManager;
        private UdpSendUtils udpSendUtils;
        [SerializeField] private Slider interfaceSlider;
        [SerializeField] private Slider soundsSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private VariableJoystick movementJoystick;
        [SerializeField] private VariableJoystick attackJoystick;
        [SerializeField] private GameObject movementLocked;
        [SerializeField] private GameObject movementUnlocked;
        [SerializeField] private GameObject attackLocked;
        [SerializeField] private GameObject attackUnlocked;
        private JoystickType movementType;
        private JoystickType attackType;

        private void Awake()
        {
            lobbyLoaderController = GetComponent<LobbyLoaderController>();
            battleUiController = GetComponent<BattleUiController>();

            soundManager = SoundManager.Instance();
            uiSoundsManager = UiSoundsManager.Instance();
            soundManager.LoadValues();
            interfaceSlider.value = soundManager.InterfaceVolume;
            soundsSlider.value = soundManager.SoundsVolume;
            musicSlider.value = soundManager.MusicVolume;

            movementType = (JoystickType)PlayerPrefs.GetInt(nameof(movementType), (int)JoystickType.Fixed);
            attackType = (JoystickType)PlayerPrefs.GetInt(nameof(attackType), (int)JoystickType.Fixed);
        }

        private void Start()
        {
            udpSendUtils = GetComponent<UdpController>().GetUdpSendUtils();

            StartCoroutine(LateStart(Time.deltaTime));
        }

        private IEnumerator LateStart(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            // какая-то зрада, но пока сойдёт
            movementJoystick.SetMode(movementType);
            attackJoystick.SetMode(attackType);
            if (movementType != JoystickType.Fixed)
            {
                movementLocked.SetActive(false);
                movementUnlocked.SetActive(true);
            }
            else
            {
                movementType = JoystickType.Fixed;
                movementLocked.SetActive(true);
                movementUnlocked.SetActive(false);
            }
            if (attackType != JoystickType.Fixed)
            {
                attackLocked.SetActive(false);
                attackUnlocked.SetActive(true);
            }
            else
            {
                attackType = JoystickType.Fixed;
                attackLocked.SetActive(true);
                attackUnlocked.SetActive(false);
            }
        }

        public void Button_ShowMenu_Click()
        {
            battleUiController.ShowMenu();
        }

        public void Button_CloseMenu_Click()
        {
            battleUiController.CloseMenu();
        }
   
        public void Button_Exit_Click()
        {
            new StubBattleExitHelper().StubNotifyGameServerAsync(udpSendUtils).ConfigureAwait(false);
            uiSoundsManager.PlayStop();
            lobbyLoaderController.LoadLobbyScene();
        }

        public void Interface_Slider_OnChange(float value)
        {
            soundManager.InterfaceVolume = value;
            uiSoundsManager.PlayClick();
        }

        public void Sounds_Slider_OnChange(float value)
        {
            soundManager.SoundsVolume = value;
            uiSoundsManager.PlayClick();
        }

        public void Music_Slider_OnChange(float value)
        {
            soundManager.MusicVolume = value;
            uiSoundsManager.PlayClick();
        }

        public void Button_Lock_Movement_Click()
        {
            uiSoundsManager.PlayClick();
            if (movementType == JoystickType.Fixed)
            {
                movementType = JoystickType.Dynamic;
                movementLocked.SetActive(false);
                movementUnlocked.SetActive(true);
            }
            else
            {
                movementType = JoystickType.Fixed;
                movementLocked.SetActive(true);
                movementUnlocked.SetActive(false);
            }

            movementJoystick.SetMode(movementType);
        }

        public void Button_Lock_Attack_Click()
        {
            uiSoundsManager.PlayClick();
            if (attackType == JoystickType.Fixed)
            {
                attackType = JoystickType.Dynamic;
                attackLocked.SetActive(false);
                attackUnlocked.SetActive(true);
            }
            else
            {
                attackType = JoystickType.Fixed;
                attackLocked.SetActive(true);
                attackUnlocked.SetActive(false);
            }

            attackJoystick.SetMode(attackType);
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetInt(nameof(movementType), (int)movementType);
            PlayerPrefs.SetInt(nameof(attackType), (int)attackType);

            PlayerPrefs.Save();
        }
    }
}