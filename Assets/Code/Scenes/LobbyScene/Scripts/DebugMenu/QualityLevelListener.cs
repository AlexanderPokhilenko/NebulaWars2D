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
        }

        private void SetQualityLevel(int levelIndex)
        {
            string levelName = QualitySettings.names[levelIndex];
            log.Debug("новый уровень "+levelName);
            QualitySettings.SetQualityLevel(levelIndex, true);
        }

    }
}