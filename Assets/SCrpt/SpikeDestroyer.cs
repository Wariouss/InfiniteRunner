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
        if (collision.TryGetComponent(out ObstaclesClass spike))
        {
            _spikeGenerator.RemoveObstacle(spike);
        }
    }
}