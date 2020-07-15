﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.BattleScene.Experimental
{
    public class KillInfoObject : MonoBehaviour
    {
        public float currentTransparency = 1f;
        public UserInfoObject killerInfo;
        public UserInfoObject victimInfo;
        public Text killedText;

        public void SetKillerSprite(Sprite sprite) => killerInfo.SetSprite(sprite);
        public void SetKillerName(string newText) => killerInfo.SetText(newText);
        public void SetVictimSprite(Sprite sprite) => victimInfo.SetSprite(sprite);
        public void SetVictimName(string newText) => victimInfo.SetText(newText);

        public void SetTransparency(float percentage)
        {
            currentTransparency = percentage;
            killerInfo.SetTransparency(percentage);
            victimInfo.SetTransparency(percentage);
            var textColor = killedText.color;
            textColor.a = percentage;
            killedText.color = textColor;
        }

        public void DecreaseTransparency(float delta) => SetTransparency(currentTransparency - delta);
    }
}
