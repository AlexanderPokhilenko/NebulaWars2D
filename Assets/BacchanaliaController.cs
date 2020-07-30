using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BacchanaliaController : MonoBehaviour
{
    private float radius = 4f;
    private bool background = true;
    private bool particleSystem = true;
    [SerializeField] public GameObject[] gos;
    [SerializeField] public GameObject backgroundCanvas;
    private readonly List<float> angles = new List<float>();
    private readonly List<Transform> instances = new List<Transform>();
    private readonly List<ParticleSystem> particleSystemsList = new List<ParticleSystem>();
    
    public void Spawn()
    {
       Random random = new Random();
       int index = random.Next(gos.Length);
       GameObject prefab = gos[index];
       if (prefab != null)
       {
           var instance = Instantiate(prefab);
           var test = instance.GetComponent<Transform>();
           var particleSystems = instance.GetComponents<ParticleSystem>();
           if (particleSystems != null)
           {
                particleSystemsList.AddRange(particleSystems);
           }
           particleSystems = instance.GetComponentsInChildren<ParticleSystem>();
           if (particleSystems != null)
           {
                particleSystemsList.AddRange(particleSystems);
           }
           instances.Add(test);
           angles.Add(index);
       }
    }

    public void ChangeParticleSystem()
    {
        particleSystem = !particleSystem;
        foreach (var system in particleSystemsList)
        {
            system.gameObject.SetActive(particleSystem);
        }
    }

    public void ChangeBackground()
    {
        background = !background;
        backgroundCanvas.gameObject.SetActive(background);
    }
    
    private void Update()
    {
        for (var index = 0; index < instances.Count; index++)
        {
            float angle = angles[index];
            angle += Time.deltaTime;

            var x = Mathf.Cos (angle ) * radius;
            var y = Mathf.Sin (angle) * radius;
            instances[index].position = new Vector2(x, y);

            angles[index] = angle;
        }
    }
}
