using UnityEngine;

public class SpikeDestroyer : MonoBehaviour
{
    private SpikeGenerator _spikeGenerator;

    private void Awake()
    {
        _spikeGenerator = FindObjectOfType<SpikeGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out SpikeScript spike))
        {
            if (collision.tag == "spike")
                _spikeGenerator.generateSpike(spike);
                
        }
        if (collision.TryGetComponent(out SpikeScript ship))
        {
            if (collision.tag == "ship")
                _spikeGenerator.generateShip(ship);

        }
    }
}