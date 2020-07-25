using System;
using Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow;
using DataLayer.Tables;
using NetworkLibrary.NetworkLibrary.Http;
using ZeroFormatter;

namespace Code.Scenes.LobbyScene.Scripts.ResourcesAccrual
{
    /// <summary>
    /// todo это полнейший пиздец
    /// </summary>
    public class ResourceModelMapper
    {
        public ResourceModel Map(PurchaseModel purchaseModel)
        {
            ResourceModel resourceModel = new ResourceModel();
            switch (purchaseModel.productModel.TransactionType)
            {
                case TransactionTypeEnum.WarshipPowerPoints:
                    int startValue = purchaseModel.productModel.WarshipPowerPointsProduct.CurrentPowerPointsAmount;
                    int finishValue = startValue + purchaseModel.productModel.WarshipPowerPointsProduct.PowerPointsIncrement;
                    int maxValueForLevel =
                        purchaseModel.productModel.WarshipPowerPointsProduct.CurrentMaxPowerPointsAmount;
                    resourceModel.ResourceType = ResourceType.WarshipPowerPoints;
                    resourceModel.SerializedModel = ZeroFormatterSerializer.Serialize(
                        new WarshipPowerPointsResourceModel()
                        {
                            WarshipId = purchaseModel.productModel.WarshipPowerPointsProduct.WarshipId,
                            WarshipSkinName = "hare",
                            StartValue = startValue,
                            FinishValue = finishValue,
                            MaxValueForLevel = maxValueForLevel 
                        }); 
                    break;
                case TransactionTypeEnum.SoftCurrency:
                    resourceModel.ResourceType = ResourceType.SoftCurrency;
                    resourceModel.SerializedModel = ZeroFormatterSerializer.Serialize(
                        new SoftCurrencyResourceModel()
                        {
                            Amount = purchaseModel.productModel.Amount
                        });
                    break;
                case TransactionTypeEnum.HardCurrency:
                    resourceModel.ResourceType = ResourceType.HardCurrency;
                    resourceModel.SerializedModel = ZeroFormatterSerializer.Serialize(
                        new HardCurrencyResourceModel()
                        {
                            Amount = purchaseModel.productModel.Amount
                        });
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return resourceModel;
        }
    }
}