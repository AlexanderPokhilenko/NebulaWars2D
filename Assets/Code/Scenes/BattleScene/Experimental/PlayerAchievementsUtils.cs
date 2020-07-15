using Code.Common;
using Code.Common.Logger;
using Libraries.NetworkLibrary.Experimental;

namespace Code.Scenes.BattleScene.Experimental
{
    public static class PlayerAchievementsUtils
    {
        private static readonly ILog log = LogManager.CreateLogger(typeof(PlayerAchievementsUtils));
        
        public static void LogPlayerAchievements(MatchResultDto matchResultDto)
        {
            if (matchResultDto == null)
            {
                log.Debug($"{nameof(matchResultDto)} is null");
                return;
            }
            log.Debug($"{nameof(matchResultDto.SkinName)} {matchResultDto.SkinName}");
            log.Debug($"{nameof(matchResultDto.MatchRatingDelta)} {matchResultDto.MatchRatingDelta}");
            log.Debug($"{nameof(matchResultDto.CurrentWarshipRating)} {matchResultDto.CurrentWarshipRating}");
            if (matchResultDto.LootboxPoints.Count == 0)
            {
                log.Debug("Список наград пуст");
            }
            
            foreach (var pair  in matchResultDto.LootboxPoints)
            {
                log.Debug($"{pair.Key} {pair.Value}");
            }
        }
    }
}