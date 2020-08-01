using System.Collections.Generic;
using System.Linq;
using Code.Scenes.BattleScene.Experimental;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.BattleScene.ECS.Systems.NetworkSyncSystems
{
    public class UpdatePlayersSystem : IExecuteSystem, ITearDownSystem
    {
        private static readonly object LockObj = new object();
        private static Dictionary<int, ushort> entityIds; // accountId -> entityId
        private static bool WasProcessed = true;
        private readonly GameContext gameContext;
        private readonly Dictionary<int, BattleRoyalePlayerModel> _playerInfos;

        public UpdatePlayersSystem(Contexts contexts)
        {
            gameContext = contexts.game;
            _playerInfos = MyMatchDataStorage.Instance.GetMatchModel().PlayerModels
                .ToDictionary(info => info.AccountId);
        }

        public static void SetNewPlayers(Dictionary<int, ushort> newPlayers)
        {
            lock (LockObj)
            {
                entityIds = newPlayers;
                WasProcessed = false;
            }
        }

        public void TearDown()
        {
            entityIds?.Clear();
        }

        public void Execute()
        {
            lock (LockObj)
            {
                if (WasProcessed) return;
                var currentEntityIds = new Dictionary<int, ushort>(entityIds); // чтобы можно было удалять внутри foreach

                foreach (var pair in currentEntityIds)
                {
                    var entity = gameContext.GetEntityWithId(pair.Value);

                    if (entity != null)
                    {
                        var accountId = pair.Key;
                        entity.AddPlayer(accountId, _playerInfos[accountId].Nickname);
                        entityIds.Remove(accountId);
                    }
                }

                WasProcessed = entityIds.Count == 0;
            }
        }
    }
}