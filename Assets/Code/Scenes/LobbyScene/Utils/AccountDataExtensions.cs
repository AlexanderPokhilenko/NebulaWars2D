using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LobbyScene.Scripts
{
    public static class AccountDataExtensions
    {
        public static AccountDto Subtract(this AccountDto accountData,
            RewardsThatHaveNotBeenShown rewardsThatHaveNotBeenShown)
        {
            AccountDto result = new AccountDto
            {
                Username = accountData.Username,
                Warships = accountData.Warships,
                AccountRating = accountData.AccountRating - rewardsThatHaveNotBeenShown.AccountRatingDelta,
                HardCurrency = accountData.HardCurrency - rewardsThatHaveNotBeenShown.HardCurrencyDelta,
                SoftCurrency = accountData.SoftCurrency - rewardsThatHaveNotBeenShown.SoftCurrencyDelta,
                SmallLootboxPoints = accountData.SmallLootboxPoints - rewardsThatHaveNotBeenShown.LootboxPointsDelta,
                AccountId = accountData.AccountId
            };
            return result;
        }
    }
}