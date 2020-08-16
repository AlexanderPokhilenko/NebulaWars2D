using Code.Common;
using Code.Common.Storages;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.BattleScene.Experimental
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class PlayerInfosGridController : Singleton<PlayerInfosGridController>
    {
        [SerializeField] private PlayerInfoObject prototype;

        private void Start()
        {
            var matchModel = MyMatchDataStorage.Instance.GetMatchModel();
            var models = matchModel.PlayerModels;
            foreach (var model in models)
            {
                var info = Instantiate(prototype, transform);
                info.SetInfo(model);
            }
        }
    }
}