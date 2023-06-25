using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpikeGenerator : MonoBehaviour
{
    public float MinSpeed => _minSpeed;
    public float MaxSpeed => _maxSpeed;
    public float CurrentSpeed => _currentSpeed;
    public float SpeedMultiplier => _speedMultiplier;
    
    [SerializeField] private SpikePool spikePool;
    [FormerlySerializedAs("MinSpeed")] [SerializeField] private float _minSpeed;
    [FormerlySerializedAs("MaxSpeed")] [SerializeField] private float _maxSpeed;
    [FormerlySerializedAs("currentSpeed")] [SerializeField] private float _currentSpeed;
    [FormerlySerializedAs("SpeedMultiplier")] [SerializeField] private float _speedMultiplier;

    private List<SpikeScript> _spikes;

    private void Awake()
    {
        _spikes = new List<SpikeScript>();
        _currentSpeed = _minSpeed;
        generateSpike(null);
    }
    
    public void generateSpike(SpikeScript oldSpike)
    {
        if(oldSpike)
        {
            _spikes.Remove(oldSpike);
            spikePool.ReturnObject(oldSpike);
        }
        
        SpikeScript SpikeIns = spikePool.GetObject();
        SpikeIns.transform.position = transform.position;
        SpikeIns.transform.rotation = transform.rotation;
        _spikes.Add(SpikeIns);
    }
    
    public void RandomSpikeGeneration()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateSpike", randomWait);
    }

    private void FixedUpdate()
    {
        ChangeSpeed();
    }

    private void ChangeSpeed()
    {
        if (_currentSpeed > _maxSpeed)
            return;
        
        _currentSpeed += _speedMultiplier;
        
        for (int spikeIndex = 0; spikeIndex < _spikes.Count; spikeIndex++)
            _spikes[spikeIndex].NotifySpeedChange(_currentSpeed);
    }
}