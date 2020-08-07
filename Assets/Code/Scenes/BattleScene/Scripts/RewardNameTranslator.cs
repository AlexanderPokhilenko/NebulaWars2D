using System.Collections.Generic;
using Libraries.NetworkLibrary.Experimental;

namespace Code.Scenes.BattleScene.Scripts
{
    public static class RewardNameTranslator
    {
        private static readonly Dictionary<MatchRewardTypeEnum, string> Dictionary =
            new Dictionary<MatchRewardTypeEnum, string>
            {
                {MatchRewardTypeEnum.RankingReward, "Ranking reward"},
                {MatchRewardTypeEnum.DoubleLootboxPoints, "Double tokens"},
            };
        
        public static string Translate(MatchRewardTypeEnum matchRewardTypeEnum)
        {
            if (Dictionary.TryGetValue(matchRewardTypeEnum, out string result))
            {
                return result;
            }

            return matchRewardTypeEnum.ToString();
        }
    }
}