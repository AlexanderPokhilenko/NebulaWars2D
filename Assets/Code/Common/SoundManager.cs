#define AddRandomSounding
using UnityEngine;

namespace Code.Common
{
    public class SoundManager : Singleton<SoundManager>
    {
        protected override bool DontDestroy { get; } = true;
        public float InterfaceVolume { get; set; }
        public float SoundsVolume { get; set; }
        public float MusicVolume { get; set; }
        public const float MaxBattleSoundDistance = 15f;
        private const float MaxSoundingDistance2D = 5f;
        private const float MinSoundingDistance3D = 7f;
        private float cameraDistance;
        private float listeningDistance;
        private AnimationCurve soundSpreadCurve;
        private bool valuesWereLoad = false;
#if AddRandomSounding
        private readonly System.Random random = new System.Random();
        private const float PitchDelta = 0.2f;
#endif

        public void LoadValues()
        {
            if(valuesWereLoad) return;
            valuesWereLoad = true;
            InterfaceVolume = PlayerPrefs.GetFloat(nameof(InterfaceVolume), 1f);
            SoundsVolume = PlayerPrefs.GetFloat(nameof(SoundsVolume), 1f);
            MusicVolume = PlayerPrefs.GetFloat(nameof(MusicVolume), 1f);
        }

        public void PlayGameSound(AudioSource audioSource, AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.spatialBlend = 0.95f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.minDistance = cameraDistance;
            audioSource.maxDistance = listeningDistance;
            audioSource.SetCustomCurve(AudioSourceCurveType.Spread, soundSpreadCurve);
#if AddRandomSounding
            audioSource.pitch = 1f + ((float)random.NextDouble() - 0.5f) * PitchDelta;
#endif
            audioSource.PlayOneShot(clip, SoundsVolume);
        }

        public void PlaySameUiSound(AudioSource audioSource, AudioClip clip)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            audioSource.pitch = 1f;
            audioSource.volume = InterfaceVolume;
            audioSource.PlayOneShot(clip);
        }

        
        public void PlayParallel(AudioSource audioSource, AudioClip clip)
        {
            audioSource.pitch = 1f;
            audioSource.volume = InterfaceVolume;
            audioSource.PlayOneShot(clip);
        }

        public void PlayUiSound(AudioSource audioSource, AudioClip clip, bool reversed)
        {
            audioSource.volume = InterfaceVolume;
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            audioSource.clip = clip;
            if (reversed)
            {
                audioSource.pitch = -1f;
                audioSource.timeSamples = clip.samples - 1;
            }
            else
            {
                audioSource.pitch = 1f;
                audioSource.timeSamples = 0;
            }
#if AddRandomSounding
            audioSource.pitch += ((float)random.NextDouble() - 0.5f) * PitchDelta;
#endif
            audioSource.Play();
        }

        private void Start()
        {
            LoadValues();
            cameraDistance = Mathf.Abs(Camera.main.transform.position.z);
            listeningDistance = Mathf.Sqrt(cameraDistance * cameraDistance + MaxBattleSoundDistance * MaxBattleSoundDistance);

            float soundingAs2DDist = Mathf.Sqrt(cameraDistance * cameraDistance + MaxSoundingDistance2D * MaxSoundingDistance2D);
            float soundingAs3DDist = Mathf.Sqrt(cameraDistance * cameraDistance + MinSoundingDistance3D * MinSoundingDistance3D);

            Keyframe[] keyFrameArray = new Keyframe[4];
            keyFrameArray[0] = new Keyframe(0, 0.5f);
            keyFrameArray[1] = new Keyframe(soundingAs2DDist, 0.5f);
            keyFrameArray[2] = new Keyframe(soundingAs3DDist, 0f);
            keyFrameArray[3] = new Keyframe(listeningDistance, 0f);
            soundSpreadCurve = new AnimationCurve(keyFrameArray);
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetFloat(nameof(InterfaceVolume), InterfaceVolume);
            PlayerPrefs.SetFloat(nameof(SoundsVolume), SoundsVolume);
            PlayerPrefs.SetFloat(nameof(MusicVolume), MusicVolume);
            PlayerPrefs.Save();
        }
    }
}
