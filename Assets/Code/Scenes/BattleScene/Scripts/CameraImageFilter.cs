using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraImageFilter : MonoBehaviour
{
    public Material shaderedMaterial;

    void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
    {
        Graphics.Blit(sourceTexture, destTexture, shaderedMaterial);
    }
}