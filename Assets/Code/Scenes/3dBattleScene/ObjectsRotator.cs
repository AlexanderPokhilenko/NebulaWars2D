using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


using UnityEngine;

public class ObjectsRotator : MonoBehaviour
{
    [SerializeField] private List<Transform> items;
    List<int> speed = new List<int>(){45,10,21,15,80,68,95};
    private float xDelta=10;
    private float index;
    private void Update()
    {
        for (var i = 0; i < items.Count; i++)
        {
            Transform item = items[i];
            item.Rotate(0, speed[i] * Time.deltaTime, 0);
        }
    }

    public void CreateObjects()
    {
        index++;
        for (int i = 0; i < 7; i++)
        {
            GameObject obj = items[i].gameObject;
            Vector3 newPosition = obj.transform.position + new Vector3(xDelta*index,0,0);
            var go = Instantiate(obj);
            go.transform.position = newPosition;
            items.Add(go.transform);
            Random random = new Random();
            int tmp = random.Next(10,400);
            speed.Add(tmp);
        }
    }
}
