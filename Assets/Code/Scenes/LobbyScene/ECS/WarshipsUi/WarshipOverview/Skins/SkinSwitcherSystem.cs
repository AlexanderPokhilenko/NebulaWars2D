using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Code.Common;
using Code.Scenes.LobbyScene.ECS.Systems.Reactive.Warships;
using Code.Scenes.LobbyScene.Scripts;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.Components.WarshipsUi.WarshipOverview
{
    /// <summary>
    /// Отвечает за показ скинов во время обзора корабля
    /// </summary>
    public class SkinSwitcherSystem : ReactiveSystem<LobbyUiEntity>
    {
        private readonly LobbyUiContext lobbyUiContext;
        private readonly WarshipsUiStorage warshipsUiStorage;
        private readonly IGroup<LobbyUiEntity> warshipsGroup;
        private readonly ILog log = LogManager.CreateLogger(typeof(SkinSwitcherSystem));

        public SkinSwitcherSystem(Contexts contexts, WarshipsUiStorage warshipsUiStorage)
            : base(contexts.lobbyUi)
        {
            this.warshipsUiStorage = warshipsUiStorage;
            lobbyUiContext = contexts.lobbyUi;
            warshipsGroup = lobbyUiContext.GetGroup(LobbyUiMatcher.Warship);
        }

        protected override ICollector<LobbyUiEntity> GetTrigger(IContext<LobbyUiEntity> context)
        {
            return context.CreateCollector(LobbyUiMatcher.CurrentSkinIndex);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasCurrentSkinIndex;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            int newSkinIndex = entities.Last().currentSkinIndex.index;
            string skinName = lobbyUiContext.warshipOverviewDto.WarshipDto.Skins[newSkinIndex].Name;
            DestroyCurrentSkin();
            SpawnSkin(skinName);
            CurrentWarshipSkinIndexStorage.Set(lobbyUiContext.warshipOverviewDto.WarshipDto.WarshipName, newSkinIndex);
            
            LobbyUiEntity warshipComponent = warshipsGroup
                .GetEntities()
                .Single(entity => 
                    entity.warship.warshipDto.Id == lobbyUiContext.warshipOverviewDto.WarshipDto.Id);
            
            ReloadWarshipView(warshipComponent.warship.index, lobbyUiContext.warshipOverviewDto.WarshipDto);
            warshipComponent.Destroy();
        }

        private void DestroyCurrentSkin()
        {
            warshipsUiStorage.warshipRoot.transform.DestroyAllChildren();
        }
        
        private void SpawnSkin(string skinName)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + skinName);
            Transform parent = warshipsUiStorage.warshipRoot.transform;
            GameObject warship = Object.Instantiate(prefab, parent, false);
            warship.transform.position = new Vector3(0,0,55);
            warship.transform.localScale = new Vector3(1.4f,1.4f,1.4f);
        }
        
        private void ReloadWarshipView(ushort warshipIndex, WarshipDto warshipDto)
        {
            lobbyUiContext.CreateEntity().AddWarship(warshipIndex, warshipDto);
        }
    }
    
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
            return context.CreateCollector(LobbyUiMatcher.CurrentSkinIndex);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasCurrentSkinIndex;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            int newSkinIndex = entities.Last().currentSkinIndex.index;
            int warshipId = lobbyUiContext.warshipOverviewDto.WarshipDto.Id;
            string skinName = lobbyUiContext.warshipOverviewDto.WarshipDto.Skins[newSkinIndex].Name;
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            Task task = ChangeSkinOnServer(warshipId, skinName, cancellationTokenSource.Token);
        }

        private async Task ChangeSkinOnServer(int warshipId, string skinName, CancellationToken cts)
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