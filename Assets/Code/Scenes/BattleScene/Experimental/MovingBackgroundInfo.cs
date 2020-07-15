using System;
using UnityEngine.UI;

namespace Code.Scenes.BattleScene.Experimental
{
    [Serializable]
    public class MovingBackgroundInfo
    {
        public Image image;
        public float coefficient;

        public void Deconstruct(out Image img, out float k)
        {
            img = image;
            k = coefficient;
        }
    }
}
