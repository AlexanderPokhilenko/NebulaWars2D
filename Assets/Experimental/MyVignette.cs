using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MyVignette : MonoBehaviour
{
    #region Variables
    public Shader CurShader;
    [Range(0f, 1f)]
    public float VignetteRadius = 0.8f;
    [Range(0f, 1f)]
    public float VignetteSoftness = 0.5f;
    public Color Color = Color.white;
    private Material curMaterial;
    #endregion

    #region Properties
    Material material
    {
        get
        {
            if (curMaterial == null)
            {
                curMaterial = new Material(CurShader) {hideFlags = HideFlags.HideAndDontSave};
            }
            return curMaterial;
        }
    }
    #endregion
    // Use this for initialization
    void Start()
    {
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
        }
    }

    void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
    {
        if (CurShader != null)
        {
            material.SetFloat("_VRadius", VignetteRadius);
            material.SetFloat("_VSoft", VignetteSoftness);
            material.SetColor("_Color", Color);
            Graphics.Blit(sourceTexture, destTexture, material);
        }
        else
        {
            Graphics.Blit(sourceTexture, destTexture);
        }
    }

    void OnDisable()
    {
        if (curMaterial)
        {
            DestroyImmediate(curMaterial);
        }
    }
}