using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.BattleScene.Experimental
{
    public class PlayerInfoObject : MonoBehaviour
    {
        [SerializeField] private Image warshipImage;
        [SerializeField] private Text nicknameText;
        [SerializeField] private Text powerLevelText;
        [SerializeField] private Text warshipNameText;
        [SerializeField] private GameObject humanObject;
        [SerializeField] private GameObject botObject;

        public void SetInfo(BattleRoyalePlayerModel model)
        {
            warshipImage.sprite = Resources.Load<Sprite>($"SkinPreview/{model.WarshipName}");
            nicknameText.text = model.Nickname;
            powerLevelText.text = model.WarshipPowerLevel.ToString();
            warshipNameText.text = model.WarshipName;
            if (model.IsBot())
            {
                humanObject.SetActive(false);
                botObject.SetActive(true);
            }
            else
            {
                humanObject.SetActive(true);
                botObject.SetActive(false);
            }
        }
    }
}