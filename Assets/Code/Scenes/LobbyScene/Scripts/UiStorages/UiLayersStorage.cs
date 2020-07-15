using UnityEngine;
using UnityEngine.Assertions;

namespace Code.Scenes.LobbyScene.Scripts.UiStorages
{
    /// <summary>
    /// Хранит ссылки на ui слои, которые нужны для правильной работы магазина.
    /// </summary>
    public class UiLayersStorage : MonoBehaviour
    {
        public GameObject warshipsRootGameObject;
        public GameObject layer0RootGameObject;
        public GameObject lootboxRootGameObject;
        public GameObject shopLayerRootGameObject;
        public GameObject warshipsUiLayerRootGameObject;
        public GameObject backButton;
        public GameObject sectionText;

        public void Check()
        {
            Assert.IsNotNull(warshipsRootGameObject);
            Assert.IsNotNull(layer0RootGameObject);
            Assert.IsNotNull(lootboxRootGameObject);
            Assert.IsNotNull(shopLayerRootGameObject);
            Assert.IsNotNull(warshipsUiLayerRootGameObject);
            Assert.IsNotNull(backButton);
            Assert.IsNotNull(sectionText);
        }
    }
}