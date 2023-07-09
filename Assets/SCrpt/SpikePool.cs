using Assets.SCrpt;
using System.Collections.Generic;
using UnityEngine;

public class SpikePool : MonoBehaviour
{
    [SerializeField] private ObstaclesClass[] ObstaclePrefab;
    [SerializeField] private int size;
    private Queue<ObstaclesClass> pool;

    void Awake()
    {
        pool = new Queue<ObstaclesClass>();
        List<ObstaclesClass> PreFabs = new List<ObstaclesClass>();

        for (int i = 0; i < size; i++)
        {
            for (int prefabindex = 0; prefabindex < ObstaclePrefab.Length; prefabindex++)
            {
               ObstaclesClass obj = Instantiate(ObstaclePrefab[prefabindex]);
               obj.gameObject.SetActive(false);
               PreFabs.Add(obj);              
            }
        }

        PreFabs.Shuffle();
        for(int poolindex = 0; poolindex<PreFabs.Count; poolindex++)
        {
            pool.Enqueue(PreFabs[poolindex]);
        }
    }


   

    public ObstaclesClass GetObject()
    {
        if (pool.Count < 1)
        {
            return null;
        }
        ObstaclesClass obj = pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnObject(ObstaclesClass obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}