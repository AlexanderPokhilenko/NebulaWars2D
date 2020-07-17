using UnityEngine;

namespace Code.Common
{
    public class JoysticksManager : Singleton<JoysticksManager>
    {
        protected override bool DontDestroy { get; } = true;
        public JoystickType MovementType { get; set; }
        public JoystickType AttackType { get; set; }

        private void Start()
        {
            MovementType = (JoystickType)PlayerPrefs.GetInt(nameof(MovementType), (int)JoystickType.Fixed);
            AttackType = (JoystickType)PlayerPrefs.GetInt(nameof(AttackType), (int)JoystickType.Fixed);
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetInt(nameof(MovementType), (int)MovementType);
            PlayerPrefs.SetInt(nameof(AttackType), (int)AttackType);

            PlayerPrefs.Save();
        }
    }
}