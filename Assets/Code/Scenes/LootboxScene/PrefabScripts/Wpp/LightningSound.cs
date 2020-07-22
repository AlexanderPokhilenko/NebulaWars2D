using System;
using Code.Common;
using Code.Common.Logger;
using UnityEngine;

namespace Code.Scenes.LootboxScene.PrefabScripts.Wpp
{
    [RequireComponent(typeof(AudioSource))]
    public class LightningSound : MonoBehaviour
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(LightningSound));
        
        private void Awake()
        {
            log.Debug("Запуск звука молнии 1");
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                throw new NullReferenceException(nameof(audioSource));
            }

            if (audioSource.clip==null)
            {
                throw new NullReferenceException(nameof(audioSource.clip));
            }

            audioSource.volume = SoundManager.Instance().InterfaceVolume;
            
            log.Debug("Запуск звука молнии 2");
        }
    }
}