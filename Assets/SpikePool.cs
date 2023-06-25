using System.Collections.Generic;
using UnityEngine;

public class SpikePool : MonoBehaviour
{
    public GameObject spikePrefab;
    public int size;
    private Queue<GameObject> pool;

    void Awake()
    {
        pool = new Queue<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(spikePrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
       
       GameObject obj = pool.Dequeue();
       obj.SetActive(true);
       return obj;
        
       
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}

