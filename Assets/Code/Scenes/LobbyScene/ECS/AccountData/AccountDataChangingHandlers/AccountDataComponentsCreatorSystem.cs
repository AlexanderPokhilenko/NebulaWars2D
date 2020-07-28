using System.Collections.Generic;
using System.Linq;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.ECS.Warships;
using Code.Scenes.LobbyScene.ECS.Warships.Utils;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LobbyScene.ECS.AccountData.AccountDataChangingHandlers
{
    /// <summary>
    /// Отвечает за обновление всех данных аккаунта.
    /// </summary>
    public class AccountDataComponentsCreatorSystem:IExecuteSystem
    {
        private bool hasNewValue;
        private AccountDto accountData;
        private readonly LobbyUiContext lobbyUiContext;
        private readonly ILog log = LogManager.CreateLogger(typeof(AccountDataComponentsCreatorSystem));
        
        public AccountDataComponentsCreatorSystem(Contexts contexts)
        {
            lobbyUiContext = contexts.lobbyUi;
        }
        
        /// <summary>
        /// Вызывается при получении данных от профиль-сервера.
        /// </summary>
        /// <param name="accountInfoArg"></param>
        public void SetAccountData(AccountDto accountInfoArg)
        {
            log.Info("Пришли данные аккаунта");
            accountInfoArg.CheckAccountData(log);
            accountData = accountInfoArg;
            hasNewValue = true;
        }
        
        public int GetCurrentWarshipId()
        {
            int currentWarshipIndex = lobbyUiContext.currentWarshipIndex.value;
            WarshipComponent currentWarshipComponent = lobbyUiContext
                .GetGroup(LobbyUiMatcher.Warship)
                .AsEnumerable()
                .Single(entity => entity.warship.index == currentWarshipIndex).warship;
            int id = currentWarshipComponent.warshipDto.Id;
            return id;
        }

        public void Execute()
        {
            if (hasNewValue)
            {
                lobbyUiContext.ReplaceUsername(accountData.Username);
                lobbyUiContext.ReplaceAccountRating(accountData.AccountRating);
                lobbyUiContext.ReplaceHardCurrency(accountData.HardCurrency);
                lobbyUiContext.ReplaceSoftCurrency( accountData.SoftCurrency);
                int warshipIndex = WarshipIndexStorage.ReadWarshipIndex();
                lobbyUiContext.ReplaceCurrentWarshipIndex(warshipIndex);
                lobbyUiContext.ReplacePointsForSmallLootbox(accountData.SmallLootboxPoints);
                CreateWarshipComponents(accountData.Warships, lobbyUiContext);
                hasNewValue = false;
            }
        }

        private void CreateWarshipComponents(List<WarshipDto> warships, LobbyUiContext lobbyUiContextArg)
        {
            log.Info("Старт создания сущностей для кораблей");
            for (var i = 0; i < warships.Count; i++)
            {
                log.Info("Создание сущности для корабля " + i);
                WarshipDto warshipDto = warships[i];
                LobbyUiEntity entity = lobbyUiContextArg.CreateEntity();
                
                entity.AddWarship((ushort) i, warshipDto);
                WarshipsStorage.Instance.AddOrUpdate(warshipDto.WarshipTypeEnum, warshipDto);
            }

            log.Info("Создание сущностей для кораблей окончено");
        }
    }
}