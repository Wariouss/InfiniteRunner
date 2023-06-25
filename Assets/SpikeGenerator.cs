using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;
    public SpikePool spikePool;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;



    private void Awake()
    {
        currentSpeed = MinSpeed;
        generateSpike();

    }


   


    public void generateSpike()
    {
        GameObject SpikeIns = spikePool.GetObject();
        SpikeIns.transform.position = transform.position;
        SpikeIns.transform.rotation = transform.rotation;
        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;

    }

    
    public void RandomSpikeGeneration()
    {

        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateSpike", randomWait);
    }



    
    // Update is called once per frame
       void Update()
    {
       

    }

    private void FixedUpdate()
    {
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }
}
