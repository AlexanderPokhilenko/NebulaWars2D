using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Common
{
    [RequireComponent(typeof(AudioSource))]
    public class UiSoundsManager : Singleton<UiSoundsManager>
    {
        protected override bool DontDestroy { get; } = true;
        [SerializeField] private AudioClip adding;
        [SerializeField] private AudioClip click;
        [SerializeField] private AudioClip error;
        [SerializeField] private AudioClip hardAdding;
        [SerializeField] private AudioClip levelUp;
        [SerializeField] private AudioClip lootbox;
        [SerializeField] private AudioClip menuOpen;
        [SerializeField] private AudioClip pointsAdding;
        [SerializeField] private AudioClip purchase;
        [SerializeField] private AudioClip ratingAdding;
        [SerializeField] private AudioClip softAdding;
        [SerializeField] private AudioClip start;
        [SerializeField] private AudioClip warshipChanging;
        [SerializeField] private AudioClip lightning;
        [SerializeField] private AudioClip wpp01;
        [SerializeField] private AudioClip wpp02;
        [SerializeField] private AudioClip wpp03;
        private SoundManager soundManager;
        private AudioSource mainAudioSource;

        protected override void Awake()
        {
            mainAudioSource = GetComponent<AudioSource>();
            soundManager = SoundManager.Instance();
        }

        private void PlaySound(AudioSource source, AudioClip clip)
        {
            soundManager.PlayUiSound(source, clip, false);
        }

        private void PlaySoundReversed(AudioSource source, AudioClip clip)
        {
            soundManager.PlayUiSound(source, clip, true);
        }

        private void PlayOneShot(AudioSource source, AudioClip clip)
        {
            soundManager.PlaySameUiSound(source, clip);
        }
        
        public void PlayAdding() => PlaySound(mainAudioSource, adding);
        public void PlayClick() => PlaySound(mainAudioSource, click);
        public void PlayError() => PlayOneShot(mainAudioSource, error);
        public void PlayHardAdding() => PlayOneShot(mainAudioSource, hardAdding);
        public void PlayLevelUp() => PlaySound(mainAudioSource, levelUp);
        public void PlayLootbox() => PlaySound(mainAudioSource, lootbox);
        public void PlayMenu(bool closing) => soundManager.PlayUiSound(mainAudioSource, menuOpen, closing);
        public void PlayMenuOpen() => PlaySound(mainAudioSource, menuOpen);
        public void PlayMenuClose() => PlaySoundReversed(mainAudioSource, menuOpen);
        public void PlayPointsAdding() => PlayOneShot(mainAudioSource, pointsAdding);
        public void PlayPurchase() => PlaySound(mainAudioSource, purchase);
        public void PlayRatingAdding() => PlayOneShot(mainAudioSource, ratingAdding);
        public void PlaySoftAdding() => soundManager.PlayDich(mainAudioSource, softAdding);
        public void PlayStart() => PlaySound(mainAudioSource, start);
        public void PlayStop() => PlaySoundReversed(mainAudioSource, start);
        public void PlayWarshipChangingLeft() => PlaySound(mainAudioSource, warshipChanging);
        public void PlayWarshipChangingRight() => PlaySoundReversed(mainAudioSource, warshipChanging);
        public void PlayWarshipPowerPointsAccrual() => soundManager.PlayDich(mainAudioSource, wpp03);
    }
}