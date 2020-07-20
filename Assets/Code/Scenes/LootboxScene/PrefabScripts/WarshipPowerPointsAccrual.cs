using System;
using System.Collections;
using System.Collections.Generic;
using Code.Common;
using Code.Common.Logger;
using Entitas;
using UnityEngine;
using Random = System.Random;

namespace Code.Scenes.LootboxScene.PrefabScripts
{
    public class WppIconsInstantiatorSystem : ReactiveSystem<LobbyUiEntity>
    {
        public WppIconsInstantiatorSystem(IContext<LobbyUiEntity> context) : base(context)
        {
        }

        public WppIconsInstantiatorSystem(ICollector<LobbyUiEntity> collector) : base(collector)
        {
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            throw new NotImplementedException();
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Находится на префабе премиум-валюты. Управляет анимацией при появлении префаба.
    /// </summary>
    public class WarshipPowerPointsAccrual : MonoBehaviour
    {
        private GameObject lightningParticleSystem;

        [SerializeField] private GameObject wppIconPrefab;
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipPowerPointsAccrual));

        public void SetData(string warshipPrefabNameArg, int amount)
        {
            StartCoroutine(Animation(warshipPrefabNameArg, amount));
        }
    
        private void Awake()
        {
            lightningParticleSystem = transform.Find("ParticleSystem").gameObject;
            if (wppIconPrefab == null)
            {
                throw new NullReferenceException(nameof(wppIconPrefab));
            }
        }

        private void Start()
        {
            lightningParticleSystem.SetActive(false);
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        private IEnumerator Animation(string warshipPrefabNameArg, int amount)
        {
            StartCoroutine(WarshipAnimation(warshipPrefabNameArg, amount));
            yield break;
        }
        
        private IEnumerator WarshipAnimation(string warshipPrefabNameArg, int amount)
        {
            //создать кораблик слева за сценой
            GameObject warshipPrefab = Resources.Load<GameObject>($"Prefabs/{warshipPrefabNameArg}");
            Vector3 position = new Vector3(-4,0);
            Quaternion quaternion = Quaternion.identity;
            GameObject warship = Instantiate(warshipPrefab, position, quaternion, transform);
            warship.transform.localScale = Vector3.one/2;

            //плавно переместить корабль на центр экрана
            while (warship.transform.position.x<0)
            {
                Vector3 tmp = warship.transform.position;
                tmp = new Vector3(tmp.x+0.15f, tmp.y);
                warship.transform.position = tmp;
                yield return null;
            }
            
            //включить систему частиц
            lightningParticleSystem.SetActive(true);
            //включить звук молнии
            UiSoundsManager.Instance().PlayLightning();
            //создать набор иконок

            RectTransform canvas = transform.Find("Canvas").GetComponent<RectTransform>();
            Random random = new Random();
            float centerX = 640;
            float centerY = 360;
            for (int i = 0; i < amount; i++)
            {
                float distanceFromCenter = 200;
                float randomAngle = random.Next(360)/2/Mathf.PI;
                float x = Mathf.Sin(randomAngle)*distanceFromCenter+centerX;
                float y = Mathf.Cos(randomAngle)*distanceFromCenter+centerY;
                Vector3 tmpPosition = new Vector3(x, y); 
                Instantiate(wppIconPrefab, tmpPosition, Quaternion.identity, canvas);
            }
            //переместить их
            
            //втянуть их в шкалу силы
            
            //если шкала заполнена, то показать зелёную шкалу

            yield break;
        }
    }
}
