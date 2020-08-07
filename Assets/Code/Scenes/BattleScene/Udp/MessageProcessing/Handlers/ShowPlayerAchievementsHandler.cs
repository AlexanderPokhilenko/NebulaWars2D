using Code.Common;
using Code.Common.Logger;
using Code.Scenes.BattleScene.Scripts;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class ShowPlayerAchievementsHandler : MessageHandler<ShowPlayerAchievementsMessage>
    {
        private readonly int matchId;
        private readonly ILog log = LogManager.CreateLogger(typeof(ShowPlayerAchievementsHandler));

        public ShowPlayerAchievementsHandler(int matchId)
        {
            this.matchId = matchId;
        }

        protected override void Handle(in ShowPlayerAchievementsMessage message, uint messageId, bool needResponse)
        {
            log.Info($"Показать результаты боя игрока {nameof(message.MatchId)} {message.MatchId}");

            if (matchId == message.MatchId)
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