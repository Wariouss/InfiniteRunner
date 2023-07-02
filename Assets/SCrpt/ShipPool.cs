using System.Collections.Generic;
using UnityEngine;

public class ShipPool : MonoBehaviour
{
    public SpikeScript shipPrefab;
    public int size;
    private Queue<SpikeScript> pool;

    void Awake()
    {
        pool = new Queue<SpikeScript>();

        for (int i = 0; i < size; i++)
        {
            SpikeScript obj = Instantiate(shipPrefab);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public SpikeScript GetObject()
    {
        SpikeScript obj = pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnObject(SpikeScript obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
