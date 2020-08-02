using System;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Common.Storages
{
    public class MyMatchDataStorage
    {
        private static readonly Lazy<MyMatchDataStorage> lazy = new Lazy<MyMatchDataStorage>(() => new MyMatchDataStorage());
        public static MyMatchDataStorage Instance => lazy.Value;
        private BattleRoyaleClientMatchModel matchData;

        public void SetMatchData(BattleRoyaleClientMatchModel matchDataArg)
        {
            matchData = matchDataArg;
        }

        public BattleRoyaleClientMatchModel GetMatchModel()
        {
            return matchData;
        }
    }
}