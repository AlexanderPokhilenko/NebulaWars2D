using UnityEngine;
using UnityEngine.UI;

namespace Code.Common
{
    public class BaseMenuManager : Singleton<BaseMenuManager>
    {
        [Header("Слайдеры для настройки звуков")]
        [SerializeField] private Slider interfaceSlider;
        [SerializeField] private Slider soundsSlider;
        [SerializeField] private Slider musicSlider;
        private SoundManager soundManager;
        private UiSoundsManager uiSoundsManager;

        protected override void Awake()
        {
            base.Awake();

            soundManager = SoundManager.Instance();
            uiSoundsManager = UiSoundsManager.Instance();

            soundManager.LoadValues();
            interfaceSlider.value = soundManager.InterfaceVolume;
            soundsSlider.value = soundManager.SoundsVolume;
            musicSlider.value = soundManager.MusicVolume;
        }

        public void ShowMenu()
        {
            gameObject.SetActive(true);
            uiSoundsManager.PlayMenuOpen();
        }

        public void CloseMenu()
        {
            gameObject.SetActive(false);
            uiSoundsManager.PlayMenuClose();
        }

        public void SwitchMenu()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            uiSoundsManager.PlayMenu(gameObject.activeSelf);
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
    }
}