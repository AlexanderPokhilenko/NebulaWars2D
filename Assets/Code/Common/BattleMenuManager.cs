using UnityEngine;

namespace Code.Common
{
    [RequireComponent(typeof(BaseMenuManager))]
    public class BattleMenuManager : Singleton<BattleMenuManager>
    {
        [Header("Объекты \"замков\" для движения")]
        [SerializeField] private GameObject movementLocked;
        [SerializeField] private GameObject movementUnlocked;
        [Header("Объекты \"замков\" для атаки")]
        [SerializeField] private GameObject attackLocked;
        [SerializeField] private GameObject attackUnlocked;
        private JoysticksManager joysticksManager;
        private UiSoundsManager uiSoundsManager;

        protected override void Awake()
        {
            base.Awake();

            joysticksManager = JoysticksManager.Instance();
            uiSoundsManager = UiSoundsManager.Instance();

            if (joysticksManager.MovementType != JoystickType.Fixed)
            {
                movementLocked.SetActive(false);
                movementUnlocked.SetActive(true);
            }
            else
            {
                movementLocked.SetActive(true);
                movementUnlocked.SetActive(false);
            }
            if (joysticksManager.AttackType != JoystickType.Fixed)
            {
                attackLocked.SetActive(false);
                attackUnlocked.SetActive(true);
            }
            else
            {
                attackLocked.SetActive(true);
                attackUnlocked.SetActive(false);
            }
        }

        public void Button_Lock_Movement_Click()
        {
            if (joysticksManager.MovementType == JoystickType.Fixed)
            {
                joysticksManager.MovementType = JoystickType.Dynamic;
                movementLocked.SetActive(false);
                movementUnlocked.SetActive(true);
            }
            else
            {
                joysticksManager.MovementType = JoystickType.Fixed;
                movementLocked.SetActive(true);
                movementUnlocked.SetActive(false);
            }
            uiSoundsManager.PlayClick();
        }

        public void Button_Lock_Attack_Click()
        {
            if (joysticksManager.AttackType == JoystickType.Fixed)
            {
                joysticksManager.AttackType = JoystickType.Dynamic;
                attackLocked.SetActive(false);
                attackUnlocked.SetActive(true);
            }
            else
            {
                joysticksManager.AttackType = JoystickType.Fixed;
                attackLocked.SetActive(true);
                attackUnlocked.SetActive(false);
            }
            uiSoundsManager.PlayClick();
        }
    }
}