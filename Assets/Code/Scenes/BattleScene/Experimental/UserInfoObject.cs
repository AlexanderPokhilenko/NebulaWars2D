using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.BattleScene.Experimental
{
    public class UserInfoObject : MonoBehaviour
    {
        public Image image;
        public Text text;

        public void SetSprite(Sprite sprite) => image.sprite = sprite;
        public void SetText(string newText) => text.text = newText;

        public void SetTransparency(float percentage)
        {
            var imageColor = image.color;
            imageColor.a = percentage;
            image.color = imageColor;
            var textColor = text.color;
            textColor.a = percentage;
            text.color = textColor;
        }
    }
}
