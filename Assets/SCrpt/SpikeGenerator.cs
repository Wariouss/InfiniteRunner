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
    [SerializeField] public ShipPool shipPool;
    [FormerlySerializedAs("MinSpeed")] [SerializeField] private float _minSpeed;
    [FormerlySerializedAs("MaxSpeed")] [SerializeField] private float _maxSpeed;
    [FormerlySerializedAs("currentSpeed")] [SerializeField] private float _currentSpeed;
    [FormerlySerializedAs("SpeedMultiplier")] [SerializeField] private float _speedMultiplier;

    private List<SpikeScript> _spikes;
    private List<SpikeScript> _ships;

    private void Awake()
    {
        _spikes = new List<SpikeScript>();
        _ships = new List<SpikeScript>();
        _currentSpeed = _minSpeed;
        generateSpike(null);
        generateShip(null);
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
    public void generateShip(SpikeScript oldShip)
    {
        if (oldShip)
        {
            _ships.Remove(oldShip);
            shipPool.ReturnObject(oldShip);
        }

        SpikeScript ShipIns = shipPool.GetObject();
        ShipIns.transform.position = new Vector3(25f,2,0);
        ShipIns.transform.rotation = transform.rotation;
        _spikes.Add(ShipIns);

    }
    public void RandomSpikeGeneration()
    {
        float randomWaitSpike = Random.Range(0.01f, 1f);
        float randomWaitShip = Random.Range(0.2f, 1.2f);
        Invoke("generateSpike", randomWaitSpike);
        Invoke("generateShip", randomWaitShip);
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
       
        for (int shipIndex = 0; shipIndex < _ships.Count; shipIndex++)
            _ships[shipIndex].NotifySpeedChange(_currentSpeed);
    }
}