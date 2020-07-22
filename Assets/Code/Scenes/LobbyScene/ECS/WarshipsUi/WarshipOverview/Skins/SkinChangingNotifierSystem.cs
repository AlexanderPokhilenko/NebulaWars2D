using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Code.Common;
using Code.Common.Logger;
using Entitas;

namespace Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipOverview.Skins
{
    public class SkinChangingNotifierSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyUiContext lobbyUiContext;
        private CancellationTokenSource cancellationTokenSource;
        private readonly ILog log = LogManager.CreateLogger(typeof(SkinSwitcherSystem));
        public SkinChangingNotifierSystem(Contexts contexts)
            : base(contexts.lobbyUi)
        {
            lobbyUiContext = contexts.lobbyUi;
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.WarshipOverviewCurrentSkinIndex);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasWarshipOverviewCurrentSkinIndex;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            int newSkinIndex = entities.Last().warshipOverviewCurrentSkinIndex.index;
            int warshipId = lobbyUiContext.warshipOverviewDto.warshipDto.Id;
            string skinName = lobbyUiContext.warshipOverviewDto.warshipDto.Skins[newSkinIndex].Name;
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            Task task = ChangeSkinOnServerAsync(warshipId, skinName, cancellationTokenSource.Token);
        }

        private async Task ChangeSkinOnServerAsync(int warshipId, string skinName, CancellationToken cts)
        {
            HttpClient httpClient = new HttpClient();
            if(!PlayerIdStorage.TryGetServiceId(out string playerServiceId))
            {
                log.Warn("Не удалось получить id игрока");
                return;
            }
            
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(playerServiceId), "playerServiceId");
                formData.Add(new StringContent(warshipId.ToString()), "warshipId");
                formData.Add(new StringContent(skinName), "skinName");
                await httpClient.PostAsync(NetworkGlobals.ChangeSkinUrl, formData, cts);
            }
        }
    }
}