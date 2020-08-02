using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Logger;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.Scripts.DebugMenu
{
    public class QualityLevelListener : MonoBehaviour
    {
        private int MaxDivider;
        private int ResolutionMultiplier;
        private readonly ILog log = LogManager.CreateLogger(typeof(QualityLevelListener));

        private void Awake()
        {
            var uiStorage = FindObjectOfType<DebugMenuUiStorage>();
            List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
            foreach (var qualityLevelName in QualitySettings.names)
            {
                options.Add(new Dropdown.OptionData(qualityLevelName));
            }

            uiStorage.dropdown.options = options;

            uiStorage.dropdown.onValueChanged.AddListener(SetQualityLevel);

            uiStorage.dropdown.value = QualitySettings.GetQualityLevel();
            log.Debug("текущее значение "+QualitySettings.names[QualitySettings.GetQualityLevel()]);

            var resolution = Screen.currentResolution;
            var width = resolution.width;
            var height = resolution.height;
            MaxDivider = GCD(width, height);

            ResolutionMultiplier = PlayerPrefs.GetInt(nameof(ResolutionMultiplier), MaxDivider);
            log.Debug(ResolutionMultiplier);

            var slider = uiStorage.slider;
            slider.maxValue = MaxDivider;
            slider.value = ResolutionMultiplier;
        }

        private void OnDestroy()
        {
            log.Debug(nameof(OnDestroy));
            PlayerPrefs.SetInt(nameof(ResolutionMultiplier), ResolutionMultiplier);
            PlayerPrefs.Save();
        }

        private void SetResolution(int value)
        {
            ResolutionMultiplier = value;
            var resolution = Screen.currentResolution;
            var width = resolution.width;
            var height = resolution.height;
            Screen.SetResolution(width * ResolutionMultiplier / MaxDivider, height * ResolutionMultiplier / MaxDivider, true);
        }

        public void OnResolutionChanged(float value)
        {
            SetResolution((int)value);
        }

        private void SetQualityLevel(int levelIndex)
        {
            string levelName = QualitySettings.names[levelIndex];
            log.Debug("новый уровень "+levelName);
            QualitySettings.SetQualityLevel(levelIndex, true);
        }
        /// <summary>
        /// Наибольший общий делитель двух чисел.
        /// </summary>
        /// <param name="a">Первое число.</param>
        /// <param name="b">Второе число.</param>
        /// <returns>НОД двух чисел.</returns>
        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }
    }
}