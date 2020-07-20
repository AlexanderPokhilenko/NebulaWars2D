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
        private AudioSource audioSource;
        private SoundManager soundManager;

        public void Start()
        {
            audioSource = GetComponent<AudioSource>();
            soundManager = SoundManager.Instance();
        }

        private void PlaySound(AudioClip clip) => soundManager.PlayUiSound(audioSource, clip, false);
        private void PlaySoundReversed(AudioClip clip) => soundManager.PlayUiSound(audioSource, clip, true);
        private void PlayOneShot(AudioClip clip) => soundManager.PlaySameUiSound(audioSource, clip);

        public void PlayAdding() => PlaySound(adding);
        public void PlayClick() => PlaySound(click);
        public void PlayError() => PlayOneShot(error);
        public void PlayHardAdding() => PlayOneShot(hardAdding);
        public void PlayLevelUp() => PlaySound(levelUp);
        public void PlayLootbox() => PlaySound(lootbox);
        public void PlayMenu(bool closing) => soundManager.PlayUiSound(audioSource, menuOpen, closing);
        public void PlayMenuOpen() => PlaySound(menuOpen);
        public void PlayMenuClose() => PlaySoundReversed(menuOpen);
        public void PlayPointsAdding() => PlayOneShot(pointsAdding);
        public void PlayPurchase() => PlaySound(purchase);
        public void PlayRatingAdding() => PlayOneShot(ratingAdding);
        public void PlaySoftAdding() => PlayOneShot(softAdding);
        public void PlayStart() => PlaySound(start);
        public void PlayStop() => PlaySoundReversed(start);
        public void PlayWarshipChangingLeft() => PlaySound(warshipChanging);
        public void PlayWarshipChangingRight() => PlaySoundReversed(warshipChanging);
        public void PlayLightning() => PlaySound(lightning);
    }
}