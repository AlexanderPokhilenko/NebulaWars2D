using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.ECS.Warships;
using Code.Scenes.LobbyScene.Scripts.WarshipsUi;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;

namespace Code.Scenes.LobbyScene.ECS.WarshipsUi.WarshipOverview.Skins
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
            return context.CreateCollector(LobbyUiMatcher.WarshipOverviewCurrentSkinIndex);
        }

        protected override bool Filter(LobbyUiEntity entity)
        {
            return entity.hasWarshipOverviewCurrentSkinIndex;
        }

        protected override void Execute(List<LobbyUiEntity> entities)
        {
            int newSkinIndex = entities.Last().warshipOverviewCurrentSkinIndex.index;
            string skinName = lobbyUiContext.warshipOverviewDto.warshipDto.Skins[newSkinIndex].Name;
            DestroyCurrentSkin();
            SpawnSkin(skinName);
            CurrentWarshipSkinIndexStorage.Set(lobbyUiContext.warshipOverviewDto.warshipDto.WarshipName, newSkinIndex);
            
            LobbyUiEntity warshipComponent = warshipsGroup
                .GetEntities()
                .Single(entity => 
                    entity.warship.warshipDto.Id == lobbyUiContext.warshipOverviewDto.warshipDto.Id);
            
            ReloadWarshipView(warshipComponent.warship.index, lobbyUiContext.warshipOverviewDto.warshipDto);
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
}