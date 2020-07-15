using System.Collections.Generic;
using Libraries.NetworkLibrary.Experimental;

namespace Code.Scenes.BattleScene.Scripts
{
    public static class RewardNameTranslator
    {
        private static readonly Dictionary<MatchRewardTypeEnum, string> dictionary =
            new Dictionary<MatchRewardTypeEnum, string>
            {
                {MatchRewardTypeEnum.RankingReward, "RANKING REWARD"},
                {MatchRewardTypeEnum.DoubleLootboxPoints, "DOUBLE TOKENS"},
            };
        
        public static string Translate(MatchRewardTypeEnum matchRewardTypeEnum)
        {
            if (dictionary.TryGetValue(matchRewardTypeEnum, out string result))
            {
                return result;
            }
            else
            {
                return matchRewardTypeEnum.ToString();
            }
        }
    }
}