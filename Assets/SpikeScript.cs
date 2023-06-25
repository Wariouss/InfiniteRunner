using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public SpikeGenerator spikeGenerator;

    public int size;
    public SpikePool spikePool;



    // Update is called once per frame
    void Update()
    {
        if (spikeGenerator != null)
        {
            transform.Translate(Vector2.left * spikeGenerator.currentSpeed * Time.deltaTime);
        }
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            //spikeGenerator.RandomSpikeGeneration();
            //currentSpike = GetObject(); 
            //currentSpike.SetActive(true);
            //GetObject();
            //Spike.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            //Destroy(this.gameObject);
            spikePool.ReturnObject(Spike);
            if (spikeGenerator != null)
            {
                spikeGenerator.generateSpike();
            }
            //spikePool.ReturnObject(this.gameObject);
        }
    }
}







