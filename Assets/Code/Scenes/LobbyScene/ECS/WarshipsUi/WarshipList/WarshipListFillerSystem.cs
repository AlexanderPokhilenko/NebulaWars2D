using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Scenes.BattleScene.Experimental;
using Code.Common;
using Code.Scenes.LobbyScene.Scripts;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Vector2 = NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2;

namespace Code.Scenes.LobbyScene.ECS.Systems.Reactive.Warships
{
    public class WarshipListFillerSystem:ReactiveSystem<LobbyUiEntity>
    {
        private readonly IGroup<LobbyUiEntity> warshipsGroup;
        private readonly WarshipsUiStorage warshipsUiStorage;
        private readonly LobbyEcsController lobbyEcsController;
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipSpawnerSystem));

        public WarshipListFillerSystem(Contexts contexts, WarshipsUiStorage warshipsUiStorage, 
            LobbyEcsController lobbyEcsController) 
            : base(contexts.lobbyUi)
        {
            this.warshipsUiStorage = warshipsUiStorage;
            this.lobbyEcsController = lobbyEcsController;
            warshipsGroup = contexts.lobbyUi.GetGroup(LobbyUiMatcher.Warship);
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.Warship.AddedOrRemoved());
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasWarship;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            log.Info("Старт заполнения списка кораблей");
            FillWarshipsList(warshipsGroup.AsEnumerable()
                .OrderBy(entity=>entity.warship.index)
                .Select(entity=>entity.warship.warshipDto)
                .ToList());
            log.Info("Заполнение списка кораблей закончено");
        }

        private void FillWarshipsList(List<WarshipDto> warshipsList)
        {
            ClearWarshipList();
            CreateItems(warshipsList);
        }
        
        private void ClearWarshipList()
        {
            warshipsUiStorage.warshipsListBackgroundGameObject.transform.DestroyAllChildren();
        }

        private void CreateItems(List<WarshipDto> warshipsListData)
        {
            for (int index = 0; index < warshipsListData.Count; index++)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/LobbyWarshipsList/Image_WarshipListItem")
                                    ?? throw new Exception("Не удалось найти префаб");
                Transform parent = warshipsUiStorage.warshipsListBackgroundGameObject.transform;
                GameObject item = Object.Instantiate(prefab, parent, false );
                
                //Взять элемент
                WarshipDto warshipDto = warshipsListData[index];
                
                //Установить картинку
                Image image = item.transform.Find("Image_WarshipPreview").GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>(warshipDto.WarshipName);
                
                
                //Установить название корабля
                Text warshipNameText = item.transform.Find("Image_WarshipPreview/Text_WarshipName").GetComponent<Text>();
                warshipNameText.text = warshipDto.WarshipName.ToUpper();
                
                //Установить уровень силы
                Text warshipPowerText = item.transform.Find("Image_WarshipPreview/Text_Power").GetComponent<Text>();
                warshipPowerText.text = "POWER "+warshipDto.PowerLevel;

                
                //Проверить на кол-во ресурсов для перехода на новый уровень
                int softCurrency = lobbyEcsController.GetSoftCurrency();
                int improvementCost = WarshipPowerScaleStorage.Instance.GetCost(warshipDto.PowerLevel);
                int maxPowerPoints = WarshipPowerScaleStorage.Instance.GetMaxPowerPoints(warshipDto.PowerLevel);
                
                bool showImproveAnimation = softCurrency >= improvementCost && warshipDto.PowerPoints >= maxPowerPoints;

                if (showImproveAnimation)
                {
                    item.transform.Find("Empty_PowerValueRoot").gameObject.SetActive(false);
                    item.transform.Find("Empty_FilledPowerScale").gameObject.SetActive(true);
                }
                else
                {
                    item.transform.Find("Empty_PowerValueRoot").gameObject.SetActive(true);
                    item.transform.Find("Empty_FilledPowerScale").gameObject.SetActive(false);

                    //Установить кол-во баллов текущего уровня силы на шкале прогресса
                    Slider slider = item.transform.Find("Empty_PowerValueRoot/Slider").GetComponent<Slider>();
                    slider.value = WarshipPowerScaleStorage.Instance.GetProgress(warshipDto.PowerLevel, warshipDto.PowerPoints);
                
                    //Установить текст кол-ва баллов текущего уровня силы 
                    Text sliderText = item.transform.Find("Empty_PowerValueRoot/Text").GetComponent<Text>();
                    sliderText.text = warshipDto.PowerPoints + "/"+WarshipPowerScaleStorage.Instance.GetMaxPowerPoints(warshipDto.PowerLevel);
                }

             
                //Подготовка к показу ранга
                WarshipRankModel warshipRankModel = WarshipRatingScaleStorage.Instance.GetRankModel(warshipDto.Rating);

                //Установить текст уровеня ранга
                Text rankText = item.transform.Find("Empty_WarshipExperienceScale/Image_LeftCircle/Text_RankValue")
                    .GetComponent<Text>();
                rankText.text = warshipRankModel.currentRank.ToString();
                
                //Установить текст кол-ва трофеев
                Text trophyCountText = item.transform.Find("Empty_WarshipExperienceScale/Image_RightRect/Text")
                    .GetComponent<Text>();
                trophyCountText.text = warshipDto.Rating.ToString();
                
                //Установить значение шкалы прогресса кол-ва трофеев
                Slider sliderTrophy = item.transform.Find("Empty_WarshipExperienceScale/Image_RightRect/Slider")
                    .GetComponent<Slider>();
                sliderTrophy.value = warshipRankModel.rankProgress;
                
                //Установить обработчик нажатия
                Button button = item.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    lobbyEcsController.ShowWarshipOverview(warshipDto);
                });
            }
        }
    }
}