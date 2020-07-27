using NetworkLibrary.NetworkLibrary.Http;
using ZeroFormatter;

namespace Code.Scenes.LobbyScene.Scripts.ResourcesAccrual
{
    /// <summary>
    /// По списку ресурсов в лутбоксе создаёт обьект для анимации движущихся наград.
    /// </summary>
    public class RewardsThatHaveNotBeenShownFactory
    {
        public RewardsThatHaveNotBeenShown Create(LootboxModel lootboxModel)
        {
            RewardsThatHaveNotBeenShown result = new RewardsThatHaveNotBeenShown();
            foreach (ResourceModel resourceModel in lootboxModel.Prizes)
            {
                if (resourceModel.ResourceTypeEnum == ResourceTypeEnum.HardCurrency)
                {
                    var hardCurrencyResourceModel =
                        ZeroFormatterSerializer.Deserialize<HardCurrencyResourceModel>(resourceModel.SerializedModel);
                    result.HardCurrencyDelta += hardCurrencyResourceModel.Amount;
                }
                
                if (resourceModel.ResourceTypeEnum == ResourceTypeEnum.SoftCurrency)
                {
                    var softCurrencyResourceModel =
                        ZeroFormatterSerializer.Deserialize<SoftCurrencyResourceModel>(resourceModel.SerializedModel);
                    result.SoftCurrencyDelta += softCurrencyResourceModel.Amount;
                }
            }
            return result;
        }
    }
}