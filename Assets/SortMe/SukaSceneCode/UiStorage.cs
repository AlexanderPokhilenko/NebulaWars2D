using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.SukaScene
{
    public class UiStorage : MonoBehaviour
    {
        [SerializeField] private Button currencyButton;
        [SerializeField] private Button confirmAllButton;
        private Purchaser purchaser;

        private void Awake()
        {
            purchaser = FindObjectOfType<Purchaser>();
        }

        private void Start()
        {
            currencyButton.onClick.RemoveAllListeners();
            currencyButton.onClick.AddListener(() =>
            {
                purchaser.BuyCurrency();
            }); 
            confirmAllButton.onClick.RemoveAllListeners();
            confirmAllButton.onClick.AddListener( () =>
            {
                purchaser.ConfirmAll();
            });
        }
    }
}
