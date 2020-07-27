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
            switch (purchaseModel.productModel.ResourceTypeEnum)
            {
                case ResourceTypeEnum.WarshipPowerPoints:
                    WarshipPowerPointsProductModel wppModel = purchaseModel.productModel;
                    resourceModel.ResourceTypeEnum = ResourceTypeEnum.WarshipPowerPoints;
                    resourceModel.SerializedModel = ZeroFormatterSerializer.Serialize(
                        new WarshipPowerPointsResourceModel()
                        {
                            WarshipId = wppModel.WarshipId,
                            WarshipSkinName = "hare",
                            StartValue = wppModel.StartValue,
                            FinishValue = wppModel.FinishValue,
                            MaxValueForLevel = wppModel.MaxValueForLevel 
                        }); 
                    break;
                case ResourceTypeEnum.SoftCurrency:
                    SoftCurrencyProductModel softModel = purchaseModel.productModel;
                    resourceModel.ResourceTypeEnum = ResourceTypeEnum.SoftCurrency;
                    resourceModel.SerializedModel = ZeroFormatterSerializer.Serialize(
                        new SoftCurrencyResourceModel()
                        {
                            Amount = softModel.Amount
                        });
                    break;
                case ResourceTypeEnum.HardCurrency:
                    HardCurrencyProductModel hardModel = purchaseModel.productModel;
                    resourceModel.ResourceTypeEnum = ResourceTypeEnum.HardCurrency;
                    resourceModel.SerializedModel = ZeroFormatterSerializer.Serialize(
                        new HardCurrencyResourceModel()
                        {
                            Amount = hardModel.Amount
                        });
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return resourceModel;
        }
    }
}