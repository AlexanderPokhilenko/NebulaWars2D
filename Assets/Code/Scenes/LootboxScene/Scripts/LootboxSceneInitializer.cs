using System;
using UnityEngine;

namespace Code.Scenes.LootboxScene.Scripts
{
    public class LootboxSceneInitializer : MonoBehaviour
    {
        private void Awake()
        {
            var uiStorage = FindObjectOfType<LootboxUiStorage>();
            foreach (Transform t in uiStorage.resourcesRoot.transform)
            {
                if (t.gameObject.name != "Sprites_Lootbox")
                {
                    t.gameObject.SetActive(false);
                }
            }
        }
    }
}