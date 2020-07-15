using System.Collections;
using UnityEngine;

/// <summary>
/// Это говно создаёт particle system при открытии коробки
/// </summary>
public class LootboxOpenEffectController : MonoBehaviour 
{
    [SerializeField] private GameObject closedBox;
    [SerializeField] private GameObject openedBox;
    [SerializeField] private GameObject effectPrefab;
    
    private bool isOpened;
    
    private void Start()
    {
        isOpened = false;
        closedBox.SetActive(true);
        openedBox.SetActive(false);
    }

    public void OpenLootbox()
    {
        if (!isOpened) 
        {
            StartCoroutine(PlayFx());
        }
    }
    
    private IEnumerator PlayFx()
    {
        isOpened = true;
        yield return new WaitForSeconds(0.2f);

        closedBox.SetActive(false);
        var transform1 = openedBox.transform;
        var position = transform1.position;
        var rotation = transform1.rotation;
        openedBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Instantiate(effectPrefab, position, rotation);
        CameraShake.myCameraShake.ShakeCamera(0.3f, 0.1f);
    }
}