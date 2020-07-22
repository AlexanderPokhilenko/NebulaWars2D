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
        private float _cameraDistance;
        private float _listeningDistance;
        private AnimationCurve _soundSpreadCurve;
        private bool valuesWereLoad = false;
#if AddRandomSounding
        private readonly System.Random _random = new System.Random();
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

        public void PlayGameSound(AudioSource source, AudioClip clip)
        {
            source.clip = clip;
            source.spatialBlend = 0.95f;
            source.rolloffMode = AudioRolloffMode.Linear;
            source.minDistance = _cameraDistance;
            source.maxDistance = _listeningDistance;
            source.SetCustomCurve(AudioSourceCurveType.Spread, _soundSpreadCurve);
#if AddRandomSounding
            source.pitch = 1f + ((float)_random.NextDouble() - 0.5f) * PitchDelta;
#endif
            source.PlayOneShot(clip, SoundsVolume);
        }

        public void PlaySameUiSound(AudioSource source, AudioClip clip)
        {
            if (source.isPlaying) source.Stop();
            source.pitch = 1f;
            source.volume = InterfaceVolume;
            source.PlayOneShot(clip);
        }

        public void PlayUiSound(AudioSource source, AudioClip clip, bool reversed)
        {
            source.volume = InterfaceVolume;
            if (source.isPlaying) source.Stop();
            source.clip = clip;
            if (reversed)
            {
                source.pitch = -1f;
                source.timeSamples = clip.samples - 1;
            }
            else
            {
                source.pitch = 1f;
                source.timeSamples = 0;
            }
#if AddRandomSounding
            source.pitch += ((float)_random.NextDouble() - 0.5f) * PitchDelta;
#endif
            source.Play();
        }

        private void Start()
        {
            LoadValues();
            _cameraDistance = Mathf.Abs(Camera.main.transform.position.z);
            _listeningDistance = Mathf.Sqrt(_cameraDistance * _cameraDistance + MaxBattleSoundDistance * MaxBattleSoundDistance);

            var soundingAs2DDist = Mathf.Sqrt(_cameraDistance * _cameraDistance + MaxSoundingDistance2D * MaxSoundingDistance2D);
            var soundingAs3DDist = Mathf.Sqrt(_cameraDistance * _cameraDistance + MinSoundingDistance3D * MinSoundingDistance3D);

            Keyframe[] keyFrameArray = new Keyframe[4];
            keyFrameArray[0] = new Keyframe(0, 0.5f);
            keyFrameArray[1] = new Keyframe(soundingAs2DDist, 0.5f);
            keyFrameArray[2] = new Keyframe(soundingAs3DDist, 0f);
            keyFrameArray[3] = new Keyframe(_listeningDistance, 0f);
            _soundSpreadCurve = new AnimationCurve(keyFrameArray);
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
