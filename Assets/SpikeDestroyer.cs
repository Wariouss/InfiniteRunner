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
            if (_spikeGenerator)
                _spikeGenerator.generateSpike(spike);
        }
    }
}