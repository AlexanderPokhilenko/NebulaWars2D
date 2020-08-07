using UnityEngine;

namespace Code.Scenes.BattleScene.Scripts
{
    [RequireComponent(typeof(Camera))]
    public class CameraImageFilter : MonoBehaviour
    {
        public Material shaderedMaterial;

        private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
        {
            Graphics.Blit(sourceTexture, destTexture, shaderedMaterial);
        }
    }
}