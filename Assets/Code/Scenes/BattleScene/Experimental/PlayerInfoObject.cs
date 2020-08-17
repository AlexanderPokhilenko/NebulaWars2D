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
        [SerializeField] private Image humanObject;
        [SerializeField] private Image botObject;

        public void SetInfo(BattleRoyalePlayerModel model)
        {
            warshipImage.sprite = Resources.Load<Sprite>($"SkinPreview/{model.WarshipName}");
            nicknameText.text = model.Nickname;
            powerLevelText.text = model.WarshipPowerLevel.ToString();
            warshipNameText.text = model.WarshipName;
            if (model.IsBot())
            {
                humanObject.gameObject.SetActive(false);
                botObject.gameObject.SetActive(true);
            }
            else
            {
                humanObject.gameObject.SetActive(true);
                botObject.gameObject.SetActive(false);
            }
        }

        public void SetColor(Color color)
        {
            humanObject.color = color;
            botObject.color = color;
        }
    }
}