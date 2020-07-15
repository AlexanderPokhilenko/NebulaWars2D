using Code.Common;
using Code.Scenes.BattleScene.Scripts;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;
using NetworkLibrary.NetworkLibrary.Udp;
using ZeroFormatter;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class ShowPlayerAchievementsHandler : IMessageHandler
    {
        private readonly int matchId;
        private readonly ILog log = LogManager.CreateLogger(typeof(ShowPlayerAchievementsHandler));

        public ShowPlayerAchievementsHandler(int matchId)
        {
            this.matchId = matchId;
        }
        
        public void Handle(MessageWrapper messageWrapper)
        {
            ShowPlayerAchievementsMessage showPlayerAchievementsMessage =
                ZeroFormatterSerializer.Deserialize<ShowPlayerAchievementsMessage>(messageWrapper.SerializedMessage);

            log.Warn("Показать результаты боя игрока" +
                     $" {nameof(showPlayerAchievementsMessage.MatchId)} {showPlayerAchievementsMessage.MatchId}");
            
            if (matchId == showPlayerAchievementsMessage.MatchId)
            {
                UnityThread.Execute(() => MatchRewardUiController.Instance().ShowPlayerAchievements());
            }
            else
            {
                log.Error($"не тот матч!");
            }
        }
    }
}