

using System;
using System.Collections.Generic;
using Code.Common.Logger;
using UnityEngine;

public class BacchanaliaController : MonoBehaviour
{
    [SerializeField] public GameObject[] gos;
    private float radius = 4f;
    private readonly List<Transform> instances = new List<Transform>();
    private readonly List<float> angles = new List<float>();
    
    public void Spawn()
    {
       var random = new System.Random();
       int index = random.Next(gos.Length);

       GameObject prefab = gos[index];
       if (prefab != null)
       {
           var instance = Instantiate(prefab);
           var test = instance.GetComponent<Transform>();
           instances.Add(test);
           angles.Add(index);
       }

    }
    
    private void Update()
    {
        for (var index = 0; index < instances.Count; index++)
        {
            var angle = angles[index];
            angle += Time.deltaTime; // меняется плавно значение угла

            var x = Mathf.Cos (angle ) * radius;
            var y = Mathf.Sin (angle) * radius;
            instances[index].position = new Vector2(x, y);

            angles[index] = angle;
        }
    }
}
