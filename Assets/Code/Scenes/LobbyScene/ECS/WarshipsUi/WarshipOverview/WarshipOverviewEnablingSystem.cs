using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.Common;
using Code.Common.Logger;
using Code.Common.Statistics;
using Code.Scenes.LobbyScene.ECS.CommonLayoutSwitcher;
using Code.Scenes.LobbyScene.ECS.Warships;
using Code.Scenes.LobbyScene.Scripts;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using Code.Scenes.LobbyScene.Scripts.WarshipsUi;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipOverview
{
    public class WarshipOverviewEnablingSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyUiContext lobbyUiContext;
        private readonly WarshipsUiStorage warshipsUiStorage;
        private readonly LobbyEcsController lobbyEcsController;
        private readonly LobbyLayoutSwitcher lobbyLayoutSwitcher;
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipOverviewEnablingSystem));

        public WarshipOverviewEnablingSystem(Contexts contexts, WarshipsUiStorage warshipsUiStorage,
           LobbyLayoutSwitcher lobbyLayoutSwitcher, LobbyEcsController lobbyEcsController) 
            : base(contexts.lobbyUi)
        {
            this.warshipsUiStorage = warshipsUiStorage;
            this.lobbyLayoutSwitcher = lobbyLayoutSwitcher;
            this.lobbyEcsController = lobbyEcsController;
            lobbyUiContext = contexts.lobbyUi;
        }
        
        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.EnableWarshipOverviewUiLayer);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasEnableWarshipOverviewUiLayer;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            // log.Debug(nameof(WarshipOverviewEnablingSystem));
            LobbyUiEntity entity = entities.Last();
            ShowOverviewLayer(entity.enableWarshipOverviewUiLayer.WarshipDto);
            lobbyLayoutSwitcher.SetCurrentLayer(ShittyUiLayerState.WarshipOverview);
        }
        
        private void ShowOverviewLayer(WarshipDto warshipDto)
        {
            warshipsUiStorage.hint.SetActive(false);
            ShowWarshipOverview(warshipDto);
            warshipsUiStorage.warshipListRootGameObject.SetActive(false);
            warshipsUiStorage.warshipRootGameObject.SetActive(true);
            warshipsUiStorage.warshipRoot.SetActive(true);
        }
        
        private void ShowWarshipOverview(WarshipDto warshipDto)
        {
            UpdateData(warshipDto);
            
            //Установить значения компонентов для выбора скинов
            lobbyUiContext.ReplaceWarshipOverviewDto(warshipDto);
            int currenctSkinIndex = CurrentWarshipSkinIndexStorage.Get(warshipDto.WarshipName);
            lobbyUiContext.ReplaceCurrentSkinIndex(currenctSkinIndex);
        }
        
        private void UpdateData(WarshipDto warshipDto)
        {
            //Установить название корабля
            warshipsUiStorage.warshipName.text = warshipDto.WarshipName.ToUpper();
            //Установить тип корабля
            warshipsUiStorage.warshipTypeName.text = warshipDto.CombatRoleName;
            //Установить ранг корабля
            WarshipRankModel rankModel = WarshipRatingScaleStorage.Instance.GetRankModel(warshipDto.Rating);
            warshipsUiStorage.warshipRank.text = rankModel.currentRank.ToString();
            //Установить слайдер для рейтинга
            warshipsUiStorage.trophySlider.value = rankModel.rankProgress;
            //Установить рейтинг корабля
            warshipsUiStorage.trophyText.text = rankModel.ToString();
            //Установить описание корабля
            warshipsUiStorage.warshipDescription.text = warshipDto.Description;
            //Установить уровень силы
            warshipsUiStorage.warshipPowerLevel.text = "POWER " + warshipDto.PowerLevel;
            //TODO Установить характеристики корабля (атаку, защиту, скорость или что там)
            
            //Проверить на кол-во ресурсов для перехода на новый уровень
            int softCurrency = lobbyEcsController.GetSoftCurrency();
            int improvementCost = WarshipPowerScaleStorage.Instance.GetCost(warshipDto.PowerLevel);
            int maxPowerPoints = WarshipPowerScaleStorage.Instance.GetMaxPowerPoints(warshipDto.PowerLevel);
                
            bool showImproveAnimation = softCurrency >= improvementCost && warshipDto.PowerPoints >= maxPowerPoints;

            Text powerPointsValueText;
            //Показать нужную шкалу. (Красную или зелёную)
            if (showImproveAnimation)
            {
                powerPointsValueText = warshipsUiStorage.greenPowerPointsValueText;
                warshipsUiStorage.redScale.SetActive(false);
                warshipsUiStorage.greenScale.SetActive(true);
            }
            else
            {
                warshipsUiStorage.redScale.SetActive(true);
                warshipsUiStorage.greenScale.SetActive(false);
                powerPointsValueText = warshipsUiStorage.powerValueText;
            }
            
            //Установить кол-во очков силы для текущего уровня
            powerPointsValueText.text =  warshipDto.PowerPoints + "/" + 
                                         WarshipPowerScaleStorage.Instance.GetMaxPowerPoints(warshipDto.PowerLevel);

            //Установить слайдер для кол-ва очков силы
            warshipsUiStorage.powerSlider.value =
                WarshipPowerScaleStorage.Instance.GetProgress(warshipDto.PowerLevel, warshipDto.PowerPoints);
            
            //Установить цену улучшения
            warshipsUiStorage.improveButtonCost.text = WarshipPowerScaleStorage.Instance.GetCost(warshipDto.PowerLevel).ToString();
            //Установить слушатель для кнопки улучшения
            warshipsUiStorage.improveButton.onClick.RemoveAllListeners();
            warshipsUiStorage.improveButton.onClick.AddListener(() =>
            {
                if (warshipDto.PowerPoints >= WarshipPowerScaleStorage.Instance.GetMaxPowerPoints(warshipDto.PowerLevel))
                {
                    //показать окно покупки улучшения
                    lobbyEcsController.ShowWarshipImprovementModalWindow(warshipDto);
                }
                else
                {
                    UiSoundsManager.Instance().PlayError();
                    //показать всплывающую подсказку о невозможности операции
                    if (!warshipsUiStorage.hint.activeSelf)
                    {
                        warshipsUiStorage.hint.SetActive(true);
                        Task.Run(async () =>
                        {
                            await Task.Delay(2000);
                            UnityThread.Execute(() => { warshipsUiStorage.hint.SetActive(false); });
                        });    
                    }
                }
            });
            //Установить слушатель для кнопки выбора корабля\   
            warshipsUiStorage.chooseButton.onClick.RemoveAllListeners();
            warshipsUiStorage.chooseButton.onClick.AddListener(() =>
            {
                //TODO добавить эту фигню
            });
            
            //Установить стоимость для кнопки покупки улучшения
            warshipsUiStorage.popupWindowCostText.text = WarshipPowerScaleStorage.Instance
                .GetCost(warshipDto.PowerLevel).ToString();
            
            //Установить слушатель для кнопки покупки улучшения
            warshipsUiStorage.popupWindowBuyButton.onClick.RemoveAllListeners();
            warshipsUiStorage.popupWindowBuyButton.onClick.AddListener(()=>
            {
                //todo показать окно подтверждения
            });
            
            //Установить слушатель для меню с характеристиками корабля
            warshipsUiStorage.warshipCharacteristicsButton.onClick.RemoveAllListeners();
            warshipsUiStorage.warshipCharacteristicsButton.onClick.AddListener(()=>
            {
                lobbyEcsController.ShowWarshipCharacteristics(warshipDto);
            });
        }
    }

    public static class TransformExtensions
    {
        public static void SetOpacity(this Transform parentTransform, float alphaValue)
        {
            Material material = parentTransform.GetComponent<Renderer>().material;
            Color color = material.color;
            material.color = new Color(color.r, color.g, color.b, alphaValue);
            
            foreach (Transform transform in parentTransform)
            {
                transform.SetOpacity(alphaValue);
            }
        }
    }
}