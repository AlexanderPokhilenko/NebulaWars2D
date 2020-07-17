using System.Collections;
using Code.Scenes.BattleScene.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Common
{
    [RequireComponent(typeof(Button))]
    public class MenuButtonListener : MonoBehaviour
    {
        [SerializeField] private BaseMenuManager menu;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(menu.ShowMenu);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu.SwitchMenu();
            }
        }
    }
}