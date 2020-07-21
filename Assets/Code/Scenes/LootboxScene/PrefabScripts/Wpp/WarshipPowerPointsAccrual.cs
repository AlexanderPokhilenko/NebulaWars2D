using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.ECS;
using Code.Scenes.LobbyScene.ECS.AccountData.MovingAwards.Images;
using Code.Scenes.LootboxScene.PrefabScripts.Wpp.ECS.Systems;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Code.Scenes.LootboxScene.PrefabScripts.Wpp
{
    /// <summary>
    /// Находится на префабе премиум-валюты. Управляет анимацией при появлении префаба.
    /// </summary>
    public class WarshipPowerPointsAccrual : MonoBehaviour
    {
        private Systems systems;
        private RectTransform canvasRect;
        private WppAccrualContext wppContext;
        private GameObject lightningParticleSystem;
        [SerializeField] private GameObject wppIconPrefab;
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipPowerPointsAccrual));

        public void SetData(LootboxWarshipPowerPointsModel lootboxWarshipPowerPointsModel)
        {
            StartCoroutine(Animation(lootboxWarshipPowerPointsModel));
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
            log.Error("start called");
            lightningParticleSystem.SetActive(false);
            Contexts contexts = Contexts.sharedInstance;
            canvasRect = transform.Find("Canvas").GetComponent<RectTransform>();
            Text text = transform.Find("Canvas/Empty_PowerValueRoot/Text").GetComponent<Text>();
            RectTransform upperObject = transform.Find("Canvas/Empty_UpperObject").GetComponent<RectTransform>();
            wppContext = Contexts.sharedInstance.wppAccrual;
            
            systems = new Systems()
                //Движение наград
                .Add(new WppImagesInstantiatorSystem(contexts, canvasRect, wppIconPrefab))
                .Add(new IconsDataUpdaterSystem(contexts))
                .Add(new IconsUpdaterSystem(contexts, upperObject))
                .Add(new WppViewDestroySystem(contexts))
                .Add(new WppScaleUpdaterSystem(contexts.wppAccrual, text))
                ;
            
            if (wppContext == null)
            {
                throw new NullReferenceException("context is null in start");
            }
        }

        private void Update()
        {
            if (systems != null)
            {
                systems.Execute();
                systems.Cleanup();
            }
        }

        private IEnumerator Animation(LootboxWarshipPowerPointsModel lootboxWarshipPowerPointsModel)
        {
            yield return new WaitUntil(()=>wppContext!=null);
            log.Error("Animation called");
            int startValue = lootboxWarshipPowerPointsModel.StartValue;
            int maxValue = lootboxWarshipPowerPointsModel.MaxValueForLevel;
            log.Error($"{nameof(startValue)} {startValue}");
            wppContext.CreateEntity().ReplaceWarshipPowerPoints(startValue,maxValue);
            int amount = lootboxWarshipPowerPointsModel.FinishValue - lootboxWarshipPowerPointsModel.StartValue;
            StartCoroutine(WarshipAnimation(lootboxWarshipPowerPointsModel.WarshipPrefabName, amount));
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
            float velocity = 0.01f;
            float acceleration = 0.005f;
            while (warship.transform.position.x < 0)
            {
                Vector3 tmp = warship.transform.position;
                tmp = new Vector3(tmp.x+velocity, tmp.y);
                warship.transform.position = tmp;
                velocity += acceleration;
                yield return null;
            }
            
            //включить систему частиц
            lightningParticleSystem.SetActive(true);
            
            //создать набор иконок
            Vector3 spawnPosition = new Vector3(Screen.width/2, Screen.height/2);
            Vector3 finishPosition = canvasRect.gameObject.transform.Find("Empty_PowerValueRoot/Image_PowerValue")
                .GetComponent<RectTransform>().position;
            
            var trajectoryFactory = new WppIconTrajectoryFactory();
            var random = new Random();
            for (int index = 0; index < amount; index++)
            {
                DateTime spawnStartTime = DateTime.UtcNow;
                var entity = Contexts.sharedInstance.wppAccrual.CreateEntity();
                List<ControlPoint> controlPoints = trajectoryFactory
                    .Create(index, spawnStartTime, spawnPosition, finishPosition, random);
                
                IconTrajectory iconTrajectory = new IconTrajectory()
                {
                    controlPoints = controlPoints,
                    currentControlPointIndex = 0
                };
                entity.AddMovingIcon(1, iconTrajectory, AwardTypeEnum.WarshipPowerPoints);
                entity.AddPosition(controlPoints.First().position);
                entity.AddAlpha(0);
                entity.AddScale(new Vector3(1,1,1));
            }
        }
    }
}
